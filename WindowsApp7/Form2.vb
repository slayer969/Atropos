Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class Form2
    Public strSQL As String
    Public cmd As New MySqlCommand
    Public Dreader As MySqlDataReader
    Public SConnection As New MySqlConnection
    Dim activation As New DataSet
    Dim da As New MySqlDataAdapter
    Private Sub TextBox2_TextChanged(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 10 Or Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()

    End Sub
End Class