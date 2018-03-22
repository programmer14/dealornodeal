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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DealOrNoDeal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<int> list;
        private int round;
        private int casevalue;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            round = 1;
            casevalue = 0;
            list = new List<int>() { 1, 5, 10, 50, 100, 200, 350, 500, 1000, 1500, 2500, 4000, 10000, 25000, 50000, 100000, 250000, 750000, 1500000, 3000000 };
            MeganImage.Visibility = Visibility.Hidden;
            EndKImage.Visibility = Visibility.Hidden;
            PlayAgBtn.Visibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (round < 20)
            {
                var rnd = new Random();
                list = list.OrderBy(a => rnd.Next()).ToList();
                var zahl = list.FirstOrDefault();
                list.Remove(zahl);
                if (round == 1)
                {
                    //Save Choosen Case
                    casevalue = zahl;
                    //Change Image
                    var bild = (Image)sender;
                    bild.Source = new BitmapImage(new Uri(@"kofferChoosen.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    Label lb = (Label)FindName("Label_" + zahl);
                    lb.Foreground = Brushes.Red;
                    var bild = (Image)sender;
                    bild.Visibility = Visibility.Hidden;
                }

                round++;

                       

            }
            else
            {
                MeganImage.Visibility = Visibility.Visible;
                EndKImage.Visibility = Visibility.Visible;
                LabelEnd.Content = list.FirstOrDefault();
                gridMain.ShowGridLines = false;
                PlayAgBtn.Visibility = Visibility.Visible;
                Image1.Visibility = Visibility.Hidden;
                Image2.Visibility = Visibility.Hidden;
                Image3.Visibility = Visibility.Hidden;
                Image4.Visibility = Visibility.Hidden;
                Image5.Visibility = Visibility.Hidden;
                Image6.Visibility = Visibility.Hidden;
                Image7.Visibility = Visibility.Hidden;
                Image8.Visibility = Visibility.Hidden;
                Image9.Visibility = Visibility.Hidden;
                Image10.Visibility = Visibility.Hidden;
                Image11.Visibility = Visibility.Hidden;
                Image12.Visibility = Visibility.Hidden;
                Image13.Visibility = Visibility.Hidden;
                Image14.Visibility = Visibility.Hidden;
                Image15.Visibility = Visibility.Hidden;
                Image16.Visibility = Visibility.Hidden;
                Image17.Visibility = Visibility.Hidden;
                Image18.Visibility = Visibility.Hidden;
                Image19.Visibility = Visibility.Hidden;

                Image20.Visibility = Visibility.Hidden;
            }

        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void PlayAgBtn_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
