using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    class Delete
    {
        public bool banderaeliminar { get; set; } = false;
        SqlConnection conexion;
        Button agregar, modificar, cancelar;
        public Delete(SqlConnection conexion, Button agregar, Button modificar, Button cancelar)
        {
            this.conexion = conexion;
            this.agregar = agregar;
            this.modificar = modificar;
            this.cancelar = cancelar;
        }

        public void Pacientes(DataRowView selectedRow)
        {
            if (banderaeliminar == false)
            {
                agregar.Visibility = Visibility.Hidden;
                modificar.Visibility = Visibility.Hidden;
                cancelar.Visibility = Visibility.Visible;
                banderaeliminar = true;

            }
            else
            {
                if(selectedRow != null)
                {
                    try
                    {
                        MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.OK)
                        {
                            string query = "DELETE FROM Pacientes WHERE id_pacientes=@id_pacientes";
                            using (SqlCommand Command = new(query, conexion))
                            {
                                Command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
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
