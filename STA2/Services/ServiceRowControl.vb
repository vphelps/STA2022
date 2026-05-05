Imports System.ServiceProcess

Public Class ServiceRowControl

    ' -------------------------------------------------
    ' Public state (set by FormMain / ServiceManager)
    ' -------------------------------------------------

    Public Property ServiceName As String
    Public Property DisplayName As String

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
    Private _installed As Boolean = True

    ' True when service is not installed and may be hidden
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
    Private _isAdmin As Boolean = False

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
    Private _isBusy As Boolean = False

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
    Private _status As ServiceControllerStatus =
        ServiceControllerStatus.Stopped

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

        lblName.Text = DisplayName

        ' Automatically scale icons to fit
        picStatus.SizeMode = PictureBoxSizeMode.Zoom

        ' Icon-only buttons
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

        ' Automatically scale 96x96 icons to button size
        btnStart.Image =
        ResizeImageToFit(
            My.Resources.imgGreenPlay96,
            btnStart.ClientSize)

        btnStop.Image =
        ResizeImageToFit(
            My.Resources.imgRedStop96,
            btnStop.ClientSize)

        btnRestart.Image =
        ResizeImageToFit(
            My.Resources.imgRefresh96,
            btnRestart.ClientSize)

        UpdateVisualState()

    End Sub

    ' -------------------------------------------------
    ' Button click handlers (raise intent only)
    ' -------------------------------------------------

    Private Sub btnStart_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStart.Click

        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent StartRequested(ServiceName)
        End If

    End Sub

    Private Sub btnStop_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStop.Click

        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent StopRequested(ServiceName)
        End If

    End Sub

    Private Sub btnRestart_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRestart.Click

        If Installed AndAlso IsAdmin AndAlso Not IsBusy Then
            RaiseEvent RestartRequested(ServiceName)
        End If

    End Sub

    ' -------------------------------------------------
    ' Visual state logic (ONLY place UI is updated)
    ' -------------------------------------------------

    Private Sub UpdateVisualState()

        ' ---- Service not installed ----
        If Not Installed Then
            lblStatus.Text = "Not Installed"
            picStatus.Image = ServicesDisplay.GetNotInstalledImage()

            btnStart.Enabled = False
            btnStop.Enabled = False
            btnRestart.Enabled = False
            Return
        End If

        ' ---- Busy / in-progress ----
        If IsBusy Then
            lblStatus.Text = "Working..."
            picStatus.Image =
                ServicesDisplay.GetServiceStatusImage(Status)

            btnStart.Enabled = False
            btnStop.Enabled = False
            btnRestart.Enabled = False
            Return
        End If

        ' ---- Admin privileges required ----
        If Not IsAdmin Then
            lblStatus.Text = "Requires Administrator"
            picStatus.Image =
                ServicesDisplay.GetServiceStatusImage(Status)

            btnStart.Enabled = False
            btnStop.Enabled = False
            btnRestart.Enabled = False
            Return
        End If

        ' ---- Normal installed / idle states ----
        picStatus.Image =
            ServicesDisplay.GetServiceStatusImage(Status)

        Select Case Status

            Case ServiceControllerStatus.Running
                lblStatus.Text = "Running"
                btnStart.Enabled = False
                btnStop.Enabled = True
                btnRestart.Enabled = True

            Case ServiceControllerStatus.Stopped
                lblStatus.Text = "Stopped"
                btnStart.Enabled = True
                btnStop.Enabled = False
                btnRestart.Enabled = False

            Case ServiceControllerStatus.StartPending
                lblStatus.Text = "Starting..."
                btnStart.Enabled = False
                btnStop.Enabled = False
                btnRestart.Enabled = False

            Case ServiceControllerStatus.StopPending
                lblStatus.Text = "Stopping..."
                btnStart.Enabled = False
                btnStop.Enabled = False
                btnRestart.Enabled = False

            Case Else
                lblStatus.Text = Status.ToString()
                btnStart.Enabled = False
                btnStop.Enabled = False
                btnRestart.Enabled = False

        End Select

    End Sub
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