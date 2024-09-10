Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Tecnicos
    Dim b As Integer

    Private Sub Tecnicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarcatedraticos()
        b = -1
    End Sub
    Sub cargarcatedraticos()
        Dim cString As String
        cString = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
        Dim conn As New MySqlConnection(cString)
        Try
            conn.Open()
            Dim sQuery = "SELECT * FROM tecnicos  "
            Dim da As New MySqlDataAdapter(sQuery, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Sub Limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre, especialidad As String

        nombre = TextBox1.Text
        especialidad = TextBox2.Text

        If nombre <> "" Then
            If vbYes = MessageBox.Show("Desea Guardar Cambios", "Registrar tecnico", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                Dim cString As String
                cString = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
                Dim conn As New MySqlConnection(cString)
                Try
                    conn.Open()
                    Dim cm As New MySqlCommand
                    Dim sQuery As String
                    If b = -1 Then
                        sQuery = "INSERT INTO tecnicos ( nombre,especialidad ) VALUES(@nombre, @especialidad);"
                        Limpiar()
                    Else
                        sQuery = "UPDATE tecnicos SET  nombre=@nombre, especialidad=@especialidad WHERE id=" & b
                        b = -1
                        Limpiar()
                        Button2.Text = "Guardar"
                    End If

                    cm.Connection() = conn
                    cm.CommandText() = sQuery
                    cm.Parameters.AddWithValue("@nombre", nombre)
                    cm.Parameters.AddWithValue("@especialidad", especialidad)
                    cm.ExecuteNonQuery()
                    MessageBox.Show("Guardado con éxito")
                    cargarcatedraticos()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try
            Else
                Limpiar()
                b = -1
                Button1.Text = "Guardar"
            End If
        Else
            MessageBox.Show("Ingrese un dato Válido")
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim idTecnico As Integer
            idTecnico = DataGridView1.CurrentRow.Cells(0).Value
            Dim sQuery As String
            sQuery = $"SELECT  nombre,  especialidad  FROM tecnicos WHERE id =" & idTecnico & ";"
            Dim cString As String
            cString = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
            Dim conn As New MySqlConnection(cString)
            b = idTecnico
            Dim da As New MySqlDataAdapter(sQuery, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0)
                TextBox1.Text = fila("nombre").ToString()
                TextBox2.Text = fila("especialidad").ToString()
            Else
                MessageBox.Show("El registro no Existe")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        Button1.Text = "Modificar"
        Button2.Enabled = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If vbYes = MessageBox.Show("Desea Eliminar el registro", "Eliminar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Dim cString As String
            cString = "server=localhost;user=root;database=DLB;port=3306;password=CVO2024;"
            Dim conn As New MySqlConnection(cString)
            Try
                conn.Open()
                Dim cm As New MySqlCommand
                Dim sQuery As String
                sQuery = "DELETE FROM tecnicos WHERE id  = " & b
                Limpiar()
                cm.Connection() = conn
                cm.CommandText() = sQuery
                cm.ExecuteNonQuery()
                MessageBox.Show("Registro Eliminado")
                cargarcatedraticos()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        Else
            Limpiar()
            b = -1

        End If
    End Sub
End Class