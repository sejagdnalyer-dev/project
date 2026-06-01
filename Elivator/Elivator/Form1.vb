Imports System.Collections.Generic

Public Class Form1
    Dim currentFloor As Integer = 1
    Dim targetFloor As Integer = 1

    Dim elevatorBusy As Boolean = False
    Dim doorOpening As Boolean = False
    Dim emergencyStop As Boolean = False
    Dim systemStopped As Boolean = False
    Dim doorsMoving As Boolean = False
    ' Door state
    Dim doorsOpened As Boolean = False
    Dim floorQueue As New Queue(Of Integer)

    Dim floor1Y As Integer = 452
    Dim floor2Y As Integer = 303
    Dim floor3Y As Integer = 156
    Dim floor4Y As Integer = 2

    Dim targetY As Integer
    Dim alarmActive As Boolean = False
    ' Elevator positions
    Dim floorY() As Integer = {452, 303, 156, 2}



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnRun.Click, AddressOf btnRun_Click
        btnRun.Enabled = False
        pnlElevator.Top = floorY(0)

        lblFloor.Text = "1"
        lblFloor1.Text = "1"
        lblFloor2.Text = "1"
        lblFloor3.Text = "1"
        lblFloor4.Text = "1"



    End Sub

    Private Sub btnFloor1_Click(sender As Object, e As EventArgs) Handles btnFloor1.Click
        AddFloorRequest(1)
    End Sub

    Private Sub btnFloor2_Click(sender As Object, e As EventArgs) Handles btnFloor2.Click
        AddFloorRequest(2)
    End Sub

    Private Sub btnFloor3_Click(sender As Object, e As EventArgs) Handles btnFloor3.Click
        AddFloorRequest(3)
    End Sub

    Private Sub btnFloor4_Click(sender As Object, e As EventArgs) Handles btnFloor4.Click
        AddFloorRequest(4)
    End Sub



    Private Sub AddFloorRequest(floor As Integer)
        If alarmActive Then Exit Sub
        ' Avoid duplicate requests
        If Not floorQueue.Contains(floor) Then

            floorQueue.Enqueue(floor)

        End If

        lblStatus.Text = "QUEUE: " & String.Join(",", floorQueue)

        ' Start elevator if idle
        If elevatorBusy = False Then

            ProcessNextFloor()

        End If

    End Sub

    Private Sub ProcessNextFloor()

        If floorQueue.Count = 0 Then

            elevatorBusy = False

            lblStatus.Text = "IDLE"

            Return

        End If

        elevatorBusy = True

        targetFloor = floorQueue.Dequeue()

        If targetFloor > currentFloor Then

            lblDirection.Text = "↑"
            lblDirection1.Text = "↑"
            lblDirection2.Text = "↑"
            lblDirection3.Text = "↑"
            lblDirection4.Text = "↑"
            lblStatus.Text = "MOVING UP"

        ElseIf targetFloor < currentFloor Then

            lblDirection.Text = "↓"
            lblDirection1.Text = "↓"
            lblDirection2.Text = "↓"
            lblDirection3.Text = "↓"
            lblDirection4.Text = "↓"
            lblStatus.Text = "MOVING DOWN"

        Else

            OpenDoors()
            Return

        End If

        tmrElevator.Start()

    End Sub


    Private Sub tmrElevator_Tick(sender As Object, e As EventArgs) Handles tmrElevator.Tick
        If systemStopped Then Exit Sub
        If emergencyStop Then

            tmrElevator.Stop()
            lblStatus.Text = "EMERGENCY STOP"
            Return

        End If

        Dim targetY As Integer = floorY(targetFloor - 1)

        If pnlElevator.Top > targetY Then

            pnlElevator.Top -= 2

        ElseIf pnlElevator.Top < targetY Then

            pnlElevator.Top += 2

        End If

        If Math.Abs(pnlElevator.Top - targetY) <= 2 Then

            pnlElevator.Top = targetY

            tmrElevator.Stop()

            currentFloor = targetFloor

            lblFloor.Text = currentFloor.ToString()
            lblFloor1.Text = currentFloor.ToString()
            lblFloor2.Text = currentFloor.ToString()
            lblFloor3.Text = currentFloor.ToString()
            lblFloor4.Text = currentFloor.ToString()

            lblStatus.Text = "ARRIVED"



            ' Wait before opening doors
            Dim waitDoor As New Timer

            waitDoor.Interval = 1000

            AddHandler waitDoor.Tick,
    Sub()

        waitDoor.Stop()

        OpenDoors()

    End Sub

            waitDoor.Start()

        End If

    End Sub

    Private Sub OpenDoors()

        If doorsOpened Then Return

        doorOpening = True

        doorsMoving = True

        lblStatus.Text = "OPENING DOORS"

        tmrDoor.Start()

    End Sub

    Private Sub CloseDoors()
        If alarmActive Then Exit Sub
        If Not doorsOpened Then Return

        doorOpening = False

        doorsMoving = True

        lblStatus.Text = "CLOSING DOORS"

        tmrDoor.Start()

    End Sub

    Private Sub tmrDoor_Tick(sender As Object, e As EventArgs) Handles tmrDoor.Tick
        If systemStopped Then Exit Sub
        ' OPENING
        If doorOpening Then

            If doorLeft.Width > 5 Then

                doorLeft.Width -= 2

                doorRight.Width -= 2
                doorRight.Left += 2

            Else

                tmrDoor.Stop()

                doorsOpened = True
                doorsMoving = False

                lblStatus.Text = "DOORS OPEN"

                If Not alarmActive Then

                    ' Wait before closing
                    tmrAutoClose.Start()

                End If

            End If

                Else

            ' CLOSING
            If doorLeft.Width < 80 Then

                doorLeft.Width += 2

                doorRight.Width += 2
                doorRight.Left -= 2

            Else

                tmrDoor.Stop()

                doorsOpened = False
                doorsMoving = False

                doorLeft.Width = 80
                doorRight.Width = 80
                doorRight.Left = 80

                lblStatus.Text = "IDLE"

                ProcessNextFloor()

                EnableButtons()

            End If

        End If
    End Sub

    Private Sub tmrAutoClose_Tick(sender As Object, e As EventArgs) Handles tmrAutoClose.Tick

        If alarmActive Then Exit Sub
        CloseDoors()

    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If alarmActive Then Exit Sub
        If systemStopped Then Exit Sub

        ' If doors already open,
        ' reset auto-close timer
        If doorsOpened Then

            tmrAutoClose.Stop()
            tmrAutoClose.Start()

            lblStatus.Text = "DOORS HELD OPEN"

            Return

        End If

        ' Prevent duplicate animations
        If doorsMoving Then Exit Sub

        ' Open doors only if elevator not moving
        If tmrElevator.Enabled = False Then

            tmrAutoClose.Stop()

            OpenDoors()

        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If alarmActive Then Exit Sub
        If systemStopped Then Exit Sub

        ' Prevent duplicate animations
        If doorsMoving Then Exit Sub

        ' Only close if already open
        If doorsOpened Then

            tmrAutoClose.Stop()

            CloseDoors()

        End If

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        systemStopped = True

        ' Update LCD
        lblStatus.Text = "SYSTEM STOPPED"

        lblDirection.Text = "■"

        btnStop.BackColor = Color.DarkRed

        ' Disable ALL controls
        btnFloor1.Enabled = False
        btnFloor2.Enabled = False
        btnFloor3.Enabled = False
        btnFloor4.Enabled = False

        btnOpen.Enabled = False
        btnClose.Enabled = False

        ' ONLY RUN BUTTON ENABLED
        btnRun.Enabled = True

    End Sub



    Private Sub DisableButtons()

        btnFloor1.Enabled = False
        btnFloor2.Enabled = False
        btnFloor3.Enabled = False
        btnFloor4.Enabled = False



    End Sub

    Private Sub EnableButtons()

        btnFloor1.Enabled = True
        btnFloor2.Enabled = True
        btnFloor3.Enabled = True
        btnFloor4.Enabled = True


    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs)

        systemStopped = False

        lblStatus.Text = "SYSTEM RUNNING"

        btnStop.BackColor = Color.Red

        ' Re-enable controls
        btnFloor1.Enabled = True
        btnFloor2.Enabled = True
        btnFloor3.Enabled = True
        btnFloor4.Enabled = True

        btnOpen.Enabled = True
        btnClose.Enabled = True

        ' Resume elevator if needed
        If currentFloor <> targetFloor Then

            If targetFloor > currentFloor Then

                lblDirection.Text = "↑"
                lblDirection1.Text = "↑"
                lblDirection2.Text = "↑"
                lblDirection3.Text = "↑"
                lblDirection4.Text = "↑"

                lblStatus.Text = "MOVING UP"

            ElseIf targetFloor < currentFloor Then

                lblDirection.Text = "↓"
                lblDirection1.Text = "↓"
                lblDirection2.Text = "↓"
                lblDirection3.Text = "↓"
                lblDirection4.Text = "↓"

                lblStatus.Text = "MOVING DOWN"

            End If

            tmrElevator.Start()

        Else

            lblStatus.Text = "IDLE"

        End If

    End Sub

    Private Sub btnFloor2Up_Click(sender As Object, e As EventArgs) Handles btnFloor2Up.Click
        AddFloorRequest(2)
    End Sub

    Private Sub btnFloor2Down_Click(sender As Object, e As EventArgs) Handles btnFloor2Down.Click
        AddFloorRequest(2)
    End Sub

    Private Sub btnFloor3Up_Click(sender As Object, e As EventArgs) Handles btnFloor3Up.Click
        AddFloorRequest(3)

    End Sub

    Private Sub btnFloor3Down_Click(sender As Object, e As EventArgs) Handles btnFloor3Down.Click

        AddFloorRequest(3)
    End Sub

    Private Sub btnFloor4Down_Click(sender As Object, e As EventArgs) Handles btnFloor4Down.Click
        AddFloorRequest(4)

    End Sub

    Private Sub btnFloor1Up_Click(sender As Object, e As EventArgs) Handles btnFloor1Up.Click
        AddFloorRequest(1)

    End Sub

    Private Sub btnAlarm_Click(sender As Object, e As EventArgs) Handles btnAlarm.Click

        alarmActive = Not alarmActive

        If alarmActive Then
            lblAlarm.ForeColor = Color.Red
            lblDirection.ForeColor = Color.Red

            tmrAlarm.Start()

            ' STOP elevator
            tmrElevator.Stop()

            ' STOP auto close
            tmrAutoClose.Stop()

            ' OPEN doors
            OpenDoors()

            ' STATUS
            lblAlarm.Text = "EMERGENCY ALARM"

            ' DIRECTION DISPLAY
            lblDirection.Text = "⚠"
            lblDirection1.Text = "⚠"
            lblDirection2.Text = "⚠"
            lblDirection3.Text = "⚠"
            lblDirection4.Text = "⚠"


            ' BUTTON COLOR
            btnAlarm.BackColor = Color.Red

            ' DISABLE controls
            DisableButtons()

            btnOpen.Enabled = False
            btnClose.Enabled = False

            ' SOUND
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)

        Else
            lblAlarm.ForeColor = Color.Lime
            lblDirection.ForeColor = Color.Lime

            tmrAlarm.Stop()

            lblAlarm.Visible = True

            ' RESET alarm
            lblAlarm.Text = "IDLE"

            btnAlarm.BackColor = DefaultBackColor

            ' ENABLE controls
            EnableButtons()

            btnOpen.Enabled = True
            btnClose.Enabled = True

        End If

    End Sub

    Private Sub tmrAlarm_Tick(sender As Object, e As EventArgs) Handles tmrAlarm.Tick
        If lblAlarm.ForeColor = Color.Red Then

            lblAlarm.ForeColor = Color.Black
            lblDirection.ForeColor = Color.Black

        Else

            lblAlarm.ForeColor = Color.Red
            lblDirection.ForeColor = Color.Red

        End If

    End Sub
End Class