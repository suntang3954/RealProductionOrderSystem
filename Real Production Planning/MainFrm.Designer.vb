<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainFrm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Dim TextShadower1 As gCursorLib.TextShadower = New gCursorLib.TextShadower()
        Me.FSW_Server = New System.IO.FileSystemWatcher()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.BtnDetect = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CB_Email = New System.Windows.Forms.CheckBox()
        Me.CB_PPAP = New System.Windows.Forms.CheckBox()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LSP = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LG601 = New System.Windows.Forms.Label()
        Me.LG602 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LFileFinish = New System.Windows.Forms.Label()
        Me.LFileTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TP_Compressor = New System.Windows.Forms.TabPage()
        Me.GLV_C = New gListviewControl.gListView()
        Me.GCursor_C = New gCursorLib.gCursor(Me.components)
        Me.Lb_C_CO = New System.Windows.Forms.Label()
        Me.lv_C_CurrentOrders = New System.Windows.Forms.ListView()
        Me.Lb_C_NP = New System.Windows.Forms.Label()
        Me.Lb_C_NO = New System.Windows.Forms.Label()
        Me.lv_C_NewOrders = New System.Windows.Forms.ListView()
        Me.TP_SparePart = New System.Windows.Forms.TabPage()
        Me.GLV_S = New gListviewControl.gListView()
        Me.Lb_S_NP = New System.Windows.Forms.Label()
        Me.Lb_S_NO = New System.Windows.Forms.Label()
        Me.LV_S_NewOrder = New System.Windows.Forms.ListView()
        Me.LV_S_CurrentOrder = New System.Windows.Forms.ListView()
        Me.Lb_S_CO = New System.Windows.Forms.Label()
        Me.TP_Finished = New System.Windows.Forms.TabPage()
        Me.BTN_CopySP = New System.Windows.Forms.Button()
        Me.BTN_CopyC = New System.Windows.Forms.Button()
        Me.LV_F_SP = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LV_F_C = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.BtnPlan = New System.Windows.Forms.Button()
        Me.lv_InsertOrder = New System.Windows.Forms.ListView()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TXT_Log = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.TSSL1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FSW_SparePart = New System.IO.FileSystemWatcher()
        Me.SIL = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.FSW_Server, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TP_Compressor.SuspendLayout()
        Me.TP_SparePart.SuspendLayout()
        Me.TP_Finished.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.FSW_SparePart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FSW_Server
        '
        Me.FSW_Server.EnableRaisingEvents = True
        Me.FSW_Server.SynchronizingObject = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 163)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.ListBox2)
        Me.GroupBox4.Controls.Add(Me.BtnDetect)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(566, 66)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "File Detector"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(327, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 43)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(82, 17)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(239, 43)
        Me.ListBox2.TabIndex = 1
        '
        'BtnDetect
        '
        Me.BtnDetect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDetect.Location = New System.Drawing.Point(6, 16)
        Me.BtnDetect.Name = "BtnDetect"
        Me.BtnDetect.Size = New System.Drawing.Size(70, 44)
        Me.BtnDetect.TabIndex = 0
        Me.BtnDetect.Text = "DETECT"
        Me.BtnDetect.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CB_Email)
        Me.GroupBox3.Controls.Add(Me.CB_PPAP)
        Me.GroupBox3.Controls.Add(Me.BtnStart)
        Me.GroupBox3.Location = New System.Drawing.Point(575, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(277, 66)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "File Converter"
        '
        'CB_Email
        '
        Me.CB_Email.AutoSize = True
        Me.CB_Email.Enabled = False
        Me.CB_Email.Location = New System.Drawing.Point(80, 43)
        Me.CB_Email.Name = "CB_Email"
        Me.CB_Email.Size = New System.Drawing.Size(58, 17)
        Me.CB_Email.TabIndex = 2
        Me.CB_Email.Text = "EMAIL"
        Me.CB_Email.UseVisualStyleBackColor = True
        '
        'CB_PPAP
        '
        Me.CB_PPAP.AutoSize = True
        Me.CB_PPAP.Location = New System.Drawing.Point(80, 19)
        Me.CB_PPAP.Name = "CB_PPAP"
        Me.CB_PPAP.Size = New System.Drawing.Size(54, 17)
        Me.CB_PPAP.TabIndex = 1
        Me.CB_PPAP.Text = "PPAP"
        Me.CB_PPAP.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.Location = New System.Drawing.Point(4, 16)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(70, 44)
        Me.BtnStart.TabIndex = 0
        Me.BtnStart.Text = "START"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LSP)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.LG601)
        Me.GroupBox2.Controls.Add(Me.LG602)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LFileFinish)
        Me.GroupBox2.Controls.Add(Me.LFileTotal)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(849, 82)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Converter Info"
        '
        'LSP
        '
        Me.LSP.BackColor = System.Drawing.SystemColors.Window
        Me.LSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSP.Location = New System.Drawing.Point(432, 16)
        Me.LSP.Name = "LSP"
        Me.LSP.Size = New System.Drawing.Size(49, 23)
        Me.LSP.TabIndex = 10
        Me.LSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(326, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Spare Parts QTY"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(166, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "G601 QTY"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(166, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "G602 QTY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LG601
        '
        Me.LG601.BackColor = System.Drawing.SystemColors.Window
        Me.LG601.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LG601.Location = New System.Drawing.Point(272, 16)
        Me.LG601.Name = "LG601"
        Me.LG601.Size = New System.Drawing.Size(48, 23)
        Me.LG601.TabIndex = 6
        Me.LG601.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LG602
        '
        Me.LG602.BackColor = System.Drawing.SystemColors.Window
        Me.LG602.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LG602.Location = New System.Drawing.Point(272, 50)
        Me.LG602.Name = "LG602"
        Me.LG602.Size = New System.Drawing.Size(49, 23)
        Me.LG602.TabIndex = 5
        Me.LG602.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Existing Files"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LFileFinish
        '
        Me.LFileFinish.BackColor = System.Drawing.SystemColors.Window
        Me.LFileFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFileFinish.Location = New System.Drawing.Point(112, 50)
        Me.LFileFinish.Name = "LFileFinish"
        Me.LFileFinish.Size = New System.Drawing.Size(48, 23)
        Me.LFileFinish.TabIndex = 4
        Me.LFileFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LFileTotal
        '
        Me.LFileTotal.BackColor = System.Drawing.SystemColors.Window
        Me.LFileTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFileTotal.Location = New System.Drawing.Point(112, 16)
        Me.LFileTotal.Name = "LFileTotal"
        Me.LFileTotal.Size = New System.Drawing.Size(48, 23)
        Me.LFileTotal.TabIndex = 1
        Me.LFileTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Converted Files"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.Controls.Add(Me.TabControl2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(12, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1355, 398)
        Me.Panel2.TabIndex = 1
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TP_Compressor)
        Me.TabControl2.Controls.Add(Me.TP_SparePart)
        Me.TabControl2.Controls.Add(Me.TP_Finished)
        Me.TabControl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(3, 4)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1025, 391)
        Me.TabControl2.TabIndex = 7
        '
        'TP_Compressor
        '
        Me.TP_Compressor.BackColor = System.Drawing.Color.DarkGreen
        Me.TP_Compressor.Controls.Add(Me.GLV_C)
        Me.TP_Compressor.Controls.Add(Me.Lb_C_CO)
        Me.TP_Compressor.Controls.Add(Me.lv_C_CurrentOrders)
        Me.TP_Compressor.Controls.Add(Me.Lb_C_NP)
        Me.TP_Compressor.Controls.Add(Me.Lb_C_NO)
        Me.TP_Compressor.Controls.Add(Me.lv_C_NewOrders)
        Me.TP_Compressor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TP_Compressor.Location = New System.Drawing.Point(4, 29)
        Me.TP_Compressor.Name = "TP_Compressor"
        Me.TP_Compressor.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Compressor.Size = New System.Drawing.Size(1017, 358)
        Me.TP_Compressor.TabIndex = 0
        Me.TP_Compressor.Text = "Compressor"
        '
        'GLV_C
        '
        Me.GLV_C.AllowDrop = True
        Me.GLV_C.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GLV_C.AutoScroll = gListviewControl.gListView.EAutoScroll.Vertical
        Me.GLV_C.ColorRowA = System.Drawing.Color.White
        Me.GLV_C.ColorRowB = System.Drawing.Color.Beige
        Me.GLV_C.ColorRows = True
        Me.GLV_C.DropBarColor = System.Drawing.Color.Red
        Me.GLV_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLV_C.FullRowSelect = True
        Me.GLV_C.GCurrCursor = Me.GCursor_C
        Me.GLV_C.GCursorVisible = True
        Me.GLV_C.GridLines = True
        Me.GLV_C.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.GLV_C.HideSelection = False
        Me.GLV_C.Location = New System.Drawing.Point(681, 29)
        Me.GLV_C.MatchFont = True
        Me.GLV_C.Name = "GLV_C"
        Me.GLV_C.OwnerDraw = True
        Me.GLV_C.Size = New System.Drawing.Size(330, 323)
        Me.GLV_C.TabIndex = 6
        Me.GLV_C.UseCompatibleStateImageBehavior = False
        Me.GLV_C.View = System.Windows.Forms.View.Details
        '
        'GCursor_C
        '
        Me.GCursor_C.gBlackBitBack = True
        Me.GCursor_C.gBoxShadow = True
        Me.GCursor_C.gCursorImage = CType(resources.GetObject("GCursor_C.gCursorImage"), System.Drawing.Bitmap)
        Me.GCursor_C.gEffect = gCursorLib.gCursor.eEffect.No
        Me.GCursor_C.gFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GCursor_C.gHotSpot = System.Drawing.ContentAlignment.MiddleCenter
        Me.GCursor_C.gIBTransp = 80
        Me.GCursor_C.gImage = CType(resources.GetObject("GCursor_C.gImage"), System.Drawing.Bitmap)
        Me.GCursor_C.gImageBorderColor = System.Drawing.Color.Black
        Me.GCursor_C.gImageBox = New System.Drawing.Size(75, 56)
        Me.GCursor_C.gImageBoxColor = System.Drawing.Color.White
        Me.GCursor_C.gITransp = 0
        Me.GCursor_C.gScrolling = gCursorLib.gCursor.eScrolling.No
        Me.GCursor_C.gShowImageBox = False
        Me.GCursor_C.gShowTextBox = False
        Me.GCursor_C.gTBTransp = 80
        Me.GCursor_C.gText = "Example Text" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Second Line" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Third Line"
        Me.GCursor_C.gTextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.GCursor_C.gTextAutoFit = gCursorLib.gCursor.eTextAutoFit.All
        Me.GCursor_C.gTextBorderColor = System.Drawing.Color.Red
        Me.GCursor_C.gTextBox = New System.Drawing.Size(100, 30)
        Me.GCursor_C.gTextBoxColor = System.Drawing.Color.Blue
        Me.GCursor_C.gTextColor = System.Drawing.Color.Blue
        Me.GCursor_C.gTextFade = gCursorLib.gCursor.eTextFade.Solid
        Me.GCursor_C.gTextMultiline = True
        Me.GCursor_C.gTextShadow = True
        Me.GCursor_C.gTextShadowColor = System.Drawing.Color.Black
        TextShadower1.Alignment = System.Drawing.ContentAlignment.TopCenter
        TextShadower1.Blur = 5.0!
        TextShadower1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        TextShadower1.Offset = CType(resources.GetObject("TextShadower1.Offset"), System.Drawing.PointF)
        TextShadower1.Padding = New System.Windows.Forms.Padding(0)
        TextShadower1.ShadowColor = System.Drawing.Color.Black
        TextShadower1.ShadowTransp = 104
        TextShadower1.Text = "Example Text" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Second Line" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Third Line"
        TextShadower1.TextColor = System.Drawing.Color.Blue
        Me.GCursor_C.gTextShadower = TextShadower1
        Me.GCursor_C.gTTransp = 0
        Me.GCursor_C.gType = gCursorLib.gCursor.eType.Text
        '
        'Lb_C_CO
        '
        Me.Lb_C_CO.BackColor = System.Drawing.Color.PaleGreen
        Me.Lb_C_CO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_C_CO.Location = New System.Drawing.Point(6, 3)
        Me.Lb_C_CO.Name = "Lb_C_CO"
        Me.Lb_C_CO.Size = New System.Drawing.Size(333, 23)
        Me.Lb_C_CO.TabIndex = 1
        Me.Lb_C_CO.Text = "Current Orders"
        Me.Lb_C_CO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lv_C_CurrentOrders
        '
        Me.lv_C_CurrentOrders.AllowDrop = True
        Me.lv_C_CurrentOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lv_C_CurrentOrders.AutoArrange = False
        Me.lv_C_CurrentOrders.BackColor = System.Drawing.Color.LightGray
        Me.lv_C_CurrentOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_C_CurrentOrders.FullRowSelect = True
        Me.lv_C_CurrentOrders.GridLines = True
        Me.lv_C_CurrentOrders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv_C_CurrentOrders.HideSelection = False
        Me.lv_C_CurrentOrders.Location = New System.Drawing.Point(6, 29)
        Me.lv_C_CurrentOrders.Name = "lv_C_CurrentOrders"
        Me.lv_C_CurrentOrders.Size = New System.Drawing.Size(333, 323)
        Me.lv_C_CurrentOrders.TabIndex = 0
        Me.lv_C_CurrentOrders.UseCompatibleStateImageBehavior = False
        Me.lv_C_CurrentOrders.View = System.Windows.Forms.View.Details
        '
        'Lb_C_NP
        '
        Me.Lb_C_NP.BackColor = System.Drawing.Color.PaleGreen
        Me.Lb_C_NP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_C_NP.Location = New System.Drawing.Point(681, 3)
        Me.Lb_C_NP.Name = "Lb_C_NP"
        Me.Lb_C_NP.Size = New System.Drawing.Size(330, 23)
        Me.Lb_C_NP.TabIndex = 5
        Me.Lb_C_NP.Text = "New Planning"
        Me.Lb_C_NP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_C_NO
        '
        Me.Lb_C_NO.BackColor = System.Drawing.Color.PaleGreen
        Me.Lb_C_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_C_NO.Location = New System.Drawing.Point(345, 3)
        Me.Lb_C_NO.Name = "Lb_C_NO"
        Me.Lb_C_NO.Size = New System.Drawing.Size(330, 23)
        Me.Lb_C_NO.TabIndex = 3
        Me.Lb_C_NO.Text = "New Orders"
        Me.Lb_C_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lv_C_NewOrders
        '
        Me.lv_C_NewOrders.AllowDrop = True
        Me.lv_C_NewOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lv_C_NewOrders.AutoArrange = False
        Me.lv_C_NewOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_C_NewOrders.FullRowSelect = True
        Me.lv_C_NewOrders.GridLines = True
        Me.lv_C_NewOrders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv_C_NewOrders.HideSelection = False
        Me.lv_C_NewOrders.Location = New System.Drawing.Point(345, 29)
        Me.lv_C_NewOrders.Name = "lv_C_NewOrders"
        Me.lv_C_NewOrders.Size = New System.Drawing.Size(330, 323)
        Me.lv_C_NewOrders.TabIndex = 2
        Me.lv_C_NewOrders.UseCompatibleStateImageBehavior = False
        Me.lv_C_NewOrders.View = System.Windows.Forms.View.Details
        '
        'TP_SparePart
        '
        Me.TP_SparePart.BackColor = System.Drawing.Color.DarkBlue
        Me.TP_SparePart.Controls.Add(Me.GLV_S)
        Me.TP_SparePart.Controls.Add(Me.Lb_S_NP)
        Me.TP_SparePart.Controls.Add(Me.Lb_S_NO)
        Me.TP_SparePart.Controls.Add(Me.LV_S_NewOrder)
        Me.TP_SparePart.Controls.Add(Me.LV_S_CurrentOrder)
        Me.TP_SparePart.Controls.Add(Me.Lb_S_CO)
        Me.TP_SparePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TP_SparePart.Location = New System.Drawing.Point(4, 29)
        Me.TP_SparePart.Name = "TP_SparePart"
        Me.TP_SparePart.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_SparePart.Size = New System.Drawing.Size(1017, 358)
        Me.TP_SparePart.TabIndex = 1
        Me.TP_SparePart.Text = "Spare Part"
        '
        'GLV_S
        '
        Me.GLV_S.AllowDrop = True
        Me.GLV_S.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GLV_S.AutoScroll = gListviewControl.gListView.EAutoScroll.Vertical
        Me.GLV_S.ColorRowA = System.Drawing.Color.White
        Me.GLV_S.ColorRowB = System.Drawing.Color.Beige
        Me.GLV_S.ColorRows = True
        Me.GLV_S.DropBarColor = System.Drawing.Color.Red
        Me.GLV_S.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLV_S.FullRowSelect = True
        Me.GLV_S.GCurrCursor = Me.GCursor_C
        Me.GLV_S.GCursorVisible = True
        Me.GLV_S.GridLines = True
        Me.GLV_S.HideSelection = False
        Me.GLV_S.Location = New System.Drawing.Point(681, 29)
        Me.GLV_S.MatchFont = True
        Me.GLV_S.Name = "GLV_S"
        Me.GLV_S.OwnerDraw = True
        Me.GLV_S.Size = New System.Drawing.Size(330, 323)
        Me.GLV_S.TabIndex = 8
        Me.GLV_S.UseCompatibleStateImageBehavior = False
        Me.GLV_S.View = System.Windows.Forms.View.Details
        '
        'Lb_S_NP
        '
        Me.Lb_S_NP.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Lb_S_NP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_S_NP.Location = New System.Drawing.Point(681, 3)
        Me.Lb_S_NP.Name = "Lb_S_NP"
        Me.Lb_S_NP.Size = New System.Drawing.Size(330, 23)
        Me.Lb_S_NP.TabIndex = 7
        Me.Lb_S_NP.Text = "New Planning"
        Me.Lb_S_NP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_S_NO
        '
        Me.Lb_S_NO.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Lb_S_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_S_NO.Location = New System.Drawing.Point(345, 3)
        Me.Lb_S_NO.Name = "Lb_S_NO"
        Me.Lb_S_NO.Size = New System.Drawing.Size(330, 23)
        Me.Lb_S_NO.TabIndex = 5
        Me.Lb_S_NO.Text = "New Orders"
        Me.Lb_S_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LV_S_NewOrder
        '
        Me.LV_S_NewOrder.AllowDrop = True
        Me.LV_S_NewOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LV_S_NewOrder.AutoArrange = False
        Me.LV_S_NewOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_S_NewOrder.FullRowSelect = True
        Me.LV_S_NewOrder.GridLines = True
        Me.LV_S_NewOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LV_S_NewOrder.HideSelection = False
        Me.LV_S_NewOrder.Location = New System.Drawing.Point(345, 29)
        Me.LV_S_NewOrder.Name = "LV_S_NewOrder"
        Me.LV_S_NewOrder.Size = New System.Drawing.Size(330, 323)
        Me.LV_S_NewOrder.TabIndex = 4
        Me.LV_S_NewOrder.UseCompatibleStateImageBehavior = False
        Me.LV_S_NewOrder.View = System.Windows.Forms.View.Details
        '
        'LV_S_CurrentOrder
        '
        Me.LV_S_CurrentOrder.AllowDrop = True
        Me.LV_S_CurrentOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LV_S_CurrentOrder.AutoArrange = False
        Me.LV_S_CurrentOrder.BackColor = System.Drawing.Color.LightGray
        Me.LV_S_CurrentOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_S_CurrentOrder.FullRowSelect = True
        Me.LV_S_CurrentOrder.GridLines = True
        Me.LV_S_CurrentOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LV_S_CurrentOrder.HideSelection = False
        Me.LV_S_CurrentOrder.Location = New System.Drawing.Point(6, 29)
        Me.LV_S_CurrentOrder.Name = "LV_S_CurrentOrder"
        Me.LV_S_CurrentOrder.Size = New System.Drawing.Size(333, 323)
        Me.LV_S_CurrentOrder.TabIndex = 3
        Me.LV_S_CurrentOrder.UseCompatibleStateImageBehavior = False
        Me.LV_S_CurrentOrder.View = System.Windows.Forms.View.Details
        '
        'Lb_S_CO
        '
        Me.Lb_S_CO.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Lb_S_CO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_S_CO.Location = New System.Drawing.Point(6, 3)
        Me.Lb_S_CO.Name = "Lb_S_CO"
        Me.Lb_S_CO.Size = New System.Drawing.Size(333, 23)
        Me.Lb_S_CO.TabIndex = 2
        Me.Lb_S_CO.Text = "Current Orders"
        Me.Lb_S_CO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TP_Finished
        '
        Me.TP_Finished.BackColor = System.Drawing.Color.SeaGreen
        Me.TP_Finished.Controls.Add(Me.BTN_CopySP)
        Me.TP_Finished.Controls.Add(Me.BTN_CopyC)
        Me.TP_Finished.Controls.Add(Me.LV_F_SP)
        Me.TP_Finished.Controls.Add(Me.Label2)
        Me.TP_Finished.Controls.Add(Me.LV_F_C)
        Me.TP_Finished.Controls.Add(Me.Label1)
        Me.TP_Finished.Location = New System.Drawing.Point(4, 29)
        Me.TP_Finished.Name = "TP_Finished"
        Me.TP_Finished.Size = New System.Drawing.Size(1017, 358)
        Me.TP_Finished.TabIndex = 2
        Me.TP_Finished.Text = "Finished"
        '
        'BTN_CopySP
        '
        Me.BTN_CopySP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CopySP.Location = New System.Drawing.Point(681, 74)
        Me.BTN_CopySP.Name = "BTN_CopySP"
        Me.BTN_CopySP.Size = New System.Drawing.Size(135, 38)
        Me.BTN_CopySP.TabIndex = 9
        Me.BTN_CopySP.Text = "Spare Part"
        Me.BTN_CopySP.UseVisualStyleBackColor = True
        '
        'BTN_CopyC
        '
        Me.BTN_CopyC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CopyC.Location = New System.Drawing.Point(681, 30)
        Me.BTN_CopyC.Name = "BTN_CopyC"
        Me.BTN_CopyC.Size = New System.Drawing.Size(135, 38)
        Me.BTN_CopyC.TabIndex = 8
        Me.BTN_CopyC.Text = "Compressor"
        Me.BTN_CopyC.UseVisualStyleBackColor = True
        '
        'LV_F_SP
        '
        Me.LV_F_SP.AllowDrop = True
        Me.LV_F_SP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LV_F_SP.AutoArrange = False
        Me.LV_F_SP.BackColor = System.Drawing.Color.LightGray
        Me.LV_F_SP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_F_SP.FullRowSelect = True
        Me.LV_F_SP.GridLines = True
        Me.LV_F_SP.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LV_F_SP.HideSelection = False
        Me.LV_F_SP.Location = New System.Drawing.Point(342, 30)
        Me.LV_F_SP.Name = "LV_F_SP"
        Me.LV_F_SP.Size = New System.Drawing.Size(333, 323)
        Me.LV_F_SP.TabIndex = 7
        Me.LV_F_SP.UseCompatibleStateImageBehavior = False
        Me.LV_F_SP.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(342, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(333, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Spare Part Orders"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LV_F_C
        '
        Me.LV_F_C.AllowDrop = True
        Me.LV_F_C.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LV_F_C.AutoArrange = False
        Me.LV_F_C.BackColor = System.Drawing.Color.LightGray
        Me.LV_F_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_F_C.FullRowSelect = True
        Me.LV_F_C.GridLines = True
        Me.LV_F_C.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LV_F_C.HideSelection = False
        Me.LV_F_C.Location = New System.Drawing.Point(3, 30)
        Me.LV_F_C.Name = "LV_F_C"
        Me.LV_F_C.Size = New System.Drawing.Size(333, 323)
        Me.LV_F_C.TabIndex = 4
        Me.LV_F_C.UseCompatibleStateImageBehavior = False
        Me.LV_F_C.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleGreen
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(333, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Compressor Orders"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnCopy)
        Me.GroupBox1.Controls.Add(Me.BtnPlan)
        Me.GroupBox1.Controls.Add(Me.lv_InsertOrder)
        Me.GroupBox1.Controls.Add(Me.BtnLoad)
        Me.GroupBox1.Controls.Add(Me.BtnUpload)
        Me.GroupBox1.Location = New System.Drawing.Point(1034, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 391)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Planning"
        '
        'BtnCopy
        '
        Me.BtnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopy.Location = New System.Drawing.Point(191, 19)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(52, 52)
        Me.BtnCopy.TabIndex = 12
        Me.BtnCopy.Text = "COPY"
        Me.BtnCopy.UseVisualStyleBackColor = True
        Me.BtnCopy.Visible = False
        '
        'BtnPlan
        '
        Me.BtnPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlan.Location = New System.Drawing.Point(64, 19)
        Me.BtnPlan.Name = "BtnPlan"
        Me.BtnPlan.Size = New System.Drawing.Size(52, 52)
        Me.BtnPlan.TabIndex = 0
        Me.BtnPlan.Text = "PLAN"
        Me.BtnPlan.UseVisualStyleBackColor = True
        '
        'lv_InsertOrder
        '
        Me.lv_InsertOrder.AllowDrop = True
        Me.lv_InsertOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lv_InsertOrder.AutoArrange = False
        Me.lv_InsertOrder.FullRowSelect = True
        Me.lv_InsertOrder.GridLines = True
        Me.lv_InsertOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv_InsertOrder.HideSelection = False
        Me.lv_InsertOrder.Location = New System.Drawing.Point(6, 77)
        Me.lv_InsertOrder.MultiSelect = False
        Me.lv_InsertOrder.Name = "lv_InsertOrder"
        Me.lv_InsertOrder.Size = New System.Drawing.Size(237, 308)
        Me.lv_InsertOrder.TabIndex = 7
        Me.lv_InsertOrder.UseCompatibleStateImageBehavior = False
        Me.lv_InsertOrder.View = System.Windows.Forms.View.Details
        '
        'BtnLoad
        '
        Me.BtnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.Location = New System.Drawing.Point(6, 19)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(52, 52)
        Me.BtnLoad.TabIndex = 11
        Me.BtnLoad.Text = "LOAD"
        Me.BtnLoad.UseVisualStyleBackColor = True
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.Color.Orange
        Me.BtnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.Location = New System.Drawing.Point(122, 19)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(63, 52)
        Me.BtnUpload.TabIndex = 10
        Me.BtnUpload.Text = "UPDATE"
        Me.BtnUpload.UseVisualStyleBackColor = False
        Me.BtnUpload.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.Info
        Me.Panel3.Controls.Add(Me.TXT_Log)
        Me.Panel3.Location = New System.Drawing.Point(873, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(497, 163)
        Me.Panel3.TabIndex = 2
        '
        'TXT_Log
        '
        Me.TXT_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_Log.Location = New System.Drawing.Point(3, 3)
        Me.TXT_Log.Multiline = True
        Me.TXT_Log.Name = "TXT_Log"
        Me.TXT_Log.ReadOnly = True
        Me.TXT_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TXT_Log.Size = New System.Drawing.Size(491, 157)
        Me.TXT_Log.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.TSSL1, Me.TSSL2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 582)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1370, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'TSSL1
        '
        Me.TSSL1.Name = "TSSL1"
        Me.TSSL1.Size = New System.Drawing.Size(0, 17)
        '
        'TSSL2
        '
        Me.TSSL2.Name = "TSSL2"
        Me.TSSL2.Size = New System.Drawing.Size(0, 17)
        '
        'FSW_SparePart
        '
        Me.FSW_SparePart.EnableRaisingEvents = True
        Me.FSW_SparePart.SynchronizingObject = Me
        '
        'SIL
        '
        Me.SIL.ImageStream = CType(resources.GetObject("SIL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SIL.TransparentColor = System.Drawing.Color.Transparent
        Me.SIL.Images.SetKeyName(0, "PPAP.jpg")
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 604)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTC Real Production Planning V1.1"
        CType(Me.FSW_Server, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TP_Compressor.ResumeLayout(False)
        Me.TP_SparePart.ResumeLayout(False)
        Me.TP_Finished.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.FSW_SparePart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FSW_Server As IO.FileSystemWatcher
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lv_C_CurrentOrders As ListView
    Friend WithEvents Lb_C_CO As Label
    Friend WithEvents Lb_C_NO As Label
    Friend WithEvents lv_C_NewOrders As ListView
    Friend WithEvents Lb_C_NP As Label
    Friend WithEvents TXT_Log As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnPlan As Button
    Friend WithEvents lv_InsertOrder As ListView
    Friend WithEvents BtnUpload As Button
    Friend WithEvents BtnLoad As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents LFileTotal As Label
    Friend WithEvents BtnStart As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents TSSL1 As ToolStripStatusLabel
    Friend WithEvents LFileFinish As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LG601 As Label
    Friend WithEvents LG602 As Label
    Friend WithEvents CB_PPAP As CheckBox
    Friend WithEvents CB_Email As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents BtnDetect As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TP_Compressor As TabPage
    Friend WithEvents TP_SparePart As TabPage
    Friend WithEvents Lb_S_NP As Label
    Friend WithEvents Lb_S_NO As Label
    Friend WithEvents LV_S_NewOrder As ListView
    Friend WithEvents LV_S_CurrentOrder As ListView
    Friend WithEvents Lb_S_CO As Label
    Friend WithEvents GLV_C As gListviewControl.gListView
    Friend WithEvents GCursor_C As gCursorLib.gCursor
    Friend WithEvents GLV_S As gListviewControl.gListView
    Friend WithEvents FSW_SparePart As IO.FileSystemWatcher
    Friend WithEvents SIL As ImageList
    Friend WithEvents TP_Finished As TabPage
    Friend WithEvents LV_F_SP As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents LV_F_C As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_CopySP As Button
    Friend WithEvents BTN_CopyC As Button
    Friend WithEvents BtnCopy As Button
    Friend WithEvents TSSL2 As ToolStripStatusLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents LSP As Label
    Friend WithEvents Label3 As Label
End Class
