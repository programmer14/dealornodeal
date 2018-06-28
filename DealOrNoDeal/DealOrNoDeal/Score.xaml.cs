using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DealOrNoDeal
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Highscore> _ScoreList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Highscore> ScoreList
        {
            get { return _ScoreList; }
            set { _ScoreList = value; OnPropertyChanged("ScoreList"); }
        }
        private int endvalue = 0;
        public Score(int value)
        {
            InitializeComponent();
            DataContext = this;
            endvalue = value;
            ScoreLabel.Content = "Your Score: " + endvalue;
            FillList();
        }
        private void FillList()
        {
            ScoreList = new ObservableCollection<Highscore>();
            var first = new Highscore() { Score = Properties.Settings.Default.ErsterScore, Place = "1", Name = Properties.Settings.Default.ErsterName };
            var sec = new Highscore() { Score = Properties.Settings.Default.ZweiterScore, Place = "2", Name = Properties.Settings.Default.ZweiterName };
            var tresh = new Highscore() { Score = Properties.Settings.Default.DritterScore, Place = "3", Name = Properties.Settings.Default.DriterName };
            ScoreList.Add(first);
            ScoreList.Add(sec);
            ScoreList.Add(tresh);
        }
        private void SaveScore()
        {
            if (endvalue >= Properties.Settings.Default.ErsterScore)
            {
                var ersterName = Properties.Settings.Default.ErsterName;
                var ersterScore = Properties.Settings.Default.ErsterScore;
                var zweiterName = Properties.Settings.Default.ZweiterName;
                var zweiterScore = Properties.Settings.Default.ZweiterScore;
                Properties.Settings.Default.ErsterName = TxtBoxName.Text;
                Properties.Settings.Default.ErsterScore = endvalue;
                Properties.Settings.Default.ZweiterName = ersterName;
                Properties.Settings.Default.ZweiterScore = ersterScore;
                Properties.Settings.Default.DriterName = zweiterName;
                Properties.Settings.Default.DritterScore = zweiterScore;
            }
            else if (endvalue >= Properties.Settings.Default.ZweiterScore)
            {
                var zweiterName = Properties.Settings.Default.ZweiterName;
                var zweiterScore = Properties.Settings.Default.ZweiterScore;
                Properties.Settings.Default.ZweiterName = TxtBoxName.Text;
                Properties.Settings.Default.ZweiterScore = endvalue;
                Properties.Settings.Default.DriterName = zweiterName;
                Properties.Settings.Default.DritterScore = zweiterScore;
            }
            else if (endvalue >= Properties.Settings.Default.DritterScore)
            {
                Properties.Settings.Default.DriterName = TxtBoxName.Text;
                Properties.Settings.Default.DritterScore = endvalue;
            }
            Properties.Settings.Default.AlreadySaved = true;
            Properties.Settings.Default.Save();
            FillList();
            SaveScoreBtn.IsEnabled = false;
            TxtBoxName.IsEnabled = false;
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SaveScoreBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveScore();
        }
        private void CheckSaveButton()
        {
            if ((endvalue >= Properties.Settings.Default.ErsterScore || endvalue >= Properties.Settings.Default.ZweiterScore || endvalue >= Properties.Settings.Default.DritterScore) && !string.IsNullOrWhiteSpace(TxtBoxName.Text) && !Properties.Settings.Default.AlreadySaved)
            {
                SaveScoreBtn.IsEnabled = true;
            }else
            {
                SaveScoreBtn.IsEnabled = false;
            }
        }

        private void TxtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSaveButton();
        }
    }
}
