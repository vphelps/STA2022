Imports System.ServiceProcess
Imports System.Drawing

Public Class ServiceRowControl

    ' -------------------------------------------------
    ' Backing fields
    ' -------------------------------------------------
    Private _serviceName As String
    Private _displayName As String
    Private _installed As Boolean = True
    Private _isAdmin As Boolean = False
    Private _isBusy As Boolean = False
    Private _status As ServiceControllerStatus =
        ServiceControllerStatus.Stopped

    ' -------------------------------------------------
    ' Public state (set by FormMain / ServiceManager)
    ' -------------------------------------------------

    Public Property ServiceName As String
        Get
            Return _serviceName
        End Get
        Set(value As String)
            _serviceName = value

            ' ✅ Do NOT update lblName here
            ' ServiceName is technical, not UI-facing
        End Set
    End Property

    Public Property DisplayName As String
        Get
            Return _displayName
        End Get
        Set(value As String)
            _displayName = value

            ' ✅ DisplayName is the ONLY source for lblName
            If Not String.IsNullOrWhiteSpace(value) Then
                lblName.Text = value
            Else
                ' Fallback safety (should rarely happen)
                lblName.Text = _serviceName
            End If
        End Set
    End Property

    ' True when the service exists on the machine
    Public Property Installed As Boolean
        Get
            Return _installed
        End Get
        Set(value As Boolean)
            _installed = value
            UpdateVisualState()
        End Set
    End Property

    ' True when service is hidden (e.g. not installed)
    Public Property IsHidden As Boolean = False

    ' Whether the app is running with admin privileges
    Public Property IsAdmin As Boolean
        Get
            Return _isAdmin
        End Get
        Set(value As Boolean)
            _isAdmin = value
            UpdateVisualState()
        End Set
    End Property

    ' True while a start/stop/restart operation is running
    Public Property IsBusy As Boolean
        Get
            Return _isBusy
        End Get
        Set(value As Boolean)
            _isBusy = value
            UpdateVisualState()
        End Set
    End Property

    ' Current service status
    Public Property Status As ServiceControllerStatus
        Get
            Return _status
        End Get
        Set(value As ServiceControllerStatus)
            _status = value
            UpdateVisualState()
        End Set
    End Property

    ' -------------------------------------------------
    ' Events (intent only – handled by FormMain)
    ' -------------------------------------------------

    Public Event StartRequested(serviceName As String)
    Public Event StopRequested(serviceName As String)
    Public Event RestartRequested(serviceName As String)

    ' -------------------------------------------------
    ' Control lifecycle
    ' -------------------------------------------------

    Private Sub ServiceRowControl_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ' --- Status icon ---
        picStatus.SizeMode = PictureBoxSizeMode.Zoom

        ' --- Icon-only buttons ---
        btnStart.Text = ""
        btnStop.Text = ""
        btnRestart.Text = ""

        btnStart.AutoSize = False
        btnStop.AutoSize = False
        btnRestart.AutoSize = False

        btnStart.ImageAlign = ContentAlignment.MiddleCenter
        btnStop.ImageAlign = ContentAlignment.MiddleCenter
        btnRestart.ImageAlign = ContentAlignment.MiddleCenter

        btnStart.FlatStyle = FlatStyle.Standard
        btnStop.FlatStyle = FlatStyle.Standard
        btnRestart.FlatStyle = FlatStyle.Standard

        btnStart.UseVisualStyleBackColor = True
        btnStop.UseVisualStyleBackColor = True
        btnRestart.UseVisualStyleBackColor = True

        ' --- Resize 96×96 icons to button size ---
        ' Use shared UIHelpers loader so images are reusable across modules.
        Dim startImg = UIHelpers.LoadImageFromAppFolder("imgGreenPlay96.png")
        If startImg IsNot Nothing Then
            btnStart.Image = ResizeImageToFit(startImg, btnStart.ClientSize)
            startImg.Dispose()
        Else
            btnStart.Image = Nothing
        End If

        Dim stopImg = UIHelpers.LoadImageFromAppFolder("imgRedStop96.png")
        If stopImg IsNot Nothing Then
            btnStop.Image = ResizeImageToFit(stopImg, btnStop.ClientSize)
            stopImg.Dispose()
        Else
            btnStop.Image = Nothing
        End If

        Dim refreshImg = UIHelpers.LoadImageFromAppFolder("imgRefresh96.png")
        If refreshImg IsNot Nothing Then
            btnRestart.Image = ResizeImageToFit(refreshImg, btnRestart.ClientSize)
            refreshImg.Dispose()
        Else
            btnRestart.Image = Nothing
        End If

        UpdateVisualState()

    End Sub

    ' -------------------------------------------------
    ' Button click handlers (intent only)
    ' -------------------------------------------------

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent StartRequested(ServiceName)
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent StopRequested(ServiceName)
        End If
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent RestartRequested(ServiceName)
        End If
    End Sub

    ' -------------------------------------------------
    ' Visual state logic (ONLY UI update point)
    ' -------------------------------------------------

    Private Sub UpdateVisualState()

        ' --- Service not installed ---
        If Not Installed Then
            lblStatus.Text = "Not Installed"
            picStatus.Image = ServicesDisplay.GetNotInstalledImage()

            btnStart.Enabled = False
            btnStop.Enabled = False
            btnRestart.Enabled = False
            Return
        End If

        ' --- Busy / in-progress ---
        If IsBusy Then
            lblStatus.Text = "Working..."
            picStatus.Image =
                ServicesDisplay.GetServiceStatusImage(Status)

            btnStart.Enabled = False
            btnStop.Enabled = False
            btnRestart.Enabled = False
            Return
        End If

        ' --- Show actual service status ---
        picStatus.Image =
            ServicesDisplay.GetServiceStatusImage(Status)

        Select Case Status
            Case ServiceControllerStatus.Running
                lblStatus.Text = "Running"

            Case ServiceControllerStatus.Stopped
                lblStatus.Text = "Stopped"

            Case ServiceControllerStatus.StartPending
                lblStatus.Text = "Starting..."

            Case ServiceControllerStatus.StopPending
                lblStatus.Text = "Stopping..."

            Case Else
                lblStatus.Text = Status.ToString()
        End Select

        ' --- Admin gate ONLY controls buttons ---
        Dim allowActions As Boolean = IsAdmin

        btnStart.Enabled =
            allowActions AndAlso Status = ServiceControllerStatus.Stopped

        btnStop.Enabled =
            allowActions AndAlso Status = ServiceControllerStatus.Running

        btnRestart.Enabled =
            allowActions AndAlso Status = ServiceControllerStatus.Running

        If Not IsAdmin Then
            lblStatus.Text &= " (Admin required)"
        End If

    End Sub

    ' -------------------------------------------------
    ' Image scaling helper
    ' -------------------------------------------------

    Private Function ResizeImageToFit(
        source As Image,
        targetSize As Size
    ) As Image

        Dim scale As Single = Math.Min(
            targetSize.Width / source.Width,
            targetSize.Height / source.Height)

        Dim width As Integer = CInt(source.Width * scale)
        Dim height As Integer = CInt(source.Height * scale)

        Dim bmp As New Bitmap(width, height)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Transparent)
            g.InterpolationMode =
                Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(source, 0, 0, width, height)
        End Using

        Return bmp

    End Function

End Class