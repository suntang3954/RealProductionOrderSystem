Imports Microsoft.VisualBasic.FileIO， System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports eMail = System.Net.Mail

Module Excel2MES
    'Public ReadOnly X_Path As String = "X:\CC\CNCC-HY\Teams\05_Manufacturing\Real Production Planning"
    Public ReadOnly X_Path As String = My.Computer.FileSystem.CurrentDirectory
    'below all for Excel to MES

    Private xlApp As Excel.Application
    Private xlWorkBooks As Excel.Workbooks
    Private xlWorkBook As Excel.Workbook
    Private xlWorkSheet As Excel.Worksheet
    Private xlRange As Excel.Range

    Private iWorkOrder As String 'work order number in excel
    Private iMaterial As String 'material description in excel
    Private iPN As String
    Private iNamePlateDesc As String
    Private iPlant As String
    Private iG602Plant As String 'G602 in BOM Column
    Private iG602PN As String 'G602 in BOM Column
    Private iG602PDesc As String 'G602 in BOM Column
    Private iG602PQty As String 'G602 in BOM Column
    Private iDesc As String
    Private iQty As String 'define the quantity of products in one file
    Private iFinishDate As String
    Private iStartDate As String
    Private iBOMPN As String
    Private iBOMDesc As String
    Private iBOMQty As String
    Private isubPN() As String
    Private isubQty() As String
    Private isubDesc() As String
    Private startIndex As Integer
    'Private k As Integer 'actual items number in xls
    Private iG602Qty, iG601Qty, iSPQty As Integer 'total Qty shown on label/email
    Private iG602TT350Qty, iG602TT400Qty, iG602TT700Qty, iG601TT350Qty, iG601TT400Qty, iG601TT700Qty As Integer
    Private iG601TT300Qty, iG602TT300Qty As Integer
    Private IsOldPN As Boolean

    Public Sub FileProcess(ByVal log As TextBox)

        Dim mFileInfo As System.IO.FileInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(".\01_NewOrders")
        Dim filename As String
        Dim nStartXls, nFinishXls As Integer

        Try
            If Directory.Exists(".\02_MES\") Then
                Directory.Delete(".\02_MES\", True)
                log.AppendText(Now & " 删除\02_MES文件夹..." & vbCrLf)
                Directory.CreateDirectory(".\02_MES\")
                log.AppendText(Now & " 重新创建\02_MES文件夹..." & vbCrLf)
            Else
                Directory.CreateDirectory(".\02_MES\")
                log.AppendText(Now & " 创建\02_MES文件夹..." & vbCrLf)
            End If
            MainFrm.ToolStripProgressBar1.Minimum = 0
            MainFrm.ToolStripProgressBar1.Maximum = 100
            nStartXls = mDirInfo.GetFiles("*.xls").Count
            MainFrm.LFileTotal.Text = nStartXls
            log.AppendText(Now & " 发现（" & nStartXls & "）个文件..." & vbCrLf)
            For Each mFileInfo In mDirInfo.GetFiles("*.xls")
                MainFrm.TSSL1.Text = "Processing..."
                filename = mFileInfo.FullName
                log.AppendText(Now & " 开始转换订单文件：" & filename & "..." & vbCrLf)
                ReadFromExcel(filename, log)
                MainFrm.ToolStripProgressBar1.Value = 50
                ReadPN2DESC(iPN, log)
                Write2MES(log) 'Write MES files
                If iPlant = "G602" Then Write4009(log) 'Write G602 material file
                FileSystem.MoveFile(mFileInfo.FullName, ".\05_XlsHistory\" & iPlant & "-" & iPN & "-" & iWorkOrder & "-" & iQty & "-" & Int(Rnd() * 1000) & ".xls", True)
                MainFrm.TSSL1.Text = "Finished..."
                nFinishXls = nFinishXls + 1
                MainFrm.LG601.Text = iG601Qty
                MainFrm.LG602.Text = iG602Qty
                MainFrm.LSP.Text = iSPQty
                MainFrm.LFileFinish.Text = nFinishXls
            Next
            log.AppendText(Now & " 本次转换完成（" & nFinishXls & "）个文件..." & vbCrLf)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ReadFromExcel(ByVal filename As String, ByVal log As TextBox)
        Try
            'Dim infoMaterial() As String
            xlApp = Nothing
            xlWorkBooks = Nothing
            xlWorkBook = Nothing
            xlWorkSheet = Nothing
            xlRange = Nothing
            xlApp = New Excel.Application With {
                .DisplayAlerts = False
            }
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(filename)
            xlWorkSheet = xlWorkBook.Worksheets(1)
            xlRange = xlWorkSheet.UsedRange
            xlApp.Visible = False

            log.AppendText(Now & " 打开订单文件成功..." & vbCrLf)
            iStartDate = CType(xlRange.Cells(1, 1), Excel.Range).Value 'Start Date
            iStartDate = CType(iStartDate, DateTime).ToString("MM.dd.yyyy")
            log.AppendText(Now & " 订单开始日期：" & iStartDate & "..." & vbCrLf)

            iWorkOrder = CType(xlRange.Cells(3, 6), Excel.Range).Value  'WorkOder
            iMaterial = CType(xlRange.Cells(6, 6), Excel.Range).Value  'Material
            iPlant = CType(xlRange.Cells(5, 6), Excel.Range).Value  'Plant
            iQty = Trim(CType(xlRange.Cells(7, 6), Excel.Range).Value)  'Qty
            iFinishDate = CType(xlRange.Cells(8, 6), Excel.Range).Value 'Finish Date
            iFinishDate = Left(iFinishDate, 4) & "." & Mid(iFinishDate, 5, 2) & "." & Right(iFinishDate, 2)
            iFinishDate = CType(iFinishDate, DateTime).ToString("MM.dd.yyyy")

            log.AppendText(Now & " 订单号：" & iWorkOrder & "..." & vbCrLf)
            iPN = iMaterial.Substring(0, iMaterial.IndexOf(" "))
            GetFisrt(iPN, "0")
            iPN = iPN.Substring(startIndex)
            '增加诺德堡的半成品压缩机型号和描述的匹配
            '增加了ifelse判断
            If iPN.StartsWith("600A") Then
                Select Case iPN
                    Case "600A0306"
                        iDesc = "TTS300HHS20020X0XXS413"
                    Case "600A0307"
                        iDesc = "TGS310HHS20020X0XXS413"
                    Case "600A0308"
                        iDesc = "TGS310HHH20020X0XXS413"
                    Case "600A0309"
                        iDesc = "TTS350HHS20020X0XXS413"
                    Case "600A0310"
                        iDesc = "TTS350HHH20020X0XXS413"
                    Case "600A0311"
                        iDesc = "TTS400HHS20020X0XXS413"
                    Case "600A0312"
                        iDesc = "TTS400HHH20020X0XXS413"
                    Case "600A0313"
                        iDesc = "TTS700HHS20020X0XXS413"
                    Case "600A0314"
                        iDesc = "TTS700HHH20020X0XXS413"
                End Select
            Else
                iDesc = iMaterial.Substring(iMaterial.IndexOf(" ") + 1, iMaterial.Length - 1 - iPN.Length)

            End If

            log.AppendText(Now & " 订单PN：" & iPN & "..." & vbCrLf)
            log.AppendText(Now & " 订单描述：" & iDesc & "..." & vbCrLf)
            log.AppendText(Now & " 订单数量：" & iQty & "..." & vbCrLf)
            log.AppendText(Now & " 订单完成日期：" & iFinishDate & "..." & vbCrLf)

            iBOMPN = Nothing
            iBOMDesc = Nothing
            isubPN = Nothing
            isubDesc = Nothing
            iBOMQty = Nothing
            isubQty = Nothing
            iG602Plant = Nothing
            iG602PN = Nothing
            iG602PDesc = Nothing

            For i As Integer = 14 To xlRange.Rows.Count
                Dim iValidation As String = CType(xlRange.Cells(i, 4), Excel.Range).Value
                iBOMPN = iBOMPN & CType(xlRange.Cells(i, 4), Excel.Range).Value & ","
                iBOMQty = iBOMQty & CType(xlRange.Cells(i, 7), Excel.Range).Value / iQty & ","
                'k = i

                If iPlant = "G602" Then
                    iG602Plant = CType(xlRange.Cells(i, 10), Excel.Range).Value
                    If iG602Plant = "G602" Then
                        iG602PN = iG602PN & CType(xlRange.Cells(i, 4), Excel.Range).Value & ","
                        iG602PDesc = iG602PDesc & CType(xlRange.Cells(i, 5), Excel.Range).Value & "|"
                        iG602PQty = iG602PQty & CType(xlRange.Cells(i, 7), Excel.Range).Value & ","
                    End If
                End If

            Next

            isubPN = Split(iBOMPN, ",")
            isubQty = Split(iBOMQty, ",")

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()
            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Sub test(log As TextBox)
        ReadPN2DESC("199B0650", log)
    End Sub
    Private Sub ReadPN2DESC(ByVal searchPN As String, ByVal log As TextBox)
        Try
            'IsOldPN = False
            log.AppendText(Now & " 开始读取PN2Description文件..." & vbCrLf)
            Dim reader As TextReader = File.OpenText(".\PN2Description.txt")
            Dim LineStr As String = ""
            Dim element() As String
            Dim n As Integer = 0
            iNamePlateDesc = ""
            Do While reader.Peek >= 0
                LineStr = LineStr & reader.ReadLine & ","
                n = n + 2
            Loop
            reader.Close()
            element = Split(LineStr, ",")
            For i = 0 To n - 1
                If element(i) = searchPN Then
                    iNamePlateDesc = element(i + 1)
                    Exit For
                End If
            Next

            IsOldPN = isNewMaterialNumber(searchPN)
            'Dim OldPNReader As TextReader = File.OpenText(".\08_Data\OldPNs.txt")
            'Dim OldPNLineStr As String = ""
            'Do While OldPNReader.Peek >= 0
            'OldPNLineStr = OldPNLineStr & OldPNReader.ReadLine & ","
            'Loop
            'If OldPNLineStr.IndexOf(searchPN) >= 0 Then
            'IsOldPN = True
            'End If
            'OldPNReader.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Write2MES(ByVal log As TextBox)
        Try
            log.AppendText(Now & " 开始生成MES文件..." & vbCrLf)
            Dim iVoltagePresent As String = Nothing
            If iDesc.Length > 8 Then
                iVoltagePresent = Mid(iDesc, 8, 1)
            Else
                iVoltagePresent = "SP"
            End If

            Dim iVoltageStr As String
            Select Case iVoltagePresent
                Case "H"
                    iVoltageStr = "4"
                Case "J"
                    iVoltageStr = "4"
                Case Else
                    iVoltageStr = "3"
            End Select

            For i = 1 To CType(iQty, Integer)
                Dim file As System.IO.StreamWriter
                Dim filename As String
                Dim series As String = ""

                If iNamePlateDesc <> "" Then
                    series = Mid(iNamePlateDesc, 1, 5)
                End If
                Select Case series
                    Case "TT300"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TT350"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TT400"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TT700"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG310"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG230"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG390"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG520"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG380"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TG490"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "TT450"
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case "COMPR"
                        series = Mid(iNamePlateDesc, 23, 6)
                        filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                    Case Else
                        filename = "S-" & iPN & "-" & iWorkOrder & "-" & i & "OF" & iQty
                        iSPQty = iSPQty + 1
                End Select

                'filename = series & "-" & iVoltageStr & "-" & iWorkOrder & "-" & i & "OF" & iQty
                If iPlant = "G602" Then filename = filename & "-B"
                file = My.Computer.FileSystem.OpenTextFileWriter(".\02_MES\" & filename & ".mes", True)
                log.AppendText(Now & " 生成MES文件：" & filename & ".mes..." & vbCrLf)
                file.WriteLine("") 'line1
                file.WriteLine(iWorkOrder) 'line2
                file.WriteLine(iPN) 'line3
                file.WriteLine(iNamePlateDesc) 'line4
                file.WriteLine("1") 'line5
                file.WriteLine(iFinishDate) 'line6
                file.WriteLine(iStartDate) 'line7
                file.WriteLine(iDesc) 'line8
                For j = 9 To 39
                    file.WriteLine("") 'empty lines for matching format only
                Next

                'software inform write
                For j = 0 To isubPN.Count - 1
                    If isubPN(j) <> "" Then
                        file.WriteLine(isubPN(j) & "," & isubQty(j))
                    End If
                Next

                'item quantity calculation for G602 and G601
                If iPlant = "G602" Then
                    'file.WriteLine("114009,1")
                    iG602Qty = iG602Qty + 1
                    Select Case series
                        Case "TT300"
                            iG602TT300Qty = iG602TT300Qty + 1
                        Case "TT350"
                            iG602TT350Qty = iG602TT350Qty + 1
                        Case "TT400"
                            iG602TT400Qty = iG602TT400Qty + 1
                        Case "TT700"
                            iG602TT700Qty = iG602TT700Qty + 1
                    End Select
                Else
                    iG601Qty = iG601Qty + 1
                    Select Case series
                        Case "TT300"
                            iG601TT300Qty = iG601TT300Qty + 1
                        Case "TT350"
                            iG601TT350Qty = iG601TT350Qty + 1
                        Case "TT400"
                            iG601TT400Qty = iG601TT400Qty + 1
                        Case "TT700"
                            iG601TT700Qty = iG601TT700Qty + 1
                    End Select
                End If

                If IsOldPN = True Then
                    file.WriteLine("OLD,1")
                Else
                    file.WriteLine("NEW,1")
                End If
                'IsOldPN = False
                If MainFrm.CB_PPAP.Checked = True Then
                    file.WriteLine("PPAP,1")
                Else
                    file.WriteLine("NORMAL,1")
                End If

                file.Close()
                log.AppendText(Now & " 生成完成..." & vbCrLf)

                MainFrm.ToolStripProgressBar1.Value = 50 * i / iQty + 50
            Next
            If IsOldPN = False Then
                Dim OldPNFile As StreamWriter
                OldPNFile = My.Computer.FileSystem.OpenTextFileWriter(".\08_Data\OldPNs.txt", True)
                OldPNFile.WriteLine(iPN)
                OldPNFile.Close()
            End If
            log.AppendText(Now & " 生成MES文件总计（" & iQty & "）..." & vbCrLf)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Write4009(ByVal log As TextBox)
        Try
            log.AppendText(Now & " 开始生成G602物料文件..." & vbCrLf)

            Dim file As System.IO.StreamWriter
            Dim filename As String
            Dim series As String = ""
            Dim i4009subPN() As String = Split(iG602PN, ",")
            Dim i4009subDesc() As String = Split(iG602PDesc, "|")
            Dim i4009subBOMQty() As String = Split(iG602PQty, ",")
            Dim i As Integer = 0

            If iNamePlateDesc <> "" Then
                series = Mid(iNamePlateDesc, 1, 5)
            End If

            filename = series & "-" & iWorkOrder & "-" & iQty
            file = My.Computer.FileSystem.OpenTextFileWriter(".\02_MES\" & filename & ".csv", True)

            For Each element As String In i4009subPN
                If element <> "" Then
                    file.WriteLine(element & "," & i4009subBOMQty(i))
                    i = i + 1
                End If
            Next

            file.Close()
            log.AppendText(Now & " G602物料文件生成完成..." & vbCrLf)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetFisrt(ByVal str As String, ByVal findstr As String)
        For i = 0 To str.Length - 1
            Dim w As String = str.Substring(i, 1)
            If w <> findstr Then
                startIndex = i
                Exit For
            End If
        Next
        Return startIndex
    End Function

    Public Sub AutoEmail()
        Try
            Dim reply = MsgBox("请确认没有错误发生，点击确定后将自动发送邮件!", vbYesNo)
            If reply = vbYes Then
                Dim Email As New eMail.MailMessage
                Dim MailServer As New eMail.SmtpClient("smtp.danfoss.net") With {
                    .UseDefaultCredentials = False,
                    .Port = 25
                    }
                '.Credentials = New Net.NetworkCredential("guo.wei@danfoss.com", "meiwenti@10")
                Dim SenderAddress As New eMail.MailAddress("no_reply@danfoss.com", "Work Order Release")
                Dim BodyText As String = String.Empty

                BodyText = Now & " New work order release/新订单释放" & vbCrLf _
                    & "Factory/工厂 G601" & vbCrLf _
                    & "Quantity/数量:" & iG601Qty & vbCrLf _
                    & "TT300数量:" & iG601TT300Qty & vbCrLf _
                    & "TT350数量:" & iG601TT350Qty & vbCrLf _
                    & "TT400数量:" & iG601TT400Qty & vbCrLf _
                    & "TT700数量:" & iG601TT700Qty & vbCrLf & vbCrLf & vbCrLf _
                    & "Factory/工厂 G602" & vbCrLf _
                    & "Quantity/数量:" & iG602Qty & vbCrLf _
                    & "TT300数量:" & iG602TT300Qty & vbCrLf _
                    & "TT350数量:" & iG602TT350Qty & vbCrLf _
                    & "TT400数量:" & iG602TT400Qty & vbCrLf _
                    & "TT700数量:" & iG602TT700Qty & vbCrLf

                If MainFrm.CB_PPAP.Checked = True Then
                    BodyText = BodyText & vbCrLf _
                    & vbCrLf _
                    & "此订单为特殊管控订单！请确保你知道所要管控的内容！如有疑问请联系计划或工艺！" & vbCrLf
                End If

                With Email
                    .From = SenderAddress
                    .To.Add(New eMail.MailAddress("wujiawei@danfoss.com", "Recipient"))
                    .CC.Add(New eMail.MailAddress("liyan@danfoss.com", "Planner"))
                    .CC.Add(New eMail.MailAddress("wuyujiao@danfoss.com", "Planner"))
                    .CC.Add(New eMail.MailAddress("u261222@danfoss.com", "Stock Keeper"))
                    .CC.Add(New eMail.MailAddress("wubin@danfoss.com", "Stock Keeper"))
                    .Subject = "Work Order Release/订单释放"
                    .Body = BodyText
                    For Each filepath As String In Directory.GetFiles(".\02_MES\")
                        Dim Attach As New Net.Mail.Attachment(filepath)
                        .Attachments.Add(Attach)
                    Next
                End With
                MailServer.Send(Email)
                MsgBox("邮件发送成功！")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub AutoEmailG602(ByVal mWorkOrder As String)
        Try
            Dim reply = MsgBox("检测到G602订单，请确认是否将物料信息用邮件发出!", vbYesNo)
            If reply = vbYes Then
                Dim Email As New eMail.MailMessage
                Dim MailServer As New eMail.SmtpClient("smtp.danfoss.net") With {
                    .UseDefaultCredentials = False,
                    .Port = 25
                    }
                '.Credentials = New Net.NetworkCredential("guo.wei@danfoss.com", "meiwenti@10")
                Dim SenderAddress As New eMail.MailAddress("no_reply@danfoss.com", "G602 WO Release")
                Dim BodyText As String = String.Empty

                BodyText = Now & vbCrLf _
                    & "G602 New WO release/G602新订单释放" & vbCrLf _
                    & "订单信息：" & mWorkOrder & vbCrLf

                With Email
                    .From = SenderAddress
                    .To.Add(New eMail.MailAddress("wujiawei@danfoss.com", "Supervisor"))
                    .CC.Add(New eMail.MailAddress("U331723@danfoss.com", "Leader"))
                    .CC.Add(New eMail.MailAddress("wuyujiao@danfoss.com", "Planner"))
                    .CC.Add(New eMail.MailAddress("u261222@danfoss.com", "Stock Keeper"))
                    .CC.Add(New eMail.MailAddress("wubin@danfoss.com", "Stock Keeper"))
                    .Subject = "G602 Work Order Release/G602订单释放"
                    .Body = BodyText
                    For Each filepath As String In Directory.GetFiles(".\02_MES")
                        If filepath.EndsWith(".csv") Then
                            Dim Attach As New Net.Mail.Attachment(filepath)
                            .Attachments.Add(Attach)
                        End If
                    Next
                End With
                MailServer.Send(Email)
                MsgBox("邮件发送成功！")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Module
