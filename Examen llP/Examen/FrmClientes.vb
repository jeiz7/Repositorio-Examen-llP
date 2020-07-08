Imports System.Runtime.InteropServices
Public Class FrmClientes
    Dim conexion As conexion = New conexion()
    Dim tabla As New DataTable

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.abrirConexion()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim primerNombre, primerApellido, identidad, direccion, codigoCliente As String
        primerApellido = txtApellido.Text
        primerNombre = txtNombre.Text
        identidad = txtIdentidad.Text
        direccion = txtDireccion.Text
        codigoCliente = txtCodigoEmpleado.Text

        Try
            If conexion.Agregar(primerNombre, primerApellido, identidad, direccion, codigoCliente) Then
                MsgBox("Ingresado correctamente")
            Else
                MsgBox("Exito")
            End If
        Catch ex As Exception
            MsgBox("No se agrego al cliente")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim primerNombre As String
        primerNombre = txtNombre.Text

        Try
            If conexion.Eliminar(primerNombre) Then
                MsgBox("Eliminado Exitosamente")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim primerNombre, primerApellido, identidad, direccion, codigoCliente As String
        primerApellido = txtApellido.Text
        primerNombre = txtNombre.Text
        identidad = txtIdentidad.Text
        direccion = txtDireccion.Text
        codigoCliente = txtCodigoEmpleado.Text

        Try
            If conexion.Actualizar(primerNombre, primerApellido, identidad, direccion, codigoCliente) Then
                MsgBox("Actualizado correctamente")
            Else
                MsgBox("Exitoso")
            End If
        Catch ex As Exception
            MsgBox("No se actualizo al cliente")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            tabla = conexion.consultar()
            If tabla.Rows.Count <> 0 Then
                dgvRegistros.DataSource = tabla
            Else
                dgvRegistros.DataSource = Nothing

            End If
        Catch ex As Exception
            MsgBox("No se encontraron Registros")
        End Try

    End Sub

    Private Sub dgvRegistros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistros.CellContentClick
        txtNombre.Text = dgvRegistros.CurrentRow.Cells(0).Value.ToString
        txtApellido.Text = dgvRegistros.CurrentRow.Cells(1).Value.ToString
        txtIdentidad.Text = dgvRegistros.CurrentRow.Cells(2).Value.ToString
        txtDireccion.Text = dgvRegistros.CurrentRow.Cells(3).Value.ToString
        txtCodigoEmpleado.Text = dgvRegistros.CurrentRow.Cells(4).Value.ToString
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub
    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        btnMaximizar.Visible = False
        btnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        Me.WindowState = FormWindowState.Normal
        btnRestaurar.Visible = False
        btnMaximizar.Visible = True
    End Sub
    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


End Class
