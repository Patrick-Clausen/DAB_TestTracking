using System;
using System.Collections.Generic;
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
using DatabaseLibrary;

namespace CovidTrackerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SelectorSex_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)((ComboBoxItem)SexBox.SelectedItem).Content == "Female")
            {
                ((MainWindowViewModel) DataContext).CitizenUnderCreation.Sex = 'F';
            }
            else if ((string)((ComboBoxItem)SexBox.SelectedItem).Content == "Male")
            {
                ((MainWindowViewModel)DataContext).CitizenUnderCreation.Sex = 'M';
            }
            else if ((string)((ComboBoxItem)SexBox.SelectedItem).Content == "Other")
            {
                ((MainWindowViewModel)DataContext).CitizenUnderCreation.Sex = 'O';
            }
        }
    }
}
