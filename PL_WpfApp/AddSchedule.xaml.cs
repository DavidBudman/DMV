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
using System.Windows.Shapes;
using System.Windows.Threading;
using BE;

namespace PL_WpfApp
{
    /// <summary>
    /// Interaction logic for Yabadabadu.xaml
    /// </summary>
    public partial class AddSchedule : Window
    {
        private BE.Schedule m_schedule;
        Action EmptyDelegate = delegate () { };

        public Schedule Schedule
        {
            get => m_schedule;
            set
            {
                m_schedule = value;
                bindGrid(boolgrid, m_schedule);
            }
        }

        public AddSchedule()
        {
            //m_schedule = new BE.Schedule();
            //m_schedule.Data = new bool[5][]
            //         {
            //             new bool[]{ false, false, true, false, false, false},
            //             new bool[]{ false, false, false, false, false, false},
            //             new bool[]{ false, false, false, false, false, false},
            //             new bool[]{ false, false, true, false, false, false},
            //             new bool[]{ true, false, false, false, false, true}
            //         };

            InitializeComponent();
        }

        private void bindGrid(Grid thegrid, BE.Schedule schedule)
        {
            foreach (var item in thegrid.Children)
            {
                CheckBox checkbox = item as CheckBox;
                int i = Grid.GetRow(checkbox);
                int j = Grid.GetColumn(checkbox);
                checkbox.IsChecked = schedule.Data[i][j];
            }

            //refresh grid and window
            CommandManager.InvalidateRequerySuggested();
        }

        private void addSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (m_schedule != null)
            {
                int i, j;
                foreach (var item in this.boolgrid.Children)
                {
                    CheckBox checkbox = item as CheckBox;
                    i = Grid.GetRow(checkbox);
                    j = Grid.GetColumn(checkbox);
                    m_schedule.Data[i][j] = (checkbox.IsChecked == true);
                }
                DialogResult = true;
            }
        }
    }
}
