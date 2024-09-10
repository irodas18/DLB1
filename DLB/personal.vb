Public Class personal
    Private Sub personal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSet3.DataTable1' Puede moverla o quitarla según sea necesario.
        Me.DataTable1TableAdapter.Fill(Me.DataSet3.DataTable1)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class