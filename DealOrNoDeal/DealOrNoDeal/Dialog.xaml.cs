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

namespace DealOrNoDeal
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {

        public Dialog(int value)
        {
            
            InitializeComponent();

            textBlock.Text = "Möchten Sie das Angebot von " + value + " annehmen";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.HasAccepted = false;
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.HasAccepted = true;
            Close();
        }
    }
}
