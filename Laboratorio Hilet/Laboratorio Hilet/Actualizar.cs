using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Reflection.Emit;

namespace T.P_sqlserver
{
    static class Actualizar
    {
        static SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-QT2ACQ6\\AGUSSSTIN;user id=sa;password=1234;Initial Catalog=TP_FINAL_HOSPITAL;Integrated Security=false");


        static public void Pacientes(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT nombre_paciente AS Nombre, apellido_paciente AS Apellido, nombre_localidad AS Ciudad, CONVERT(NVARCHAR(10),fecha_nacimiento, 103) AS Nacimiento, dni AS DNI, direccion_nombre AS Direccion, direccion_numero AS Altura, direccion_piso AS Piso, direccion_departamento AS departamento, correo AS Correo, telefono AS Telefono, id_pacientes AS ID FROM Pacientes INNER JOIN Localidades ON Pacientes.id_localidades = Localidades.id_localidades";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Ingresos(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT pa.nombre_paciente AS Nombre_Paciente, pa.apellido_paciente AS Apellido_Paciente, pa.dni AS DNI, pr.nombre_profesional AS Nombre_Profesional" +
                    " ,pr.apellido_profesional AS Apellido_Profesional,CONVERT(NVARCHAR(10),I.fecha_ingreso, 103) AS Fecha_Ingreso,CONVERT(NVARCHAR(10),I.fecha_retiro, 103) AS Fecha_Retiro, id_ingresos AS ID FROM Pacientes AS pa INNER JOIN Ingresos" +
                    " AS I ON pa.id_pacientes = I.id_pacientes INNER JOIN Profesionales as pr ON I.id_profesionales = pr.id_profesionales ORDER BY pa.dni;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Localidades(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT nombre_Localidad AS Ciudad, codigo_postal AS Codigo_Postal, id_localidades AS ID FROM Localidades";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void PersonalMedico(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT pro.nombre_profesional AS Nombre, pro.apellido_profesional AS Apellido, s.nombre_servicio AS Servicio, pro.matricula_profesional AS Matricula, id_profesionales AS ID FROM Profesionales AS pro INNER JOIN Servicios AS s ON pro.id_servicios= s.id_servicios ORDER BY pro.id_profesionales;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void PersonalLaboratorio(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT pe.nombre_personal AS Nombre, pe.apellido_personal AS Apellido, c.nombre_categoria AS Categoria, e.nombre_especialidad AS Especialidad, pe.matricula_personal AS Matricula, id_personal AS ID FROM Personal_Laboratorio AS pe INNER JOIN Categoria AS c ON pe.id_categorias = c.id_categorias INNER JOIN Especialidades AS E ON pe.id_especialidades = e.id_especialidades ORDER BY Matricula;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Categorias(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT c.nombre_categoria AS Categoria, id_categorias AS ID FROM Categoria AS c ORDER BY c.id_categorias;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Especialidades(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT DISTINCT e.nombre_especialidad AS Especialidad, jefes.nombre_categoria AS Categoria, jefes.nombre_personal AS Nombre, jefes.apellido_personal AS Apellido, jefes.matricula_personal AS Matricula, e.id_especialidades AS ID FROM " +
                    "Especialidades AS e LEFT JOIN (SELECT nombre_personal, apellido_personal, matricula_personal, jefes.nombre_categoria, pe.id_categorias, pe.id_especialidades FROM Personal_Laboratorio AS pe INNER JOIN (SELECT id_categorias, nombre_categoria FROM Categoria WHERE nombre_categoria = 'Jefe') AS jefes ON jefes.id_categorias = pe.id_categorias) AS jefes ON e.id_especialidades = jefes.id_especialidades ORDER BY e.nombre_especialidad;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Practicas(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT nombre_practica AS Practica, nombre_especialidad AS Especialidad, nombre_muestra AS Muestra, tiempo_demora_practica AS Demora, id_practicas AS ID FROM Practicas INNER JOIN Especialidades ON Practicas.id_especialidades = Especialidades.id_especialidades INNER JOIN Tipos_de_Muestras ON Practicas.id_muestras = Tipos_de_Muestras.id_muestras";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /* static public void PersonalEspecialidad(DataGrid dataGrid)
         {
             try
             {
                 string query = "SELECT pe.nombre_personal AS Nombre, pe.apellido_personal AS Apellido, e.nombre_especialidad AS Especialidad, pe.matricula_personal AS Matricula FROM Personal_Laboratorio AS pe LEFT JOIN Especialidades AS e ON pe.id_especialidades = e.id_especialidades ORDER BY Matricula;";
                 using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                 using (DataTable dt = new DataTable())
                 {
                     dataAdapter.Fill(dt);
                     dataGrid.ItemsSource = dt.DefaultView;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

         static public void PracticasEspecialidad(DataGrid dataGrid)
         {
             try
             {
                 string query = "SELECT pr.nombre_practica AS Practica, m.nombre_muestra AS Muestra, e.nombre_especialidad AS Especialidad, pr.tiempo_demora_practica AS Demora FROM Practicas as pr INNER JOIN Especialidades AS e ON pr.id_especialidades = e.id_especialidades INNER JOIN Tipos_de_Muestras AS m ON pr.id_muestras= m.id_muestras ORDER BY pr.nombre_practica;";
                 using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                 using (DataTable dt = new DataTable())
                 {
                     dataAdapter.Fill(dt);
                     dataGrid.ItemsSource = dt.DefaultView;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }*/
        static public void PracticasIngreso(DataGrid dataGrid)
        {
            try
            {
                string query = "SELECT pxi.resultado AS Resultado, pra.nombre_practica AS Practica, m.nombre_muestra AS Muestra, e.nombre_especialidad AS Especialidad, pa.nombre_paciente AS Nombre, pa.apellido_paciente AS Apellido, pa.dni AS DNI, CONVERT(NVARCHAR(10),i.fecha_ingreso, 103) AS Fecha_Ingreso, CONVERT(NVARCHAR(10),i.fecha_retiro, 103) AS Fecha_Retiro, pxi.id_practicasxingreso AS ID FROM Pacientes AS pa INNER JOIN Ingresos AS i ON pa.id_pacientes = i.id_pacientes INNER JOIN PracticasxIngreso AS pxi ON i.id_ingresos = pxi.id_ingresos INNER JOIN Practicas AS pra ON pxi.id_practicas = pra.id_practicas INNER JOIN Tipos_de_Muestras AS m ON pra.id_muestras = m.id_muestras INNER JOIN Especialidades AS e ON pra.id_especialidades=e.id_especialidades ORDER BY pa.dni;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public void Todo(DataGrid dataGrid, DataGrid dataGrid2, DataGrid dataGrid3, DataGrid dataGrid4, DataGrid dataGrid5, DataGrid dataGrid6, DataGrid dataGrid7, DataGrid dataGrid8, DataGrid dataGrid9) {
            try
            {
                Pacientes(dataGrid);
                Ingresos(dataGrid2);
                Localidades(dataGrid3);
                PersonalMedico(dataGrid4);
                PersonalLaboratorio(dataGrid5);
                Categorias(dataGrid6);
                Especialidades(dataGrid7);
                Practicas(dataGrid8);
                PracticasIngreso(dataGrid9);
                //PersonalEspecialidad(dataGrid9);
                //PracticasEspecialidad(dataGrid10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
