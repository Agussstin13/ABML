using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace T.P_sqlserver
{
    static class CargarComboBox
    {
        static SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-QT2ACQ6\\AGUSSSTIN;user id=sa;password=1234;Initial Catalog=TP_FINAL_HOSPITAL;Integrated Security=false");
        static public void CargarCiudades(ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_localidad FROM Localidades";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_localidad"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarEspecialidades(ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_especialidad FROM Especialidades";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_especialidad"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarMuestra(ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_muestra FROM Tipos_de_Muestras";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_muestra"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarServicios (ComboBox combobox) {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_servicio FROM Servicios";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader()) {
                while (reader.Read()) {
                    combobox.Items.Add(reader ["nombre_servicio"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarCategorias (ComboBox combobox) {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_categoria FROM Categoria";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader()) {
                while (reader.Read()) {
                    combobox.Items.Add(reader ["nombre_categoria"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarPracticas(ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_practica FROM Practicas";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_practica"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarPacientes(ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_paciente, apellido_paciente, dni, id_pacientes FROM Pacientes";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_paciente"].ToString() + " " + reader["apellido_paciente"].ToString() + " " + reader["dni"].ToString());
                    id.Items.Add(reader["id_pacientes"]);
                }
                conexion.Close();
            }
        }
        static public void CargarProfesionales(ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_profesional, apellido_profesional, id_profesionales FROM Profesionales";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_profesional"].ToString() + " " + reader["apellido_profesional"].ToString());
                    id.Items.Add(reader["id_profesionales"]);
                }
                conexion.Close();
            }
        }
    }
}
