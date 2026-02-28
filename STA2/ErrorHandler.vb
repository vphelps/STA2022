Public Class ErrorHandler
    Public Shared Sub ErrorHandler(Message As String, StackTrace As String)

        FormError.errMessage = Message
        FormError.errStack = StackTrace
        FormError.ShowDialog()
        FormMain.Close()
        ' From inside the parent form

        Using dlg As New FormError()
            dlg.tbErrMessage.Text = Message
            dlg.tbErrStack.Text = StackTrace
            dlg.StartPosition = FormStartPosition.CenterParent  ' center over parent
            'dlg.ShowInTaskbar = False                           ' optional
            dlg.ShowDialog(FormMain)                                  ' <-- pass the owner!
        End Using

    End Sub
    Public Shared Sub WarningHandler(Message As String)
        'FormWarn.errMessage = Message
        'FormWarn.ShowDialog()
        Using dlg As New FormWarn()
            dlg.rtbErrMessage.Text = Message
            dlg.StartPosition = FormStartPosition.CenterParent  ' center over parent
            'dlg.ShowInTaskbar = False                           ' optional
            dlg.ShowDialog(FormMain)                                  ' <-- pass the owner!
        End Using


    End Sub
End Class
