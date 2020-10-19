using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BE;
using BL;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for DrivingTestWindow.xaml
    /// </summary>
    public partial class DrivingTestWindow : Window
    {
        public DrivingTestWindow()
        {
            InitializeComponent();
            this.TraineesCbx.ItemsSource = BL.FactorySingletonBL.getInstance().GetTrainees();
            TraineesCbx.DisplayMemberPath = "ID";


        }

        private void TraineesCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             Address traineeAddress = (TraineesCbx.SelectedItem as Trainee).Address;
            TestersCbx.DisplayMemberPath = "Name";
            TestersCbx.Visibility = Visibility.Visible;
            TestersCbx.Items.Clear();

            BL.FactorySingletonBL.getInstance().checkTesterDistance(traineeAddress, Backgroundworker_RunWorkerCompleted);

            TestersCbx.DisplayMemberPath = "Name";
            TestersCbx.Visibility = Visibility.Visible;

        }

        private void Backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Tester result = (Tester)e.Result;
                if (result != null)
                {
                    TestersCbx.Items.Add(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrainerCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
