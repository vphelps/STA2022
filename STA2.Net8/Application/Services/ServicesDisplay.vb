Imports System.Drawing
Imports System.ServiceProcess

Public Module ServicesDisplay

    Private ReadOnly RunningGlyph As String = "▶"
    Private ReadOnly StoppedGlyph As String = "⏹"
    Private ReadOnly PendingGlyph As String = "⟳"
    Private ReadOnly UnknownGlyph As String = "?"

    Private Function RenderGlyph(
        glyph As String,
        Optional fontSize As Single = 16,
        Optional color As Color = Nothing
    ) As Image

        If color = Nothing Then color = Color.Black

        Dim bmp As New Bitmap(24, 24)
        Using g = Graphics.FromImage(bmp)
            g.Clear(Color.Transparent)
            g.TextRenderingHint =
                Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Using f As New Font("Segoe UI Symbol", fontSize, FontStyle.Regular)
                Using b As New SolidBrush(color)
                    g.DrawString(glyph, f, b, -2, -2)
                End Using
            End Using
        End Using

        Return bmp
    End Function

    ' --------------------------------------------------

    Public Function GetServiceStatusImage(
        status As ServiceControllerStatus
    ) As Image

        Select Case status
            Case ServiceControllerStatus.Running
                Return My.Resources.imgCheckMark96

            Case ServiceControllerStatus.Stopped
                Return My.Resources.imgCrossMark96

            Case ServiceControllerStatus.StartPending,
                 ServiceControllerStatus.StopPending,
                 ServiceControllerStatus.Paused
                Return My.Resources.imgRefresh96

            Case Else
                Return RenderGlyph(UnknownGlyph, 18, Color.Gray)
        End Select

    End Function

    Public Function GetUnavailableImage() As Image
        Return RenderGlyph("🛡", 16, Color.Gray)
    End Function

    Public Function GetNotInstalledImage() As Image
        Return My.Resources.imgUnavailableBlack64
    End Function

    Public Function MeasureMaxServiceNameWidth(
        serviceNames As IEnumerable(Of String),
        font As Font
    ) As Integer

        Dim maxWidth As Integer = 0

        For Each name In serviceNames
            Dim size = TextRenderer.MeasureText(
                name,
                font,
                New Size(Integer.MaxValue, Integer.MaxValue),
                TextFormatFlags.NoPadding
            )

            maxWidth = Math.Max(maxWidth, size.Width)
        Next

        ' Small safety margin for bold glyphs / DPI variance
        Return maxWidth + 8

    End Function

End Module