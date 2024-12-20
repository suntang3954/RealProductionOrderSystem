﻿Imports System.IO
Imports System.Net
Imports System.Data.SqlClient


Module RealPP
    Public co_LVI_0 As ListViewItem
    'Private sr As StreamReader
    Public ReadOnly COMP_Path As String = "\\10.62.235.78\Broadcast\Unprocessed\MES20\"
    Public ReadOnly SP_Path As String = "\\10.62.235.78\Broadcast\Spare Parts\"
    Public ReadOnly COMP_F_Path As String = "\\10.62.235.78\Broadcast\Processed\"
    Public ReadOnly SP_F_Path As String = "\\10.62.235.78\Broadcast\Spare Parts\Processed\"
    Public pn2DescFile As String = "PN2Description.txt"
    Private mFileInfo As System.IO.FileInfo
    Private mDirInfo As System.IO.DirectoryInfo
    Private isPPAP As Boolean
    Private isBonded As Boolean
    Public temFile As String = ""
    Public pcHost As String = Dns.GetHostName()

    'read MES document and update listviewitem
    Public Sub ReadMES(ByVal path As String, ByVal mesName As String)
        'Dim line(2) As String
        'co_LVI_0 = New ListViewItem
        'sr = New StreamReader(path)

        'line(0) = sr.ReadLine
        'line(1) = sr.ReadLine
        'line(2) = sr.ReadLine
        'co_LVI_0.Text = mesName 'MES document name
        'co_LVI_0.SubItems.Add(line(2)) 'PN in MES document
        'co_LVI_0.SubItems.Add(line(1)) 'Work order in MES document
        'sr.Close()
        isPPAP = False
        isBonded = False
        Dim Lines As New List(Of String)
        Dim LastLine As String = Nothing
        Using SR As StreamReader = New StreamReader(path)
            Try
                Do While SR.Peek > -1
                    Lines.Add(SR.ReadLine)
                Loop
            Catch ex As Exception
                MsgBox("Error Occurred during decoding the file of " & mesName)
            End Try
        End Using
        LastLine = Lines.Last
        If Lines.IndexOf("PPAP,1") > 0 Then isPPAP = True
        If Lines.IndexOf("114009,1") > 0 Then isBonded = True

        If LastLine = "PPAP,1" Then
            co_LVI_0 = New ListViewItem(Left(mesName, mesName.Length), 0)
        Else
            co_LVI_0 = New ListViewItem(Left(mesName, mesName.Length))
        End If

        co_LVI_0.SubItems.Add(Lines(2)) 'PN in MES document
        co_LVI_0.SubItems.Add(Lines(1)) 'Work order in MES document
    End Sub
    'get current MES files from RALPH
    Public Sub GetCurrent(ByVal fromPath As String, ByVal listview As ListView, ByVal log As TextBox)
        Try
            log.AppendText(Now & " 连接到当前订单服务器..." & vbCrLf)
            listview.Clear()

            If Directory.Exists(fromPath) Then
                mDirInfo = New DirectoryInfo(fromPath)
                log.AppendText(Now & " 开始读取当前订单MES文件..." & vbCrLf)
                MainFrm.ToolStripProgressBar1.Maximum = mDirInfo.GetFiles("*.mes").Count
                MainFrm.ToolStripProgressBar1.Value = 0
                For Each mFileInfo In mDirInfo.GetFiles("*.mes")
                    log.AppendText(mFileInfo.Name & vbCrLf)
                    ReadMES(mFileInfo.FullName, mFileInfo.Name)
                    listview.Items.Add(co_LVI_0)
                    mFileInfo.CopyTo(".\04_Pre_UpLoad\" & mFileInfo.Name, True)

                    MainFrm.ToolStripProgressBar1.Value += 1
                Next
                log.AppendText(Now & " 读取完成..." & vbCrLf)
                listview.Columns.Add("MES")
                listview.Columns(0).Width = 230
                listview.Columns.Add("PN")
                listview.Columns(1).Width = 80
            Else
                MsgBox("Can not connect to RALPH!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    'get new MES files from share folder
    Public Sub GetNew(ByVal listview As ListView, ByVal isC As Boolean, ByVal log As TextBox)
        Try
            log.AppendText(Now & " 连接到新订单服务器..." & vbCrLf)
            listview.Clear()
            Dim FileStr As String
            If isC = False Then FileStr = "S-*.mes" Else FileStr = "T*.mes"
            If Directory.Exists(".\02_MES\") Then
                mDirInfo = New DirectoryInfo(".\02_MES\")
                log.AppendText(Now & " 开始读取新订单MES文件..." & vbCrLf)
                MainFrm.ToolStripProgressBar1.Maximum = mDirInfo.GetFiles(FileStr).Count
                MainFrm.ToolStripProgressBar1.Value = 0
                For Each mFileInfo In mDirInfo.GetFiles(FileStr)
                    ReadMES(mFileInfo.FullName, mFileInfo.Name)
                    listview.Items.Add(co_LVI_0)
                    mFileInfo.CopyTo(".\04_Pre_UpLoad\" & mFileInfo.Name, True)
                    MainFrm.ToolStripProgressBar1.Value += 1
                Next
                log.AppendText(Now & " 读取完成..." & vbCrLf)
                listview.Columns.Add("MES")
                listview.Columns(0).Width = 230
                listview.Columns.Add("PN")
                listview.Columns(1).Width = 80
            Else
                MsgBox("Can not connect to X: Driver!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    'get finished orders
    Public Sub GetFinished(ByVal CheckPath As String, ByVal listview As ListView)
        Try
            listview.Clear()
            mDirInfo = New DirectoryInfo(CheckPath)
            For Each mFileInfo In mDirInfo.GetFiles("*.mes")
                ReadMES(mFileInfo.FullName, mFileInfo.Name)

                Dim exsitCurrent As Boolean = False
                Dim addPlan As ListViewItem
                If isPPAP Then
                    addPlan = New ListViewItem(co_LVI_0.SubItems(2).Text, 0)
                Else
                    addPlan = New ListViewItem(co_LVI_0.SubItems(2).Text)
                End If
                addPlan.SubItems.Add(co_LVI_0.SubItems(1))
                addPlan.SubItems.Add(1)
                If isBonded Then addPlan.SubItems.Add("Bonded") Else addPlan.SubItems.Add("")
                If isPPAP Then addPlan.SubItems.Add("PPAP")
                If listview.Items.Count = 0 Then
                    listview.Items.Add(addPlan)
                Else
                    For i = 0 To listview.Items.Count - 1
                        If addPlan.Text = listview.Items(i).Text Then
                            exsitCurrent = True
                            listview.Items(i).SubItems(2).Text += 1
                        End If
                    Next
                    If exsitCurrent = False Then listview.Items.Add(addPlan)
                End If
            Next

            listview.Columns.Add("WO")
            listview.Columns(0).Width = 90
            listview.Columns.Add("PN")
            listview.Columns(1).Width = 100
            listview.Columns.Add("Qty")
            listview.Columns(2).Width = 30
            listview.Columns.Add("isBonded")
            listview.Columns(3).Width = 60
            listview.Columns.Add("isPPAP")
            listview.Columns(4).Width = 50
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'planning the orders in sequence mode
    Public Sub OrderSeq(ByVal curOrder As ListView, ByVal newOrder As ListView, ByVal planListview As ListView， ByVal log As TextBox)
        Try
            planListview.Clear()
            For Each item As ListViewItem In curOrder.Items
                planListview.Items.Add(item.Clone)
            Next
            For Each item As ListViewItem In planListview.Items
                item.Selected = True
            Next
            For Each item As ListViewItem In newOrder.Items
                log.AppendText(Now & " 添加新订单..." & item.Name & vbCrLf)
                planListview.Items.Add(item.Clone)
            Next
            planListview.Columns.Add("MES")
            planListview.Columns(0).Width = 230
            planListview.Columns.Add("PN")
            planListview.Columns(1).Width = 80
            MainFrm.Lb_C_NP.Text = "New Planning" & " - " & MainFrm.GLV_C.Items.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'orders show below buttons
    Public Sub InsertOrder(ByVal insListview As ListView, ByVal curListview As ListView, ByVal newListview As ListView)

        insListview.Clear()
        'read from current orders
        For Each item As ListViewItem In curListview.Items

            Dim exsitCurrent As Boolean = False
            Dim addPlan As New ListViewItem With {
                .Text = item.SubItems(2).Text
            }
            addPlan.SubItems.Add(item.SubItems(1))
            addPlan.SubItems.Add(1)
            If insListview.Items.Count = 0 Then
                insListview.Items.Add(addPlan)
            Else
                For i = 0 To insListview.Items.Count - 1
                    If addPlan.Text = insListview.Items(i).Text Then
                        exsitCurrent = True
                        insListview.Items(i).SubItems(2).Text += 1
                    End If
                Next
                If exsitCurrent = False Then insListview.Items.Add(addPlan)
            End If
        Next
        'read from new orders
        For Each item As ListViewItem In newListview.Items
            Dim exsitCurrent As Boolean = False
            Dim addPlan As New ListViewItem With {
                .Text = item.SubItems(2).Text
            }
            addPlan.SubItems.Add(item.SubItems(1))
            addPlan.SubItems.Add(1)
            If insListview.Items.Count = 0 Then
                insListview.Items.Add(addPlan)
            Else
                For i = 0 To insListview.Items.Count - 1
                    If addPlan.Text = insListview.Items(i).Text Then
                        exsitCurrent = True
                        insListview.Items(i).SubItems(2).Text += 1
                    End If
                Next
                If exsitCurrent = False Then insListview.Items.Add(addPlan)
            End If
        Next
        insListview.Columns.Add("WO")
        insListview.Columns(0).Width = 75
        insListview.Columns.Add("PN")
        insListview.Columns(1).Width = 115
        insListview.Columns.Add("Qty")
        insListview.Columns(2).Width = 30

    End Sub

    Public Sub AsCopyClick(ByVal listview As ListView)
        Try

            Dim headers = (From ch In listview.Columns
                           Let header = DirectCast(ch, ColumnHeader)
                           Select header.Text).ToArray()

            Dim items = (From item In listview.Items
                         Let lvi = DirectCast(item, ListViewItem)
                         Select (From subitem In lvi.SubItems
                                 Let si = DirectCast(subitem, ListViewItem.ListViewSubItem)
                                 Select si.Text).ToArray()).ToArray()

            Dim table As String = String.Join(vbTab, headers) & Environment.NewLine
            For Each a In items
                table &= String.Join(vbTab, a) & Environment.NewLine
            Next
            table = table.TrimEnd(CChar(Environment.NewLine))
            Clipboard.SetText(table)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '2024 12 19 update PN2Description.txt
    Public Function update_PN2Desc(ByVal new_pn As String, ByVal description As String, ByVal manual_mode As Boolean) As Boolean
        'example: 
        '600A: CORE COMPRESSOR ASSY - TT400H/TG390H 400V (S) for core
        'Model-H-1-ST-F-O-CH for normal
        Dim new_line As String
        If manual_mode Then
            If "600A" = Left(new_pn, 4) Then
                'Compressor for Nordborg
                new_line = new_pn & description
            Else
                'Normal TTS350HES3S020X0XXS413
                new_line = new_pn & "," & Left(description, 2) + Mid(description, 4, 3) & "-H-1-ST-F-O-CH"
            End If
        Else
            new_line = description
        End If
        Console.WriteLine(new_line)

        If File.Exists(pn2DescFile) Then
            Try
                File.AppendAllText(pn2DescFile, Environment.NewLine & new_line)
                Console.WriteLine(new_pn & " Has been writed.")
                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
                Return False
            End Try
        Else
            MsgBox("找不到 PN2Description.txt")
            Return False
        End If
    End Function
    Public Function ExcelMaterial2PNDesc(ByVal materialDes As String) As String
        '24/12/20
        Dim res As String = ""
        If materialDes.Contains(" ") Then
            Dim startIndex As Integer = materialDes.IndexOf(" ") + 1
            Dim len As Integer = materialDes.Length - startIndex
            Dim str As String = materialDes.Substring(startIndex, len) 'Desc
            If Left(materialDes, 8).Contains("600A") Then
                'NORDBORG CORE
                res = "CORE " & str
            Else
                'NORMAL
                Dim tem As String = Left(str, 7) 'TTS300H
                res = Left(tem, 2) & Mid(tem, 4, 3) & "-" & Right(tem, 1) & "-1-ST-F-O-CH"
            End If

        End If
        Return res
    End Function
    Public Function createLock(ByVal tag) As Boolean
        temFile = pcHost & "-" & tag & "-lock.loc"
        'get all fies in the directory with the .loc extension.
        Dim files As String() = Directory.GetFiles(".", "*.loc")
        If files.Length() > 0 Then
            Return False
        End If

        If Not File.Exists(temFile) Then
            File.Create(temFile).Close()
        End If
        Return True
    End Function
    Public Sub releaseLock(ByVal tag)
        'temFile = temFile & "-" & tag & "-lock.loc"
        If File.Exists(temFile) Then File.Delete(temFile)
    End Sub
    '2024 12 19 check if the material nubmer is new.
    Public Function isNewMaterialNumber(ByVal materialNumber As String) As Boolean
        'RETURN: 0:old,1:new
        Dim connectionString As String =
            "Server=10.62.235.85;Database=WebDB;User Id=pyuser;Password=danfoss;"
        Dim query As String = "select * from [dbo].[MaterialNumberIndex] where MaterialNumber = " & "'" & materialNumber & "'"
        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Try
                        Using reader As SqlDataReader = command.ExecuteReader()
                            If reader.HasRows Then
                                Return False 'there are records in the Database.
                            Else
                                Return True 'not exist in the DB
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
#Region "Connect to Network Driver"
    Public Sub Open_SAMS_Connection(ByVal strComputer As String, ByVal strUsername As String, ByVal strPassword As String)
        Try
            Dim procInfo As New ProcessStartInfo With {
                .FileName = "net",
                .Arguments = "use \\" & strComputer & "\Broadcast /USER:" & strUsername & " " & strPassword,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .CreateNoWindow = True
            }

            Dim proc As New Process With {
                .StartInfo = procInfo
            }
            proc.Start()
            proc.WaitForExit(15000)
        Catch ex As Exception
            MsgBox("Open_Remote_Connection" & vbCrLf & vbCrLf & ex.Message, 4096, "Error")
        End Try
    End Sub

    Public Sub Open_RALPH_Connection(ByVal strComputer As String, ByVal strUsername As String, ByVal strPassword As String)
        Try
            Dim procInfo As New ProcessStartInfo With {
                .FileName = "net",
                .Arguments = "use \\" & strComputer & "\SAP2SAMS /USER:" & strUsername & " " & strPassword,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .CreateNoWindow = True
            }

            Dim proc As New Process With {
                .StartInfo = procInfo
            }
            proc.Start()
            proc.WaitForExit(15000)
        Catch ex As Exception
            MsgBox("Open_Remote_Connection" & vbCrLf & vbCrLf & ex.Message, 4096, "Error")
        End Try
    End Sub

    Public Sub Close_Connection(ByVal device As String)
        'Close_Remote_Connection("net use \\" & compName & "\c$ /delete /yes")
        Shell("cmd.exe /c " & device, vbHidden)
    End Sub
#End Region

End Module