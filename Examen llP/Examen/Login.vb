Public Class Login
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Usuario As String
        Dim password As Integer

        Usuario = txtPassword.Text
        password = txtPassword.Text
        If (Usuario = "ADMIN") And password = "2020") Then
            FrmClientes.Show()
        Else
            MsgBox("Usuario o Password Incorrectos, Verifique")
        End If
    End Sub
End Class