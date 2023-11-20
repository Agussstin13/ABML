using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        public void SelectView(Grid dataGrid1, Grid dataGrid2, Grid dataGrid3, Grid dataGrid4, Grid dataGrid5, Grid dataGrid6, Grid dataGrid7, Grid dataGrid8, Grid dataGrid9)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;
            dataGrid3.Visibility = Visibility.Hidden;
            dataGrid4.Visibility = Visibility.Hidden;
            dataGrid5.Visibility = Visibility.Hidden;
            dataGrid6.Visibility = Visibility.Hidden;
            dataGrid7.Visibility = Visibility.Hidden;
            dataGrid8.Visibility = Visibility.Hidden;
            dataGrid9.Visibility = Visibility.Hidden;
        }
    }
}
