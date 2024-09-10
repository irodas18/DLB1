Imports MySql.Data.MySqlClient

Public Class Registros
    Dim idTecnico As Integer

    Private Sub Registros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss"
        CargarTecnico()
    End Sub
    Private Sub CargarTecnico()
        Dim cString As String = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
        Dim conn As New MySqlConnection(cString)
        Try
            conn.Open()
            Dim sQuery = "SELECT id, nombre,especialidad  FROM tecnicos "
            Dim da As New MySqlDataAdapter(sQuery, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            ComboBox1.Items.Clear()
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    ComboBox1.Items.Add(fila("id").ToString() & "- " & fila("nombre").ToString() & " " & fila("especialidad").ToString())
                Next
            Else
                MessageBox.Show("No hay proyecciones disponibles.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cString As String = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
        Dim conn As New MySqlConnection(cString)

        Try
            conn.Open()
            Dim cm As New MySqlCommand
            Dim paciente As String
            Dim tipo As String
            Dim precio As String
            paciente = TextBox1.Text
            precio = TextBox2.Text
            tipo = TextBox3.Text

            Dim squery As String
            squery = "INSERT INTO registros (paciente,tecnico_id , precio,tipo,fecha ) VALUES (@paciente,@tecnico_id, @precio, @tipo, @fecha )"
            cm.Connection = conn
            cm.CommandText = squery
            With cm.Parameters
                .AddWithValue("@tecnico_id", idTecnico)
                .AddWithValue("@precio", precio)
                .AddWithValue("@fecha", DateTimePicker1.Value)
                .AddWithValue("@paciente", paciente)
                .AddWithValue("@tipo", tipo)
            End With
            cm.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Guardado con éxito")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        Limpiar()
    End Sub
    Sub Limpiar()
        ComboBox1.SelectedIndex = -1
        TextBox2.Clear()
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox1.Focus()
        DateTimePicker1.Value = Now
        idTecnico = 0

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reporte_1.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim separador() As String
        Dim v As String

        If ComboBox1.SelectedIndex > -1 Then
            v = ComboBox1.SelectedItem.ToString()
            separador = v.Split("-")
            idTecnico = separador(0)
        End If
    End Sub
End Class