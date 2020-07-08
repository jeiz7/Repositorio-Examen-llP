Imports System.Data.SqlClient
Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-O55QRS2\MSSQLSERVERSAM;Initial Catalog=Tutorial;Integrated Security=True")
    Public Sub abrirConexion()
        Try
            conexion.Open()
            MessageBox.Show("Se Conectó correctamente")
        Catch ex As Exception
            MessageBox.Show("No se pudo Conectar: " + ex.ToString)
            End
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function consultar()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("consultarTablita", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim tablita As New DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(tablita)
                Return tablita
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        Finally
            conexion.Close()

        End Try
    End Function
    Function Agregar(primerNombre As String, primerApellido As String, identidad As String, direccion As String, codigoCliente As String)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("agregar", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@primerNombre", primerNombre)
            cmd.Parameters.AddWithValue("@primerApellido", primerApellido)
            cmd.Parameters.AddWithValue("@identidad", identidad)
            cmd.Parameters.AddWithValue("@direccion", direccion)
            cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

    Function Actualizar(ByVal primerNombre As String, primerApellido As String, identidad As String, direccion As String, codigoCliente As String)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("actualizarTabla", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@primerNombre", primerNombre)
            cmd.Parameters.AddWithValue("@primerApellido", primerApellido)
            cmd.Parameters.AddWithValue("@identidad", identidad)
            cmd.Parameters.AddWithValue("@direccion", direccion)
            cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try
    End Function

    Function Eliminar(ByVal primerNombre As String)
    Try
        conexion.Open()
        Dim cmd As New SqlCommand("eliminar", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@primerNombre", primerNombre)
        If cmd.ExecuteNonQuery Then
            Return True
        Else
            Return False
        End If

    Catch ex As Exception
        MsgBox(ex.Message)
        Return False
    Finally
        conexion.Close()

    End Try

End Function
End Class
