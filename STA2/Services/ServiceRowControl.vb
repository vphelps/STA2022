Imports System.ServiceProcess
Imports System.Drawing
Imports System.Windows.Forms

Public Class ServiceRowControl
    Inherits UserControl

    ' ==============================
    ' Public Events (UI -> Controller)
    ' ==============================
    Public Event StartRequested(serviceName As String)
    Public Event StopRequested(serviceName As String)
    Public Event RestartRequested(serviceName As String)

    ' ==============================
    ' Backing Fields
    ' ==============================
    Private _serviceName As String
    Private _displayName As String
    Private _installed As Boolean = True
    Private _status As ServiceControllerStatus = ServiceControllerStatus.Stopped
    Private _isAdmin As Boolean = True
    Private _isBusy As Boolean = False

    ' ==============================
    ' Public Properties (State In)
    ' ==============================

    Public Property ServiceName As String
        Get
            Return _serviceName
        End Get
        Set(value As String)
            _serviceName = value
        End Set
    End Property

    Public Property DisplayName As String
        Get
            Return _displayName
        End Get
        Set(value As String)
            _displayName = value
            lblName.Text = value
        End Set
    End Property

    Public Property Installed As Boolean
        Get
            Return _installed
        End Get
        Set(value As Boolean)
            _installed = value
            UpdateVisualState()
        End Set
    End Property

    Public Property Status As ServiceControllerStatus
        Get
            Return _status
        End Get
        Set(value As ServiceControllerStatus)
            _status = value
            UpdateVisualState()
        End Set
    End Property

    Public Property IsAdmin As Boolean
        Get
            Return _isAdmin
        End Get
        Set(value As Boolean)
            _isAdmin = value
            UpdateVisualState()
        End Set
    End Property

    Public Property IsBusy As Boolean
        Get
            Return _isBusy
        End Get
        Set(value As Boolean)
            _isBusy = value
            UpdateVisualState()
        End Set
    End Property

    ' ==============================
    ' Constructor
    ' ==============================
    Public Sub New()
        InitializeComponent()
        InitializeLayout()
        UpdateVisualState()
    End Sub

    ' ==============================
    ' UI Initialization (Manual)
    ' ==============================
    Private Sub InitializeLayout()

        Me.Height = 72
        Me.Dock = DockStyle.Top
        Me.BackColor = SystemColors.Window

        picStatus.Width = 16
        picStatus.Height = 16

        btnStart.Text = "Start"
        btnStop.Text = "Stop"
        btnRestart.Text = "Restart"

        AddHandler btnStart.Click,
            Sub()
                RaiseEvent StartRequested(ServiceName)
            End Sub

        AddHandler btnStop.Click,
            Sub()
                RaiseEvent StopRequested(ServiceName)
            End Sub

        AddHandler btnRestart.Click,
            Sub()
                RaiseEvent RestartRequested(ServiceName)
            End Sub
    End Sub

    ' ==============================
    ' Core State -> UI Mapping
    ' ==============================
    Private Sub UpdateVisualState()

        ' Default all actions off
        btnStart.Enabled = False
        btnStop.Enabled = False
        btnRestart.Enabled = False

        If Not _installed Then
            lblStatus.Text = "Not Installed"
            picStatus.BackColor = Color.LightGray
            Return
        End If

        If Not _isAdmin OrElse _isBusy Then
            lblStatus.Text = "Unavailable"
            picStatus.BackColor = Color.DarkGray
            Return
        End If

        Select Case _status
            Case ServiceControllerStatus.Running
                lblStatus.Text = "Running"
                picStatus.BackColor = Color.Green
                btnStop.Enabled = True
                btnRestart.Enabled = True

            Case ServiceControllerStatus.Stopped
                lblStatus.Text = "Stopped"
                picStatus.BackColor = Color.Red
                btnStart.Enabled = True

            Case ServiceControllerStatus.StartPending
                lblStatus.Text = "Starting..."
                picStatus.BackColor = Color.Gold

            Case ServiceControllerStatus.StopPending
                lblStatus.Text = "Stopping..."
                picStatus.BackColor = Color.Gold

            Case Else
                lblStatus.Text = _status.ToString()
                picStatus.BackColor = Color.Silver
        End Select
    End Sub

End Class