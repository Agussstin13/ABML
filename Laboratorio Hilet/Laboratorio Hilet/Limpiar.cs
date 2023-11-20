using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        public void LimpiarPacientes()
        {
            boxnombre.Text = "";
            boxapellido.Text = "";
            cmboxciudad.SelectedIndex = -1;
            boxnacimiento.Text = "";
            boxdni.Text = "";
            boxdireccion.Text = "";
            boxaltura.Text = "";
            boxpiso.Text = "";
            boxdepartamento.Text = "";
            boxcorreo.Text = "";
            boxtelefono.Text = "";
        }
        public void Limpiar(ComboBox cb1)
        {
            cb1.SelectedIndex = 0;
        }
        public void Limpiar(ComboBox cb1, ComboBox cb2)
        {
            cb1.SelectedIndex = 0;
            cb2.SelectedIndex = 0;
        }
    }
}
