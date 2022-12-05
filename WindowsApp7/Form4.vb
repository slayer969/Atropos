Public Class Form4
    Public ff As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.FitWidth
    End Sub
    Private Sub Form4_close(sender As Object, e As EventArgs) Handles MyBase.Closed
        Try
            My.Computer.FileSystem.DeleteFile(ff)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Form4_scale(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        PdfDocumentViewer1.Height = Me.Height - 42
        PdfDocumentViewer1.Width = Me.Width - 17
    End Sub

    Private Sub PdfDocumentViewer1_Click(sender As Object, e As EventArgs) Handles PdfDocumentViewer1.Click

    End Sub
End Class