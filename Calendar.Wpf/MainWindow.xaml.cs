using Calendar.BL;
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

namespace CalendarWpf
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var dateTimeOperations = new DateTimeOperations();

            var dateString = txtDate.Text;
            var validationResult = dateTimeOperations.ValidateDate(dateString);

            //Check validation result for entered Date string
            if (!validationResult.Success)
            {
                MessageBox.Show(validationResult.Message, "Error");
                return;
            }

            var resultString = dateTimeOperations.Stringify(validationResult.Result, AplicationType.Wpf);

            txtResult.Text = resultString;
        }
    }
}
