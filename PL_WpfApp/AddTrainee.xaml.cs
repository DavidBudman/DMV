using BE;
using BL;
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
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : Window
    {
        private Trainee mytrainee;
        public AddTrainee()
        {
            InitializeComponent();
            mytrainee = new Trainee { };
            this.DataContext = mytrainee;
            gearTypeTextBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.GearType));
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IBL mybl = BL.FactorySingletonBL.getInstance();
               if( mybl.AddTrainee(mytrainee) == true)
                {
                    MessageBox.Show(mytrainee.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
