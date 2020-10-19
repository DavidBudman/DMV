using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL myBl; 
        public MainWindow()
        {
            InitializeComponent();
            myBl = BL.FactorySingletonBL.getInstance();
          
        }

        private void ShowPersons_Click(object sender, RoutedEventArgs e)
        {
             datagrid.ItemsSource = new ObservableCollection<Person>(myBl.GetAllPersons());
        }

        private void addTraineeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTrainee wnd = new AddTrainee();
            wnd.ShowDialog();
        }

        private void AddTesterBtn_Click(object sender, RoutedEventArgs e)
        {
            Tester tester = new Tester();
            AddSchedule addSchedule = new AddSchedule();
            addSchedule.Schedule = new BE.Schedule
            {
                Data = new bool[5][]
                     {
                         new bool[]{ false, false, true, false, false, false},
                         new bool[]{ false, false, false, false, false, false},
                         new bool[]{ false, false, false, false, false, false},
                         new bool[]{ false, false, true, false, false, false},
                         new bool[]{ true, false, false, false, false, true}
                     }
            };

            addSchedule.ShowDialog();

            if (addSchedule.DialogResult.HasValue && addSchedule.DialogResult.Value == true)
            {
                MessageBox.Show(addSchedule.Schedule.ToString());
                tester.Luz = addSchedule.Schedule;
                BL.FactorySingletonBL.getInstance().AddTester(tester);
            }

        }

        private void Distance_Click(object sender, RoutedEventArgs e)
        {
            new Distance().Show();
        }

        private void ViewTestersGroup_Click(object sender, RoutedEventArgs e)
        {
            new ViewTesters().Show();
        }

        private void DrivingTestBtn_Click(object sender, RoutedEventArgs e)
        {
            new DrivingTestWindow().Show();
        }
    }
}
