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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Views;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly UserControl _teachers = new TeachersView();
        private readonly UserControl _students = new StudentsView();

        private void ToggleButton_Teachers_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_teachers);
            ToggleButton_Teachers.IsChecked = true;
            ToggleButton_Students.IsChecked = false;
        }

        private void ToggleButton_Students_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_students);
            ToggleButton_Teachers.IsChecked = false;
            ToggleButton_Students.IsChecked = true;
        }
    }
}
