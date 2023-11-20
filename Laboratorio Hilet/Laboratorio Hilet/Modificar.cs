using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using T.P_sqlserver;

namespace Laboratorio_Hilet
{
    class Update
    {
        public bool banderamodificar { get; set; } = false;
        SqlConnection conexion;
        Button Agregar, eliminar, cancelar;

        public Update(SqlConnection conexion, Button Agregar, Button eliminar, Button cancelar)
        {
            this.conexion = conexion;
            this.Agregar = Agregar;
            this.eliminar = eliminar;
            this.cancelar = cancelar;
        }

        public void Pacientes(DataGrid DGPacientes, TextBox nombre, TextBox apellido, ComboBox localidad, TextBox fecha, TextBox dni, TextBox direccion, TextBox altura, TextBox piso, TextBox departamento, TextBox correo, TextBox telefono)
        {
            if (banderamodificar == false)
            {
                Agregar.Visibility = Visibility.Hidden;
                eliminar.Visibility = Visibility.Hidden;
                cancelar.Visibility = Visibility.Visible;
                banderamodificar = true;
            }
            else
            {
                DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
                if (selectedRow != null)
                {
                    try
                    {
                        MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (result == MessageBoxResult.OK)
                        {
                            DateTime fechaNacimiento;
                            string query = "UPDATE Pacientes SET nombre_paciente=@nombre_paciente, apellido_paciente=@apellido_paciente, id_localidades=@id_localidades, fecha_nacimiento=@fecha_nacimiento, dni=@dni," +
                            " direccion_nombre=@direccion_nombre, direccion_numero=@direccion_numero, direccion_piso=@direccion_piso, direccion_departamento=@direccion_departamento, correo=@correo, telefono=@telefono WHERE id_pacientes=@id_pacientes;";
                            using (SqlCommand command = new SqlCommand(query, conexion))
                            {
                                command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(nombre.Text) ? DBNull.Value : nombre.Text);
                                command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(apellido.Text) ? DBNull.Value : apellido.Text);
                                command.Parameters.AddWithValue("@id_localidades", localidad.SelectedIndex > 0 ? localidad.SelectedIndex : "0");
                                command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(fecha.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(dni.Text) ? DBNull.Value : dni.Text);
                                command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(direccion.Text) ? DBNull.Value : direccion.Text);
                                command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(altura.Text) ? DBNull.Value : altura.Text);
                                command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(piso.Text) ? DBNull.Value : piso.Text);
                                command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(departamento.Text) ? DBNull.Value : departamento.Text);
                                command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(correo.Text) ? DBNull.Value : correo.Text);
                                command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono.Text) ? DBNull.Value : telefono.Text);
                                command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                                using (SqlDataAdapter dataAdapter = new(command))
                                using (DataTable dt = new DataTable())
                                {
                                    dataAdapter.Fill(dt);
                                }
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
        }
    }
}
