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

        public Score()
        {
            InitializeComponent();
            DataContext = this;
            ScoreList = new ObservableCollection<Highscore>();
            var first = new Highscore() { Score = Properties.Settings.Default.ErsterScore , Place = "1"};
            var sec = new Highscore() { Score = Properties.Settings.Default.ZweiterScore, Place = "2" };
            var tresh = new Highscore() { Score = Properties.Settings.Default.DritterScore, Place = "3" };
            ScoreList.Add(first);
            ScoreList.Add(sec);
            ScoreList.Add(tresh);
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
