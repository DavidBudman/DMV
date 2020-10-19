using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        //bool[][] mat = new bool[5][]
        //    {
        //        new bool[6], new bool[6],new bool[6],new bool[6],new bool[6],
        //    };
        Schedule schedule = new Schedule();
        public AddTester()
        {
            InitializeComponent();
            this.luzDataGrid.ItemsSource = schedule.Data;
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
