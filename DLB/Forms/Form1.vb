Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Tecnicos.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Examenes.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Registros.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        personal.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Reporte_general.Show()
    End Sub
End Class
