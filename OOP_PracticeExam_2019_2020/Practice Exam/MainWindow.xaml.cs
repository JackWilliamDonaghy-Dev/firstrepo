using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            bxSelectedPlayers.ItemsSource = SelectedPlayers;

            DataContext = this;
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (bxAllPlayers.SelectedIndex < 0)
            {
                return;
            }

            if (!CheckCapacity(bxAllPlayers.SelectedIndex))
            {
                MessageBox.Show("That position is already full for this formation.");
                return;
            }

            SelectedPlayers.Add(AllPlayers[bxAllPlayers.SelectedIndex]);
            AllPlayers.Remove(AllPlayers[bxAllPlayers.SelectedIndex]);
        }

        static int maxGoalies = 1, maxDefenders = 4, maxMidfielders = 4, maxForwards = 2;
        private bool CheckCapacity(int playerIndex)
        {
            Player player = AllPlayers[playerIndex];
            int goalies = SelectedPlayers.Count(selected => selected.PreferredPosition == Player.position.Goalkeeper);
            int defenders = SelectedPlayers.Count(selected => selected.PreferredPosition == Player.position.Defender);
            int midfielders = SelectedPlayers.Count(selected => selected.PreferredPosition == Player.position.Midfielder);
            int forwards = SelectedPlayers.Count(selected => selected.PreferredPosition == Player.position.Forward);

            switch (player.PreferredPosition)
            {
                case Player.position.Goalkeeper:
                    return goalies < maxGoalies;
                case Player.position.Defender:
                    return defenders < maxDefenders;
                case Player.position.Midfielder:
                    return midfielders < maxMidfielders;
                case Player.position.Forward:
                    return forwards < maxForwards;
                default:
                    return false;
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
