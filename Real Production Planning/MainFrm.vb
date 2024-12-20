Imports Microsoft.VisualBasic.FileIO, System.IO, System.Threading
Imports gListviewControl
Imports Excel = Microsoft.Office.Interop.Excel

Public Class MainFrm
    Private LogFile As StreamWriter
    Private InsertOrderSelectIndex As Integer
    Private Source As Control
    Private Squence As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Version log
            'Ver2.0
            'remove FSW created function, change FSW delete function to just stop and need to reload orders
            'upgrade to fit ONE-ERP auto generate version
            'Ver3.1: add TG380,TG490,TT450 and fix the wrong 600a0312 Description, log the decoding process of the mes files.
            'Ver3.2: add the lock function for avoiding the operation at the same time.
            Dim ver As String = " Ver3.2"
            Me.Text = Me.Text & ver

            BtnUpload.Visible = False
            BtnPlan.Visible = False
            BtnStart.Visible = False
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = 100

            If My.Computer.FileSystem.CurrentDirectory = X_Path Then
                Dim myName As String = My.User.Name
                LogFile = My.Computer.FileSystem.OpenTextFileWriter(X_Path & "\07_Log\" & Today.Year & "-" & Today.Month & "-" & Today.Day & ".log", True)
                TXT_Log.Text = Now & " 启动成功..." & vbCrLf
                TXT_Log.AppendText(Now & " 当前用户..." & myName & vbCrLf)
            Else
                MsgBox("当前执行位置：" & My.Computer.FileSystem.CurrentDirectory & " -错误！")
                LogFile = My.Computer.FileSystem.OpenTextFileWriter(".\07_Log\" & Today.Year & "-" & Today.Month & "-" & Today.Day & ".log", True)
                TXT_Log.Text = Now & " 启动成功..." & vbCrLf
                TXT_Log.AppendText(Now & " 当前用户...TEST" & vbCrLf)
            End If
            lv_C_CurrentOrders.SmallImageList = SIL
            lv_C_NewOrders.SmallImageList = SIL
            GLV_C.SmallImageList = SIL
            LV_F_C.SmallImageList = SIL
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            'If My.Computer.FileSystem.CurrentDirectory = X_Path Then
            TXT_Log.AppendText(Now & " 操作完毕！..." & vbCrLf)
            FSW_Server.Dispose()
            FSW_SparePart.Dispose()
            LogFile.WriteLine(TXT_Log.Text)
            LogFile.Close()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub checkPN_Menu() Handles CheckPNToolStripMenuItem.Click
        Dim your_pn As String = InputBox("输入你要查询的PN: ")

        If isNewMaterialNumber(your_pn) Then
            MsgBox(your_pn & ": New Material Number!")
        Else
            MsgBox(your_pn & "IS USED!")
        End If
    End Sub
    Private Sub updatePN2Desc_Menu() Handles UpdatePNFileToolStripMenuItem.Click
        Dim your_pn As String = InputBox("输入PN:")
        Dim your_des As String = InputBox("输入描述:")
        update_PN2Desc(your_pn, your_des, manual_mode:=True)
    End Sub
    Private Sub getSWV_menu() Handles GetSWVToolStripMenuItem.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBooks As Excel.Workbooks
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim xlRange, resRange As Excel.Range


        Dim your_pn, swv_value, model_value, software_value, software_model As String

        your_pn = InputBox("查询的PN:")

        Dim mDirInfo As New System.IO.DirectoryInfo(".\01_NewOrders")
        For Each xlFile In mDirInfo.GetFiles("*.xls")
            If xlFile.FullName.Contains(your_pn) Then
                TXT_Log.AppendText("try to open the xls file")

                xlApp = Nothing
                xlWorkBooks = Nothing
                xlWorkBook = Nothing
                xlWorkSheet = Nothing
                xlRange = Nothing
                xlApp = New Excel.Application With {
                    .DisplayAlerts = False
                }
                xlWorkBooks = xlApp.Workbooks
                xlWorkBook = xlWorkBooks.Open(xlFile.FullName())
                xlWorkSheet = xlWorkBook.Worksheets(1)
                xlRange = xlWorkSheet.UsedRange
                xlApp.Visible = False

                resRange = xlRange.Find("SWV")
                Try
                    swv_value = resRange.Value
                    model_value = swv_value.Split(" ").GetValue(2)
                    'software pn: 234556-134
                    software_value = CType(xlRange(resRange.Row, resRange.Column - 1), Excel.Range).Value
                    'get the s model:S314
                    software_model = getSoftwareType(software_value)
                    MsgBox("SWV:" & swv_value & Chr(13) &
                       "Model: " & model_value & Chr(13) &
                       "Software:" & software_value & Chr(13) &
                       "SoftwareMode: " & software_model)
                Catch ex As Exception
                    MsgBox("解析SWV 的时候发生错误，造成Mes文件内容可能会出错！", vbOKCancel, "Error")
                End Try
                Exit For
            End If
        Next
        Console.WriteLine("Finished")
    End Sub
    Private Sub material2PnDesc() Handles Material2PNDesToolStripMenuItem.Click
        Dim your_input As String = InputBox("请输入从SAP下载的Excel F6单元格的Material:数据:")
        Dim res As String = ExcelMaterial2PNDesc(your_input)
        MsgBox(res)
    End Sub

    Private Sub about_menu() Handles VersionToolStripMenuItem.Click
        MsgBox("
        version:2.0.0
        Date:2024-12-19
        Modified by: Ke Tang
        ")
    End Sub

#Region "System File Watcher"
    Private Sub FSW_Server_Deleted(sender As Object, e As FileSystemEventArgs) Handles FSW_Server.Deleted
        Try
            FSW_Server.EnableRaisingEvents = False
            lv_C_CurrentOrders.Items.RemoveAt(lv_C_CurrentOrders.FindItemWithText(e.Name).Index)
            MsgBox("正在生产，订单已变更，请重新加载！")
            GLV_C.Clear()
            BtnPlan.Visible = False
            BtnUpload.Visible = False
            'Dim LocalName As String
            'Dim mFileInfo As System.IO.FileInfo
            'Dim mDirInfo As New System.IO.DirectoryInfo(".\04_Pre_Upload")
            'LocalName = e.Name.Substring(e.Name.IndexOf("-") + 1)

            'For Each mFileInfo In mDirInfo.GetFiles("*" & LocalName)
            '    lv_C_CurrentOrders.Items.RemoveAt(lv_C_CurrentOrders.FindItemWithText(e.Name).Index)
            '    If FileSystem.FileExists(".\04_Pre_Upload\" & mFileInfo.Name) Then FileSystem.DeleteFile(".\04_Pre_Upload\" & mFileInfo.Name)
            'Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FSW_SparePart_Deleted(sender As Object, e As FileSystemEventArgs) Handles FSW_SparePart.Deleted
        Try
            FSW_SparePart.EnableRaisingEvents = False
            LV_S_CurrentOrder.Items.RemoveAt(LV_S_CurrentOrder.FindItemWithText(e.Name).Index)
            MsgBox("正在生产，订单已变更，请重新加载！")
            GLV_S.Clear()
            BtnPlan.Visible = False
            BtnUpload.Visible = False

            'If FileSystem.FileExists(".\04_Pre_Upload\" & e.Name) Then FileSystem.DeleteFile(".\04_Pre_Upload\" & e.Name)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FSW_Server_Created(sender As Object, e As FileSystemEventArgs) Handles FSW_Server.Created
        Try
            'Thread.Sleep(1000)
            'ReadMES(COMP_Path & e.Name, e.Name)
            'lv_C_CurrentOrders.Items.Add(co_LVI_0)
            'Lb_C_CO.Text = "Current Orders" & " - " & lv_C_CurrentOrders.Items.Count
            'FileSystem.CopyFile(COMP_Path & e.Name, ".\04_Pre_Upload\" & e.Name)
            TXT_Log.AppendText(Now & " 创建订单文件..." & e.Name & vbCrLf)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FSW_SparePart_Created(sender As Object, e As FileSystemEventArgs) Handles FSW_SparePart.Created
        Try
            'ReadMES(SP_Path & e.Name, e.Name)
            'LV_S_CurrentOrder.Items.Add(co_LVI_0)
            'Lb_S_CO.Text = "Current Orders" & " - " & LV_S_CurrentOrder.Items.Count
            'FileSystem.CopyFile(SP_Path & e.Name, ".\04_Pre_Upload\" & e.Name)
            TXT_Log.AppendText(Now & " 创建订单文件..." & e.Name & vbCrLf)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Buttons"

    Private Sub BtnPlan_Click(sender As Object, e As EventArgs) Handles BtnPlan.Click
        Try
            TXT_Log.AppendText(Now & "点击PLAN按钮..." & vbCrLf)

            'create a lock for avoiding to operate at the same time.
            'If Not createLock(TabControl2.SelectedTab.Name) Then
            'MsgBox("文件正在被操作,请稍后再尝试.")
            'Exit Sub
            'End If

            Select Case TabControl2.SelectedTab.Name
                Case "TP_Compressor"
                    OrderSeq(lv_C_CurrentOrders, lv_C_NewOrders, GLV_C, TXT_Log)
                    Lb_C_NP.Text = "New Planning" & " - " & GLV_C.Items.Count
                Case "TP_SparePart"
                    OrderSeq(LV_S_CurrentOrder, LV_S_NewOrder, GLV_S, TXT_Log)
                    Lb_S_NP.Text = "New Planning" & " - " & GLV_S.Items.Count
                Case "TP_Finished"

            End Select
            'FSW_Server.EnableRaisingEvents = True
            'FSW_SparePart.EnableRaisingEvents = True
            BtnLoad.Visible = True
            BtnUpload.Visible = True
            Squence = True

            Dim mFileInfo As System.IO.FileInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(".\02_MES")
            Dim mWO As String = Nothing
            Dim mCheck As Boolean
            For Each mFileInfo In mDirInfo.GetFiles("*.csv")
                Dim iWO As String = Mid(mFileInfo.Name, 5)
                mWO = mWO & iWO & ","
                mCheck = True
            Next
            If mCheck = True Then
                AutoEmailG602(mWO)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        Try

            TXT_Log.AppendText(Now & "点击UPLOAD按钮..." & vbCrLf)
            TSSL1.Text = "读取当前订单数据..."
            ToolStripProgressBar1.Value = 0
            Dim LastCurrItem As String
            Dim LastSeq As Integer
            Dim FirstC As String

            Select Case TabControl2.SelectedTab.Name
                Case "TP_Compressor"
                    If Squence = True Then  'squence planning
                        ToolStripProgressBar1.Maximum = lv_C_NewOrders.Items.Count
                        If lv_C_CurrentOrders.Items.Count > 0 Then
                            LastCurrItem = lv_C_CurrentOrders.Items(lv_C_CurrentOrders.Items.Count - 1).Text
                            LastSeq = Mid(LastCurrItem, 2, LastCurrItem.IndexOf("-") - 1) + 1
                        Else
                            LastSeq = 10
                        End If

                        FirstC = "A"
                        For Each item As ListViewItem In lv_C_NewOrders.Items
                            If File.Exists(".\04_Pre_UpLoad\" & item.Text) Then
                                'TXT_Log.AppendText(Now & " 处理文件..." & item.Text & vbCrLf)
                                If LastSeq >= 99 Then FirstC = "B"
                                FileSystem.CopyFile(".\04_Pre_UpLoad\" & item.Text, COMP_Path & FirstC & LastSeq & "-" & item.Text, True)
                                FileSystem.MoveFile(".\04_Pre_UpLoad\" & item.Text, ".\06_MESHistory\" & FirstC & LastSeq & "-" & item.Text, True)
                                If FileSystem.FileExists(".\02_MES\" & item.Text) Then FileSystem.DeleteFile(".\02_MES\" & item.Text)
                                LastSeq += 1
                                ToolStripProgressBar1.Value += 1
                                TXT_Log.AppendText(Now & " 处理文件..." & item.Text & " => " & FirstC & LastSeq & "-" & item.Text & vbCrLf)
                            End If
                        Next
                    Else 'not squence means insert orders
                        ToolStripProgressBar1.Maximum = GLV_C.Items.Count
                        LastSeq = 10
                        FirstC = "A"
                        For Each item As ListViewItem In GLV_C.Items

                            Dim RawMES_Name As String
                            If (item.Text.StartsWith("A") OrElse item.Text.StartsWith("B")) Then
                                RawMES_Name = Mid(item.Text, item.Text.IndexOf("-") + 2, item.Text.Length)
                            Else
                                RawMES_Name = item.Text
                            End If

                            If FileSystem.FileExists(COMP_Path & item.Text) Then
                                FSW_Server.EnableRaisingEvents = False
                                FileSystem.DeleteFile(COMP_Path & item.Text)
                            End If
                            If LastSeq = 100 Then FirstC = "B"
                            FileSystem.CopyFile(".\04_Pre_UpLoad\" & item.Text, COMP_Path & FirstC & LastSeq & "-" & RawMES_Name, True)
                            FileSystem.MoveFile(".\04_Pre_UpLoad\" & item.Text, ".\06_MESHistory\" & "A" & LastSeq & "-" & RawMES_Name, True)
                            FSW_Server.EnableRaisingEvents = True
                            If FileSystem.FileExists(".\02_MES\" & item.Text) Then FileSystem.DeleteFile(".\02_MES\" & item.Text)
                            LastSeq = LastSeq + 1
                            ToolStripProgressBar1.Value += 1
                            TXT_Log.AppendText(Now & " 处理文件..." & item.Text & " => " & FirstC & LastSeq & "-" & RawMES_Name & vbCrLf)
                        Next
                    End If
                    FSW_Server.EnableRaisingEvents = False
                    GLV_C.Clear()
                Case "TP_SparePart"
                    If Squence = True Then
                        ToolStripProgressBar1.Maximum = LV_S_NewOrder.Items.Count
                        If LV_S_CurrentOrder.Items.Count > 0 Then
                            LastCurrItem = LV_S_CurrentOrder.Items(LV_S_CurrentOrder.Items.Count - 1).Text
                            LastSeq = Mid(LastCurrItem, 2, LastCurrItem.IndexOf("-") - 1) + 1
                        Else
                            LastSeq = 10
                        End If
                        FirstC = "A"
                        For Each item As ListViewItem In LV_S_NewOrder.Items
                            If File.Exists(".\04_Pre_UpLoad\" & item.Text) Then
                                'TXT_Log.AppendText(Now & " 处理文件..." & item.Text & vbCrLf)
                                If LastSeq >= 99 Then FirstC = "B"
                                FileSystem.CopyFile(".\04_Pre_UpLoad\" & item.Text, SP_Path & FirstC & LastSeq & "-" & item.Text, True)
                                FileSystem.MoveFile(".\04_Pre_UpLoad\" & item.Text, ".\06_MESHistory\" & FirstC & LastSeq & "-" & item.Text, True)
                                If FileSystem.FileExists(".\02_MES\" & item.Text) Then FileSystem.DeleteFile(".\02_MES\" & item.Text)
                                LastSeq += 1
                                ToolStripProgressBar1.Value += 1
                                TXT_Log.AppendText(Now & " 处理文件..." & item.Text & " => " & FirstC & LastSeq & "-" & item.Text & vbCrLf)
                            End If
                        Next
                    Else
                        ToolStripProgressBar1.Maximum = GLV_S.Items.Count
                        LastSeq = 10
                        FirstC = "A"
                        For Each item As ListViewItem In GLV_S.Items
                            Dim RawMES_Name As String
                            If (item.Text.StartsWith("A") OrElse item.Text.StartsWith("B")) Then
                                RawMES_Name = Mid(item.Text, item.Text.IndexOf("-") + 2, item.Text.Length)
                            Else
                                RawMES_Name = item.Text
                            End If
                            'TXT_Log.AppendText(Now & " 处理文件..." & item.Text & vbCrLf)
                            If FileSystem.FileExists(SP_Path & item.Text) Then
                                FSW_SparePart.EnableRaisingEvents = False
                                FileSystem.DeleteFile(SP_Path & item.Text)
                            End If
                            If LastSeq = 100 Then FirstC = "B"
                            FileSystem.CopyFile(".\04_Pre_UpLoad\" & item.Text, SP_Path & FirstC & LastSeq & "-" & RawMES_Name, True)
                            FileSystem.MoveFile(".\04_Pre_UpLoad\" & item.Text, ".\06_MESHistory\" & FirstC & LastSeq & "-" & RawMES_Name, True)
                            FSW_SparePart.EnableRaisingEvents = True
                            If FileSystem.FileExists(".\02_MES\" & item.Text) Then FileSystem.DeleteFile(".\02_MES\" & item.Text)
                            LastSeq = LastSeq + 1
                            ToolStripProgressBar1.Value += 1
                            TXT_Log.AppendText(Now & " 处理文件..." & item.Text & " => " & FirstC & LastSeq & "-" & RawMES_Name & vbCrLf)
                        Next
                    End If
                    FSW_SparePart.EnableRaisingEvents = False
                    GLV_S.Clear()
                Case "TP_Finished"

            End Select
            'release the lock after updating
            'releaseLock(TabControl2.SelectedTab.Name)
            BtnUpload.Visible = False
            BtnPlan.Visible = False
            TXT_Log.AppendText(Now & " 结束上传数据..." & vbCrLf)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Try
            TXT_Log.AppendText(Now & "点击Load按钮..." & vbCrLf)

            If Directory.Exists(".\04_Pre_Upload\") Then
                Directory.Delete(".\04_Pre_Upload\", True)
            End If
            Directory.CreateDirectory(".\04_Pre_Upload\")
            GLV_C.Clear()
            GLV_S.Clear()

            If Not FileSystem.DirectoryExists(COMP_Path) Then
                If My.Computer.Network.Ping("10.62.235.78") Then
                    Open_SAMS_Connection("10.62.235.78", "DATAReader", "meiwenti@1")
                Else
                    MsgBox("Please Check with Engineering if the SAMS server is online or not.")
                End If
            End If
            TXT_Log.AppendText(Now & " SAMS服务器连接成功！..." & vbCrLf)
            Select Case TabControl2.SelectedTab.Name
                Case "TP_Compressor"
                    TSSL1.Text = "读取当前订单数据..."
                    GetCurrent(COMP_Path, lv_C_CurrentOrders, TXT_Log)
                    Lb_C_CO.Text = "Current Orders" & " - " & lv_C_CurrentOrders.Items.Count
                    FSW_Server.Path = COMP_Path
                    FSW_Server.EnableRaisingEvents = True

                    TSSL1.Text = "读取新订单数据..."
                    GetNew(lv_C_NewOrders, True, TXT_Log)
                    Lb_C_NO.Text = "New Orders" & " - " & lv_C_NewOrders.Items.Count
                    InsertOrder(lv_InsertOrder, lv_C_CurrentOrders, lv_C_NewOrders)
                Case "TP_SparePart"
                    TSSL1.Text = "读取当前订单数据..."
                    GetCurrent(SP_Path, LV_S_CurrentOrder, TXT_Log)
                    Lb_S_CO.Text = "Current Orders" & " - " & LV_S_CurrentOrder.Items.Count
                    FSW_SparePart.Path = SP_Path
                    FSW_SparePart.EnableRaisingEvents = True

                    TSSL1.Text = "读取新订单数据..."
                    GetNew(LV_S_NewOrder, False, TXT_Log)
                    Lb_S_NO.Text = "New Orders" & " - " & LV_S_NewOrder.Items.Count
                    InsertOrder(lv_InsertOrder, LV_S_CurrentOrder, LV_S_NewOrder)
                Case "TP_Finished"
                    GetFinished(COMP_F_Path, LV_F_C)
                    GetFinished(SP_F_Path, LV_F_SP)
            End Select

            BtnUpload.Visible = False
            BtnPlan.Visible = True
            TSSL2.Text = "已选择压缩机订单数量：0"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        Try
            TXT_Log.Text = Now & " 开始..." & vbCrLf
            FileProcess(TXT_Log)

            If CB_Email.Checked = True Then
                TSSL1.Text = "自动发送邮件中..."
                AutoEmail()
                TSSL1.Text = "自动发送邮件完成..."
            End If
            BtnStart.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnDetect_Click(sender As Object, e As EventArgs) Handles BtnDetect.Click
        Try
            If Not Directory.Exists(".\01_NewOrders") Then Directory.CreateDirectory(".\01_NewOrders")
            Dim mFileInfo As System.IO.FileInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(".\01_NewOrders")
            ListBox2.Items.Clear()
            For Each mFileInfo In mDirInfo.GetFiles("*.xls")
                ListBox2.Items.Add(mFileInfo.Name)
            Next
            BtnStart.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabControl2_Click(sender As Object, e As EventArgs) Handles TabControl2.Click
        Select Case TabControl2.SelectedTab.Name
            Case "TP_Compressor"
                BtnCopy.Visible = True
                InsertOrder(lv_InsertOrder, lv_C_CurrentOrders, lv_C_NewOrders)
            Case "TP_SparePart"
                BtnCopy.Visible = True
                InsertOrder(lv_InsertOrder, LV_S_CurrentOrder, LV_S_NewOrder)
            Case "TP_Finished"
                BtnCopy.Visible = False
        End Select

    End Sub

    Private Sub BTN_CopyC_Click(sender As Object, e As EventArgs) Handles BTN_CopyC.Click
        AsCopyClick(LV_F_C)
    End Sub

    Private Sub BTN_CopySP_Click(sender As Object, e As EventArgs) Handles BTN_CopySP.Click
        AsCopyClick(LV_F_SP)
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        TXT_Log.AppendText(Now & "点击COPY按钮..." & vbCrLf)

        AsCopyClick(lv_InsertOrder)
    End Sub
#End Region

#Region "GListView"
    Sub GListView_DragHelper(ByVal glist As gListView, Optional ByVal allowedEffect As DragDropEffects = CType(DragDropEffects.Move + DragDropEffects.Copy, DragDropEffects))

        Dim ar As New ArrayList
        For Each DI As ListViewItem In glist.SelectedItems
            ar.Add(DI.Text)
        Next

        If glist.GCurrCursor IsNot Nothing Then
            glist.GCurrCursor.gText = Join(ar.ToArray, vbCrLf)
            glist.GCurrCursor.MakeCursor()
        End If

        Source = CType(glist, Control)

        With glist
            If ar.Count = 1 Then
                .DoDragDrop(.SelectedItems(0), allowedEffect)
            Else
                .DoDragDrop(.SelectedItems, allowedEffect)
            End If
            .Refresh()
        End With
    End Sub

    Private Sub GLV_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles GLV_C.ItemDrag, GLV_S.ItemDrag

        If File.Exists(SP_Path & "lock.loc") Then
            MsgBox("The Spare Parts Station is busy, Pls try it again after a little time.")
        End If
        Dim glist As gListView = CType(sender, gListView)
        GListView_DragHelper(glist, DragDropEffects.Move)
        Squence = False
    End Sub

    Private Sub GLV_C_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GLV_C.SelectedIndexChanged

        Select Case TabControl2.SelectedTab.Name
            Case "TP_Compressor"
                TSSL2.Text = "已选择压缩机订单数量：" & GLV_C.SelectedItems.Count
            Case "TP_SparePart"
                TSSL2.Text = "已选择备件订单数量：" & GLV_S.SelectedItems.Count
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        test(TXT_Log)
    End Sub

#End Region

    Private Sub lv_InsertOrder_DoubleClick(sender As Object, e As EventArgs) Handles lv_InsertOrder.DoubleClick
        'MsgBox(lv_InsertOrder.SelectedItems(0).Text)
        'MsgBox(GLV_C.Items(1).SubItems(2).Text)
        Dim SOrder As String
        SOrder = lv_InsertOrder.SelectedItems(0).Text
        'GLV_C.Select()
        GLV_C.Select()
        GLV_C.SelectedItems.Clear()

        For i = 0 To GLV_C.Items.Count - 1
            If GLV_C.Items(i).SubItems(2).Text = SOrder Then
                GLV_C.MultiSelect = True
                'GLV_C.Items(i).Checked = True
                GLV_C.Items(i).Selected = True
            End If
        Next
    End Sub

End Class
