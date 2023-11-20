using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    class Insert
    {
        public bool banderaagregar { get; set; } = false;
        SqlConnection conexion;
        Button modificar, eliminar, cancelar;
        public Insert(SqlConnection conexion, Button modificar, Button eliminar, Button cancelar)
        {
            this.conexion = conexion;
            this.modificar = modificar;
            this.eliminar = eliminar;
            this.cancelar = cancelar;
        }

        public void Pacientes(TextBox nombre, TextBox apellido, ComboBox localidad, TextBox fecha, TextBox dni, TextBox direccion, TextBox altura, TextBox piso, TextBox departamento, TextBox correo, TextBox telefono)
        {
            if (banderaagregar == false)
            {
                modificar.Visibility = Visibility.Hidden;
                eliminar.Visibility = Visibility.Hidden;
                cancelar.Visibility = Visibility.Visible;
                banderaagregar = true;

            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Pacientes(nombre_paciente, apellido_paciente, id_localidades, fecha_nacimiento, dni, direccion_nombre, direccion_numero, direccion_piso, direccion_departamento, correo, telefono) VALUES (@nombre_paciente, @apellido_paciente, (SELECT id_localidades FROM Localidades WHERE nombre_localidad = @nombre_localidad), @fecha_nacimiento, @dni, @direccion_nombre, @direccion_numero, @direccion_piso, @direccion_departamento, @correo, @telefono)";
                        using (SqlCommand Command = new(query, conexion))
                        {
                            DateTime fechaNacimiento;
                            Command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(nombre.Text) ? DBNull.Value : nombre.Text); // ?Verdadero   :Falso
                            Command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(apellido.Text) ? DBNull.Value : apellido.Text);
                            Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(localidad.Text) ? DBNull.Value : localidad.Text);
                            Command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(fecha.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                            Command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(dni.Text) ? DBNull.Value : dni.Text);
                            Command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(direccion.Text) ? DBNull.Value : direccion.Text);
                            Command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(altura.Text) ? DBNull.Value : altura.Text);
                            Command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(piso.Text) ? DBNull.Value : piso.Text);
                            Command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(departamento.Text) ? DBNull.Value : departamento.Text);
                            Command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(correo.Text) ? DBNull.Value : correo.Text);
                            Command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono.Text) ? DBNull.Value : telefono.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }catch { }
            }
        }
    }
}
