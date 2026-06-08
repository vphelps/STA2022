Public Class HoverHint

    Private ReadOnly _parent As Control
    Private ReadOnly _target As Control

    Private _panel As Panel
    Private _label As Label
    Private _shadow As Panel

    Private _visible As Boolean = False
    Private _text As String

    Public Sub New(parent As Control, target As Control, text As String)
        _parent = parent
        _target = target
        _text = text

        InitializeComponents()
        WireEvents()
    End Sub

    Private Sub InitializeComponents()

        _panel = New Panel With {
            .Visible = False,
            .BackColor = Color.FromArgb(45, 45, 48),
            .Padding = New Padding(10),
            .BorderStyle = BorderStyle.FixedSingle,
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink
        }

        _label = New Label With {
            .ForeColor = Color.White,
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .MaximumSize = New Size(300, 0),
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .Text = _text
        }

        _label.Size = _label.PreferredSize
        _panel.Controls.Add(_label)

        _shadow = New Panel With {
            .Visible = False,
            .BackColor = Color.FromArgb(60, 0, 0, 0)
        }

        _parent.Controls.Add(_shadow)
        _parent.Controls.Add(_panel)

        _shadow.SendToBack()
        _panel.BringToFront()

    End Sub

    Private Sub WireEvents()
        AddHandler _target.MouseMove, AddressOf OnMouseMove
        AddHandler _target.MouseLeave, AddressOf OnMouseLeave
        AddHandler _target.MouseDown, AddressOf OnMouseDown
    End Sub

    Private _hoverId As Integer = 0

    Private Async Sub OnMouseMove(sender As Object, e As MouseEventArgs)

        ' Prevent repeated triggers
        If _visible Then Return

        _visible = True

        ' ✅ Track this hover instance (prevents async overlap bugs)
        _hoverId += 1
        Dim currentId = _hoverId

        Await Task.Delay(200)

        ' ✅ Cancel if mouse left or a newer hover started
        If Not _visible OrElse currentId <> _hoverId Then Return

        Dim screenPos = _target.PointToScreen(New Point(e.X, e.Y))
        Dim parentPos = _parent.PointToClient(screenPos)

        ' ✅ Layout BEFORE showing
        _panel.SuspendLayout()
        _panel.PerformLayout()

        ' ✅ Position calculation
        Dim offsetX As Integer = 10
        Dim offsetY As Integer = 12

        Dim x = parentPos.X + offsetX
        Dim y = parentPos.Y + offsetY

        ' ✅ Keep inside parent bounds
        x = Math.Max(5, Math.Min(x, _parent.ClientSize.Width - _panel.Width - 5))
        y = Math.Max(5, Math.Min(y, _parent.ClientSize.Height - _panel.Height - 5))

        _panel.Location = New Point(x, y)

        _shadow.Bounds = New Rectangle(
        x + 4,
        y + 4,
        _panel.Width,
        _panel.Height
    )

        _panel.ResumeLayout()

        ' ✅ SHOW LAST (prevents flicker at top-left)
        _panel.Visible = True
        _shadow.Visible = True

    End Sub
    Private Sub OnMouseDown(sender As Object, e As MouseEventArgs)
        Hide()
    End Sub

    Private Sub OnMouseLeave(sender As Object, e As EventArgs)
        Hide()
        _visible = False
    End Sub

    Private Sub Hide()
        _panel.Visible = False
        _shadow.Visible = False
    End Sub
    Public Sub SetText(text As String)
        _text = text
        _label.Text = text
        _label.Size = _label.PreferredSize
    End Sub
End Class