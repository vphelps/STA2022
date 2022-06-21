Public Class ErrorHandler
    Public Shared Sub ErrorHandler(Message As String, StackTrace As String)

        FormError.errMessage = Message
        FormError.errStack = StackTrace
        FormError.ShowDialog()
        'FormMain.Close()


    End Sub
    Public Shared Sub WarningHandler(Message As String)
        FormWarn.errMessage = Message
        FormWarn.ShowDialog()

    End Sub
End Class
