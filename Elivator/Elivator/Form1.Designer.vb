<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim Panel1 As Panel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Panel2 = New Panel()
        lblAlarm = New Label()
        lblStatus = New Label()
        lblFloor = New Label()
        lblDirection = New Label()
        btnAlarm = New Button()
        btnOpen = New Button()
        btnClose = New Button()
        btnFloor4 = New Button()
        btnStop = New Button()
        btnRun = New Button()
        btnFloor3 = New Button()
        btnFloor1 = New Button()
        btnFloor2 = New Button()
        pnlShaft = New Panel()
        pnlElevator = New Panel()
        Panel7 = New Panel()
        Panel6 = New Panel()
        doorRight = New Panel()
        doorLeft = New Panel()
        tmrDoor = New Timer(components)
        tmrElevator = New Timer(components)
        tmrAutoClose = New Timer(components)
        Panel5 = New Panel()
        Panel9 = New Panel()
        lblDirection4 = New Label()
        lblFloor4 = New Label()
        Panel8 = New Panel()
        lblDirection3 = New Label()
        lblFloor3 = New Label()
        Panel4 = New Panel()
        lblDirection2 = New Label()
        lblFloor2 = New Label()
        pnlFloor1 = New Panel()
        lblDirection1 = New Label()
        lblFloor1 = New Label()
        btnFloor4Down = New Button()
        btnFloor3Up = New Button()
        btnFloor3Down = New Button()
        btnFloor2Up = New Button()
        btnFloor2Down = New Button()
        btnFloor1Up = New Button()
        tmrAlarm = New Timer(components)
        Panel1 = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        pnlShaft.SuspendLayout()
        pnlElevator.SuspendLayout()
        Panel5.SuspendLayout()
        Panel9.SuspendLayout()
        Panel8.SuspendLayout()
        Panel4.SuspendLayout()
        pnlFloor1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImage = My.Resources.Resources.bg
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(btnAlarm)
        Panel1.Controls.Add(btnOpen)
        Panel1.Controls.Add(btnClose)
        Panel1.Controls.Add(btnFloor4)
        Panel1.Controls.Add(btnStop)
        Panel1.Controls.Add(btnRun)
        Panel1.Controls.Add(btnFloor3)
        Panel1.Controls.Add(btnFloor1)
        Panel1.Controls.Add(btnFloor2)
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(24, 35)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(235, 711)
        Panel1.TabIndex = 15
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Black
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(lblAlarm)
        Panel2.Controls.Add(lblStatus)
        Panel2.Controls.Add(lblFloor)
        Panel2.Controls.Add(lblDirection)
        Panel2.Location = New Point(14, 19)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(194, 130)
        Panel2.TabIndex = 15
        ' 
        ' lblAlarm
        ' 
        lblAlarm.AutoSize = True
        lblAlarm.Font = New Font("Consolas", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAlarm.ForeColor = Color.Black
        lblAlarm.Location = New Point(11, 95)
        lblAlarm.Name = "lblAlarm"
        lblAlarm.Size = New Size(32, 23)
        lblAlarm.TabIndex = 13
        lblAlarm.Text = "--"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus.ForeColor = Color.Cyan
        lblStatus.Location = New Point(2, 57)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(34, 24)
        lblStatus.TabIndex = 5
        lblStatus.Text = "--"
        ' 
        ' lblFloor
        ' 
        lblFloor.AutoSize = True
        lblFloor.Font = New Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFloor.ForeColor = Color.Lime
        lblFloor.Location = New Point(2, 11)
        lblFloor.Name = "lblFloor"
        lblFloor.Size = New Size(34, 24)
        lblFloor.TabIndex = 4
        lblFloor.Text = "--"
        ' 
        ' lblDirection
        ' 
        lblDirection.AutoSize = True
        lblDirection.Font = New Font("Consolas", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDirection.ForeColor = Color.Yellow
        lblDirection.Location = New Point(143, 6)
        lblDirection.Name = "lblDirection"
        lblDirection.Size = New Size(37, 41)
        lblDirection.TabIndex = 12
        lblDirection.Text = "●"
        ' 
        ' btnAlarm
        ' 
        btnAlarm.BackColor = Color.Transparent
        btnAlarm.BackgroundImage = My.Resources.Resources.alarmbtn
        btnAlarm.BackgroundImageLayout = ImageLayout.Stretch
        btnAlarm.ForeColor = Color.Transparent
        btnAlarm.Location = New Point(14, 510)
        btnAlarm.Name = "btnAlarm"
        btnAlarm.Size = New Size(90, 90)
        btnAlarm.TabIndex = 2
        btnAlarm.UseVisualStyleBackColor = False
        ' 
        ' btnOpen
        ' 
        btnOpen.BackColor = Color.Transparent
        btnOpen.BackgroundImage = My.Resources.Resources.openbtn
        btnOpen.BackgroundImageLayout = ImageLayout.Zoom
        btnOpen.ForeColor = Color.Transparent
        btnOpen.Location = New Point(14, 403)
        btnOpen.Name = "btnOpen"
        btnOpen.Size = New Size(90, 90)
        btnOpen.TabIndex = 9
        btnOpen.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Transparent
        btnClose.BackgroundImage = My.Resources.Resources.closebtn
        btnClose.BackgroundImageLayout = ImageLayout.Zoom
        btnClose.ForeColor = Color.Transparent
        btnClose.Location = New Point(118, 403)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 90)
        btnClose.TabIndex = 10
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnFloor4
        ' 
        btnFloor4.BackgroundImage = My.Resources.Resources._4btn
        btnFloor4.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor4.Font = New Font("Consolas", 15.75F, FontStyle.Bold)
        btnFloor4.Location = New Point(118, 280)
        btnFloor4.Name = "btnFloor4"
        btnFloor4.Size = New Size(90, 90)
        btnFloor4.TabIndex = 14
        btnFloor4.UseVisualStyleBackColor = True
        ' 
        ' btnStop
        ' 
        btnStop.BackColor = Color.Transparent
        btnStop.BackgroundImage = My.Resources.Resources.emebtn
        btnStop.BackgroundImageLayout = ImageLayout.Stretch
        btnStop.ForeColor = Color.Transparent
        btnStop.Location = New Point(118, 510)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(90, 90)
        btnStop.TabIndex = 11
        btnStop.UseVisualStyleBackColor = False
        ' 
        ' btnRun
        ' 
        btnRun.BackColor = Color.LimeGreen
        btnRun.BackgroundImage = My.Resources.Resources.resumebtn
        btnRun.BackgroundImageLayout = ImageLayout.Stretch
        btnRun.ForeColor = Color.White
        btnRun.Location = New Point(65, 613)
        btnRun.Name = "btnRun"
        btnRun.Size = New Size(90, 90)
        btnRun.TabIndex = 13
        btnRun.UseVisualStyleBackColor = False
        ' 
        ' btnFloor3
        ' 
        btnFloor3.BackgroundImage = My.Resources.Resources._3btn
        btnFloor3.BackgroundImageLayout = ImageLayout.Zoom
        btnFloor3.Font = New Font("Consolas", 15.75F, FontStyle.Bold)
        btnFloor3.Location = New Point(14, 279)
        btnFloor3.Name = "btnFloor3"
        btnFloor3.Size = New Size(90, 90)
        btnFloor3.TabIndex = 8
        btnFloor3.UseVisualStyleBackColor = True
        ' 
        ' btnFloor1
        ' 
        btnFloor1.BackgroundImage = My.Resources.Resources._1btn
        btnFloor1.BackgroundImageLayout = ImageLayout.Zoom
        btnFloor1.Font = New Font("Consolas", 15.75F, FontStyle.Bold)
        btnFloor1.ForeColor = Color.Transparent
        btnFloor1.Location = New Point(14, 174)
        btnFloor1.Name = "btnFloor1"
        btnFloor1.Size = New Size(90, 90)
        btnFloor1.TabIndex = 6
        btnFloor1.UseVisualStyleBackColor = True
        ' 
        ' btnFloor2
        ' 
        btnFloor2.BackgroundImage = My.Resources.Resources._2btn
        btnFloor2.BackgroundImageLayout = ImageLayout.Zoom
        btnFloor2.Font = New Font("Consolas", 15.75F, FontStyle.Bold)
        btnFloor2.Location = New Point(118, 174)
        btnFloor2.Name = "btnFloor2"
        btnFloor2.Size = New Size(90, 90)
        btnFloor2.TabIndex = 7
        btnFloor2.UseVisualStyleBackColor = True
        ' 
        ' pnlShaft
        ' 
        pnlShaft.BackColor = Color.DimGray
        pnlShaft.BackgroundImage = CType(resources.GetObject("pnlShaft.BackgroundImage"), Image)
        pnlShaft.BackgroundImageLayout = ImageLayout.Stretch
        pnlShaft.BorderStyle = BorderStyle.FixedSingle
        pnlShaft.Controls.Add(pnlElevator)
        pnlShaft.Location = New Point(659, 68)
        pnlShaft.Name = "pnlShaft"
        pnlShaft.Size = New Size(211, 612)
        pnlShaft.TabIndex = 0
        ' 
        ' pnlElevator
        ' 
        pnlElevator.BackColor = Color.Silver
        pnlElevator.BackgroundImage = CType(resources.GetObject("pnlElevator.BackgroundImage"), Image)
        pnlElevator.BackgroundImageLayout = ImageLayout.Stretch
        pnlElevator.Controls.Add(Panel7)
        pnlElevator.Controls.Add(Panel6)
        pnlElevator.Controls.Add(doorRight)
        pnlElevator.Controls.Add(doorLeft)
        pnlElevator.Location = New Point(24, 152)
        pnlElevator.Name = "pnlElevator"
        pnlElevator.Size = New Size(160, 136)
        pnlElevator.TabIndex = 1
        ' 
        ' Panel7
        ' 
        Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), Image)
        Panel7.BackgroundImageLayout = ImageLayout.Stretch
        Panel7.Location = New Point(0, 1)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(19, 136)
        Panel7.TabIndex = 2
        ' 
        ' Panel6
        ' 
        Panel6.BackgroundImage = My.Resources.Resources.rightpnl
        Panel6.BackgroundImageLayout = ImageLayout.Stretch
        Panel6.Location = New Point(142, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(18, 136)
        Panel6.TabIndex = 1
        ' 
        ' doorRight
        ' 
        doorRight.BackColor = Color.DarkGray
        doorRight.BackgroundImage = My.Resources.Resources.rightdoor
        doorRight.BackgroundImageLayout = ImageLayout.Stretch
        doorRight.BorderStyle = BorderStyle.FixedSingle
        doorRight.Location = New Point(81, 15)
        doorRight.Name = "doorRight"
        doorRight.Size = New Size(61, 118)
        doorRight.TabIndex = 0
        ' 
        ' doorLeft
        ' 
        doorLeft.BackColor = Color.Gray
        doorLeft.BackgroundImage = My.Resources.Resources.leftdoor
        doorLeft.BackgroundImageLayout = ImageLayout.Stretch
        doorLeft.BorderStyle = BorderStyle.FixedSingle
        doorLeft.Location = New Point(18, 15)
        doorLeft.Name = "doorLeft"
        doorLeft.Size = New Size(62, 118)
        doorLeft.TabIndex = 0
        ' 
        ' tmrDoor
        ' 
        tmrDoor.Interval = 15
        ' 
        ' tmrElevator
        ' 
        tmrElevator.Interval = 10
        ' 
        ' tmrAutoClose
        ' 
        tmrAutoClose.Interval = 2500
        ' 
        ' Panel5
        ' 
        Panel5.BackgroundImage = My.Resources.Resources.ChatGPT_Image_May_29__2026__08_11_31_PM
        Panel5.BackgroundImageLayout = ImageLayout.Stretch
        Panel5.Controls.Add(Panel9)
        Panel5.Controls.Add(Panel8)
        Panel5.Controls.Add(Panel4)
        Panel5.Controls.Add(pnlFloor1)
        Panel5.Controls.Add(btnFloor4Down)
        Panel5.Controls.Add(btnFloor3Up)
        Panel5.Controls.Add(btnFloor3Down)
        Panel5.Controls.Add(btnFloor2Up)
        Panel5.Controls.Add(btnFloor2Down)
        Panel5.Controls.Add(btnFloor1Up)
        Panel5.Location = New Point(276, 68)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(783, 651)
        Panel5.TabIndex = 18
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(lblDirection4)
        Panel9.Controls.Add(lblFloor4)
        Panel9.Location = New Point(659, 23)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(40, 32)
        Panel9.TabIndex = 13
        ' 
        ' lblDirection4
        ' 
        lblDirection4.AutoSize = True
        lblDirection4.Font = New Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDirection4.ForeColor = SystemColors.Window
        lblDirection4.Location = New Point(22, 10)
        lblDirection4.Name = "lblDirection4"
        lblDirection4.Size = New Size(11, 19)
        lblDirection4.TabIndex = 14
        lblDirection4.Text = "●"
        lblDirection4.UseCompatibleTextRendering = True
        ' 
        ' lblFloor4
        ' 
        lblFloor4.AutoSize = True
        lblFloor4.Font = New Font("Consolas", 8.25F)
        lblFloor4.ForeColor = SystemColors.ButtonHighlight
        lblFloor4.Location = New Point(3, 11)
        lblFloor4.Name = "lblFloor4"
        lblFloor4.Size = New Size(19, 13)
        lblFloor4.TabIndex = 11
        lblFloor4.Text = "--"
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(lblDirection3)
        Panel8.Controls.Add(lblFloor3)
        Panel8.Location = New Point(659, 168)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(40, 32)
        Panel8.TabIndex = 13
        ' 
        ' lblDirection3
        ' 
        lblDirection3.AutoSize = True
        lblDirection3.Font = New Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDirection3.ForeColor = SystemColors.Window
        lblDirection3.Location = New Point(22, 9)
        lblDirection3.Name = "lblDirection3"
        lblDirection3.Size = New Size(11, 19)
        lblDirection3.TabIndex = 13
        lblDirection3.Text = "●"
        lblDirection3.UseCompatibleTextRendering = True
        ' 
        ' lblFloor3
        ' 
        lblFloor3.AutoSize = True
        lblFloor3.Font = New Font("Consolas", 8.25F)
        lblFloor3.ForeColor = SystemColors.ButtonHighlight
        lblFloor3.Location = New Point(3, 10)
        lblFloor3.Name = "lblFloor3"
        lblFloor3.Size = New Size(19, 13)
        lblFloor3.TabIndex = 8
        lblFloor3.Text = "--"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(lblDirection2)
        Panel4.Controls.Add(lblFloor2)
        Panel4.Location = New Point(659, 321)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(40, 32)
        Panel4.TabIndex = 13
        ' 
        ' lblDirection2
        ' 
        lblDirection2.AutoSize = True
        lblDirection2.Font = New Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDirection2.ForeColor = SystemColors.Window
        lblDirection2.Location = New Point(22, 8)
        lblDirection2.Name = "lblDirection2"
        lblDirection2.Size = New Size(11, 19)
        lblDirection2.TabIndex = 12
        lblDirection2.Text = "●"
        lblDirection2.UseCompatibleTextRendering = True
        ' 
        ' lblFloor2
        ' 
        lblFloor2.AutoSize = True
        lblFloor2.Font = New Font("Consolas", 8.25F)
        lblFloor2.ForeColor = SystemColors.ButtonHighlight
        lblFloor2.Location = New Point(3, 9)
        lblFloor2.Name = "lblFloor2"
        lblFloor2.Size = New Size(19, 13)
        lblFloor2.TabIndex = 9
        lblFloor2.Text = "--"
        ' 
        ' pnlFloor1
        ' 
        pnlFloor1.Controls.Add(lblDirection1)
        pnlFloor1.Controls.Add(lblFloor1)
        pnlFloor1.Location = New Point(658, 464)
        pnlFloor1.Name = "pnlFloor1"
        pnlFloor1.Size = New Size(40, 32)
        pnlFloor1.TabIndex = 12
        ' 
        ' lblDirection1
        ' 
        lblDirection1.AutoSize = True
        lblDirection1.Font = New Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDirection1.ForeColor = SystemColors.Window
        lblDirection1.Location = New Point(23, 9)
        lblDirection1.Name = "lblDirection1"
        lblDirection1.Size = New Size(11, 19)
        lblDirection1.TabIndex = 11
        lblDirection1.Text = "●"
        lblDirection1.UseCompatibleTextRendering = True
        ' 
        ' lblFloor1
        ' 
        lblFloor1.AutoSize = True
        lblFloor1.Font = New Font("Consolas", 8.25F)
        lblFloor1.ForeColor = SystemColors.ButtonHighlight
        lblFloor1.Location = New Point(4, 10)
        lblFloor1.Name = "lblFloor1"
        lblFloor1.Size = New Size(19, 13)
        lblFloor1.TabIndex = 10
        lblFloor1.Text = "--"
        ' 
        ' btnFloor4Down
        ' 
        btnFloor4Down.BackColor = Color.Transparent
        btnFloor4Down.BackgroundImage = My.Resources.Resources.downbtn
        btnFloor4Down.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor4Down.ForeColor = Color.Transparent
        btnFloor4Down.Location = New Point(667, 81)
        btnFloor4Down.Name = "btnFloor4Down"
        btnFloor4Down.Size = New Size(21, 23)
        btnFloor4Down.TabIndex = 7
        btnFloor4Down.UseVisualStyleBackColor = False
        ' 
        ' btnFloor3Up
        ' 
        btnFloor3Up.BackColor = Color.Transparent
        btnFloor3Up.BackgroundImage = My.Resources.Resources.upbtn
        btnFloor3Up.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor3Up.ForeColor = Color.Transparent
        btnFloor3Up.Location = New Point(668, 225)
        btnFloor3Up.Name = "btnFloor3Up"
        btnFloor3Up.Size = New Size(21, 23)
        btnFloor3Up.TabIndex = 5
        btnFloor3Up.UseVisualStyleBackColor = False
        ' 
        ' btnFloor3Down
        ' 
        btnFloor3Down.BackColor = Color.Transparent
        btnFloor3Down.BackgroundImage = My.Resources.Resources.downbtn
        btnFloor3Down.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor3Down.ForeColor = Color.Transparent
        btnFloor3Down.Location = New Point(668, 250)
        btnFloor3Down.Name = "btnFloor3Down"
        btnFloor3Down.Size = New Size(21, 23)
        btnFloor3Down.TabIndex = 4
        btnFloor3Down.UseVisualStyleBackColor = False
        ' 
        ' btnFloor2Up
        ' 
        btnFloor2Up.BackColor = Color.Transparent
        btnFloor2Up.BackgroundImage = My.Resources.Resources.upbtn
        btnFloor2Up.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor2Up.ForeColor = Color.Transparent
        btnFloor2Up.Location = New Point(668, 374)
        btnFloor2Up.Name = "btnFloor2Up"
        btnFloor2Up.Size = New Size(21, 23)
        btnFloor2Up.TabIndex = 3
        btnFloor2Up.UseVisualStyleBackColor = False
        ' 
        ' btnFloor2Down
        ' 
        btnFloor2Down.BackColor = Color.Transparent
        btnFloor2Down.BackgroundImage = My.Resources.Resources.downbtn
        btnFloor2Down.BackgroundImageLayout = ImageLayout.Stretch
        btnFloor2Down.ForeColor = Color.Transparent
        btnFloor2Down.Location = New Point(668, 399)
        btnFloor2Down.Name = "btnFloor2Down"
        btnFloor2Down.Size = New Size(21, 23)
        btnFloor2Down.TabIndex = 2
        btnFloor2Down.UseVisualStyleBackColor = False
        ' 
        ' btnFloor1Up
        ' 
        btnFloor1Up.BackColor = Color.Transparent
        btnFloor1Up.BackgroundImage = CType(resources.GetObject("btnFloor1Up.BackgroundImage"), Image)
        btnFloor1Up.BackgroundImageLayout = ImageLayout.Zoom
        btnFloor1Up.ForeColor = Color.Transparent
        btnFloor1Up.Location = New Point(667, 541)
        btnFloor1Up.Name = "btnFloor1Up"
        btnFloor1Up.Size = New Size(21, 23)
        btnFloor1Up.TabIndex = 1
        btnFloor1Up.UseVisualStyleBackColor = False
        ' 
        ' tmrAlarm
        ' 
        tmrAlarm.Interval = 300
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1107, 772)
        Controls.Add(pnlShaft)
        Controls.Add(Panel5)
        Controls.Add(Panel1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Elevator Simulator"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        pnlShaft.ResumeLayout(False)
        pnlElevator.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        pnlFloor1.ResumeLayout(False)
        pnlFloor1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlShaft As Panel
    Friend WithEvents pnlElevator As Panel
    Friend WithEvents doorLeft As Panel
    Friend WithEvents doorRight As Panel
    Friend WithEvents lblFloor As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents tmrDoor As Timer
    Friend WithEvents tmrElevator As Timer
    Friend WithEvents btnFloor1 As Button
    Friend WithEvents btnFloor2 As Button
    Friend WithEvents btnFloor3 As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents lblDirection As Label
    Friend WithEvents tmrAutoClose As Timer
    Friend WithEvents btnRun As Button
    Friend WithEvents btnFloor4 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAlarm As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnFloor4Down As Button
    Friend WithEvents btnFloor3Up As Button
    Friend WithEvents btnFloor3Down As Button
    Friend WithEvents btnFloor2Up As Button
    Friend WithEvents btnFloor2Down As Button
    Friend WithEvents btnFloor1Up As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblFloor4 As Label
    Friend WithEvents lblFloor1 As Label
    Friend WithEvents lblFloor2 As Label
    Friend WithEvents lblFloor3 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pnlFloor1 As Panel
    Friend WithEvents lblAlarm As Label
    Friend WithEvents tmrAlarm As Timer
    Friend WithEvents lblDirection1 As Label
    Friend WithEvents lblDirection4 As Label
    Friend WithEvents lblDirection3 As Label
    Friend WithEvents lblDirection2 As Label

End Class
