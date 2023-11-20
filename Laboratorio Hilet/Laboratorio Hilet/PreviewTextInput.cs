using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        private Regex OnlyText = new("[^a-zA-Z]+");
        private Regex OnlyNumbers = new("[^0-9]+");


        private void boxnombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxapellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
    }
}
