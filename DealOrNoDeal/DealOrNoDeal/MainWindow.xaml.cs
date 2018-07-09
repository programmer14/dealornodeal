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
        private int endValue = 0;
        private List<int> list;
        private int round;
        private int casevalue;
        public static Boolean HasAccepted = false;

        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.AlreadySaved = false;
            Properties.Settings.Default.Save();
            DataContext = this;
            round = 1;
            casevalue = 0;
            list = new List<int>() { 1, 5, 10, 50, 100, 200, 350, 500, 1000, 1500, 2500, 4000, 10000, 25000, 50000, 100000, 250000, 750000, 1500000, 3000000 };
            MeganImage.Visibility = Visibility.Hidden;
            EndKImage.Visibility = Visibility.Hidden;
            PlayAgBtn.Visibility = Visibility.Hidden;
            ShowScoreBtn.Visibility = Visibility.Hidden;
            ImageLeftChoose.Visibility = Visibility.Hidden;
            ImageRightChoose.Visibility = Visibility.Hidden;
            LabelLeftChoose.Visibility = Visibility.Hidden;
            LabelRightChoose.Visibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
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
                bild.IsEnabled = false;
                
            }
            else
            {

                Label lb = (Label)FindName("Label_" + zahl);
                lb.Foreground = Brushes.Red;
                var bild = (Image)sender;
                bild.Visibility = Visibility.Hidden;

                if (round == 5)
                {

                    var value = 0;

                    value += casevalue;

                    foreach (var l in list)
                    {
                        value += l;
                    }

                    value = value / (list.Count + 1);

                    var dialog = new Dialog(value);
                    dialog.ShowDialog();

                    if (HasAccepted)
                    {
                        casevalue = value;
                        ChooseDialogOffer();


                    }


                }

                if (round == 10)
                {

                    var value = 0;

                    value += casevalue;

                    foreach (var l in list)
                    {
                        value += l;
                    }

                    value = value / (list.Count + 1);

                    var dialog = new Dialog(value);
                    dialog.ShowDialog();

                    if (HasAccepted)
                    {
                        casevalue = value;
                        ChooseDialogOffer();


                    }


                }

                if (round == 15)
                {

                    var value = 0;

                    value += casevalue;

                    foreach (var l in list)
                    {
                        value += l;
                    }

                    value = value / (list.Count + 1);

                    var dialog = new Dialog(value);
                    dialog.ShowDialog();

                    if (HasAccepted)
                    {
                        casevalue = value;
                        ChooseDialogOffer();


                    }


                }

            }

            //Runden zähler
            round++;

            if (list.Count == 1)
            {

                hideAllLablesAndPictures();

                ImageLeftChoose.Visibility = Visibility.Visible;
                ImageRightChoose.Visibility = Visibility.Visible;


                //Positioning Values Random
                Random r = new Random();
                int random = r.Next(1, 3);
                if(random == 1)
                {
                    LabelLeftChoose.Content = casevalue + "$";
                    LabelRightChoose.Content = list[0] + "$";
                }
                else
                {
                    LabelLeftChoose.Content = list[0] + "$";
                    LabelRightChoose.Content = casevalue + "$";
                }
                

                LabelLeftChoose.Visibility = Visibility.Visible;
                LabelRightChoose.Visibility = Visibility.Visible;
                
                
            }


        }


        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void PlayAgBtn_Click(object sender, RoutedEventArgs e)
        {

            Properties.Settings.Default.AlreadySaved = false;
            Properties.Settings.Default.Save();
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ChooseLastCase(object sender, MouseButtonEventArgs e)
        {
            /* Show Win */
            ImageLeftChoose.Visibility = Visibility.Hidden;
            ImageRightChoose.Visibility = Visibility.Hidden;
            LabelLeftChoose.Visibility = Visibility.Hidden;
            LabelRightChoose.Visibility = Visibility.Hidden;

            //MeganImage.Visibility = Visibility.Visible;
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"megan.jpg", UriKind.RelativeOrAbsolute));
            myBrush.ImageSource = image.Source;
            Grid grid = (Grid)FindName("gridMain");
            grid.Background = myBrush;
            EndKImage.Visibility = Visibility.Visible;
            LabelEnd.Content = casevalue + "$";
            PlayAgBtn.Visibility = Visibility.Visible;
            ShowScoreBtn.Visibility = Visibility.Visible;
            endValue = casevalue;
        }

        private void ChooseLastList(object sender, MouseButtonEventArgs e)
        {
            /* Show Win */
            ImageLeftChoose.Visibility = Visibility.Hidden;
            ImageRightChoose.Visibility = Visibility.Hidden;
            LabelLeftChoose.Visibility = Visibility.Hidden;
            LabelRightChoose.Visibility = Visibility.Hidden;

            //MeganImage.Visibility = Visibility.Visible;
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"megan.jpg", UriKind.RelativeOrAbsolute));
            myBrush.ImageSource = image.Source;
            Grid grid = (Grid)FindName("gridMain");
            grid.Background = myBrush;
            EndKImage.Visibility = Visibility.Visible;
            LabelEnd.Content = list[0] + "$";
            PlayAgBtn.Visibility = Visibility.Visible;
            ShowScoreBtn.Visibility = Visibility.Visible;
            endValue = list[0];
        }

        private void ChooseDialogOffer()
        {
            /* Show Win */
            hideAllLablesAndPictures();
            //MeganImage.Visibility = Visibility.Visible;
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"megan.jpg", UriKind.RelativeOrAbsolute));
            myBrush.ImageSource = image.Source;
            Grid grid = (Grid)FindName("gridMain");
            grid.Background = myBrush;
            EndKImage.Visibility = Visibility.Visible;
            LabelEnd.Content = casevalue + "$";
            PlayAgBtn.Visibility = Visibility.Visible;
            endValue = casevalue;
            ShowScoreBtn.Visibility = Visibility.Visible;
        }

        private void hideAllLablesAndPictures()
        {
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

            
            Label_1.Visibility = Visibility.Hidden;
            Label_5.Visibility = Visibility.Hidden;
            Label_10.Visibility = Visibility.Hidden;
            Label_50.Visibility = Visibility.Hidden;
            Label_100.Visibility = Visibility.Hidden;
            Label_200.Visibility = Visibility.Hidden;
            Label_350.Visibility = Visibility.Hidden;
            Label_500.Visibility = Visibility.Hidden;
            Label_1000.Visibility = Visibility.Hidden;
            Label_1500.Visibility = Visibility.Hidden;
            Label_2500.Visibility = Visibility.Hidden;
            Label_4000.Visibility = Visibility.Hidden;
            Label_10000.Visibility = Visibility.Hidden;
            Label_25000.Visibility = Visibility.Hidden;
            Label_50000.Visibility = Visibility.Hidden;
            Label_100000.Visibility = Visibility.Hidden;
            Label_250000.Visibility = Visibility.Hidden;
            Label_750000.Visibility = Visibility.Hidden;
            Label_1500000.Visibility = Visibility.Hidden;
            Label_3000000.Visibility = Visibility.Hidden;

        }

        private void hideAllPictures()
        {
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

        private void hideAllLables()
        {

            Label_1.Visibility = Visibility.Hidden;
            Label_5.Visibility = Visibility.Hidden;
            Label_10.Visibility = Visibility.Hidden;
            Label_50.Visibility = Visibility.Hidden;
            Label_100.Visibility = Visibility.Hidden;
            Label_200.Visibility = Visibility.Hidden;
            Label_350.Visibility = Visibility.Hidden;
            Label_500.Visibility = Visibility.Hidden;
            Label_1000.Visibility = Visibility.Hidden;
            Label_1500.Visibility = Visibility.Hidden;
            Label_2500.Visibility = Visibility.Hidden;
            Label_4000.Visibility = Visibility.Hidden;
            Label_10000.Visibility = Visibility.Hidden;
            Label_25000.Visibility = Visibility.Hidden;
            Label_50000.Visibility = Visibility.Hidden;
            Label_100000.Visibility = Visibility.Hidden;
            Label_250000.Visibility = Visibility.Hidden;
            Label_750000.Visibility = Visibility.Hidden;
            Label_1500000.Visibility = Visibility.Hidden;
            Label_3000000.Visibility = Visibility.Hidden;

        }

        private void showAllLables()
        {

            Label_1.Visibility = Visibility.Visible;
            Label_5.Visibility = Visibility.Visible;
            Label_10.Visibility = Visibility.Visible;
            Label_50.Visibility = Visibility.Visible;
            Label_100.Visibility = Visibility.Visible;
            Label_200.Visibility = Visibility.Visible;
            Label_350.Visibility = Visibility.Visible;
            Label_500.Visibility = Visibility.Visible;
            Label_1000.Visibility = Visibility.Visible;
            Label_1500.Visibility = Visibility.Visible;
            Label_2500.Visibility = Visibility.Visible;
            Label_4000.Visibility = Visibility.Visible;
            Label_10000.Visibility = Visibility.Visible;
            Label_25000.Visibility = Visibility.Visible;
            Label_50000.Visibility = Visibility.Visible;
            Label_100000.Visibility = Visibility.Visible;
            Label_250000.Visibility = Visibility.Visible;
            Label_750000.Visibility = Visibility.Visible;
            Label_1500000.Visibility = Visibility.Visible;
            Label_3000000.Visibility = Visibility.Visible;

        }

        private void ShowScoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var scoreview = new Score(endValue);
            scoreview.ShowDialog();
            
        }
    }
}
