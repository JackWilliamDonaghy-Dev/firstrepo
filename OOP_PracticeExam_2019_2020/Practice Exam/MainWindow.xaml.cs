using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
            ObservableCollection<Player> AllPlayers = new ObservableCollection<Player>();
            ObservableCollection<Player> SelectedPlayers = new ObservableCollection<Player>();
        public MainWindow()
        {
            InitializeComponent();

            AllPlayers = Player.CreateTeam();
            bxAllPlayers.ItemsSource = AllPlayers;
            bxAllPlayers.SelectedIndex = 0;



            DataContext = this;
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {


            if () { }
            else
            {
                SelectedPlayers.Add(AllPlayers[bxAllPlayers.SelectedIndex]);
                AllPlayers.Remove(AllPlayers[bxAllPlayers.SelectedIndex]);

            }
        }

        static int maxGoalies = 1, maxDefenders = 4, maxMidfielders = 4, maxForwards = 2;
        private void CheckCapacity(int playerIndex)
        {
            Player player = AllPlayers[playerIndex];
            if () {
        }
    }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxFormations.SelectionBoxItem.ToString() == "4-4-2")
            {
                maxGoalies = 1;
                maxDefenders = 4;
                maxMidfielders = 4;
                maxForwards = 2;
            }
            else if (cmbxFormations.SelectionBoxItem.ToString() == "4-3-3")
            {
                maxGoalies = 1;
                maxDefenders = 4;
                maxMidfielders = 3;
                maxForwards = 3;
            }
            else if (cmbxFormations.SelectionBoxItem.ToString() == "4-5-1")
            {
                maxGoalies = 1;
                maxDefenders = 4;
                maxMidfielders = 5;
                maxForwards = 1;
            }
        }
    }