Public Class semanal
    Private Sub semanal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataTable1TableAdapter.Fill(Me.DataSet2.DataTable1)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class