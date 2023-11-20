using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using T.P_sqlserver;

namespace Laboratorio_Hilet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-QT2ACQ6\\AGUSSSTIN;user id=sa;password=1234;Initial Catalog=TP_FINAL_HOSPITAL;Integrated Security=false");
        Insert Agregar;
        Update Modificar;
        Delete Eliminar;
        int selectedview;
        public MainWindow()
        {
            InitializeComponent();
            Agregar = new(conexion, btnModificar, btnEliminar, btnCancelar);
            Modificar = new(conexion, btnAgregar, btnEliminar, btnCancelar);
            Eliminar = new(conexion, btnAgregar, btnModificar, btnCancelar);
        }

        private void btnpacientes_Click(object sender, RoutedEventArgs e)
        {
            Actualizar.Pacientes(DGPacientes);
            CargarComboBox.CargarCiudades(cmboxciudad);
            SelectView(GPacientes, GIngresos, GLocalidades, GMedicos, GLaboratorio, GCategorias, GEspecialidades, GPracticas, GPracticasIngresos);
            selectedview = 1;
        }

        private void btningresos_Click(object sender, RoutedEventArgs e)
        {
            Actualizar.Ingresos(DGIngresos);
            SelectView(GIngresos, GPacientes, GLocalidades, GMedicos, GLaboratorio, GCategorias, GEspecialidades, GPracticas, GPracticasIngresos);
            selectedview = 2;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            switch(selectedview) {
                case 1:
                    Agregar.Pacientes(boxnombre, boxapellido, cmboxciudad, boxnacimiento, boxdni, boxdireccion, boxaltura, boxpiso, boxdepartamento, boxcorreo, boxtelefono);
                    Actualizar.Pacientes(DGPacientes);
                    break;
            }
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedview)
            {
                case 1:
                    Modificar.Pacientes(DGPacientes, boxnombre, boxapellido, cmboxciudad, boxnacimiento, boxdni, boxdireccion, boxaltura, boxpiso, boxdepartamento, boxcorreo, boxtelefono);
                    Actualizar.Pacientes(DGPacientes);
                    LimpiarPacientes();
                    break;
            }
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedview)
            {
                case 1:
                    DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
                    Eliminar.Pacientes(selectedRow);
                    Actualizar.Pacientes(DGPacientes);
                    break;
            }

        }

        private void DGPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGPacientes.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
                    boxnombre.Text = selectedRow.Row[0].ToString();
                    boxapellido.Text = selectedRow.Row[1].ToString();
                    cmboxciudad.SelectedItem = selectedRow.Row[2].ToString();
                    boxnacimiento.Text = selectedRow.Row[3].ToString();
                    boxdni.Text = selectedRow.Row[4].ToString();
                    boxdireccion.Text = selectedRow.Row[5].ToString();
                    boxaltura.Text = selectedRow.Row[6].ToString();
                    boxpiso.Text = selectedRow.Row[7].ToString();
                    boxdepartamento.Text = selectedRow.Row[8].ToString();
                    boxcorreo.Text = selectedRow.Row[9].ToString();
                    boxtelefono.Text = selectedRow.Row[10].ToString();
                }
            }
            catch { }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Agregar.banderaagregar = false;
            Modificar.banderamodificar = false;
            Eliminar.banderaeliminar = false;
            btnAgregar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
        }

        private void DGPacientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
