using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Practice_Exam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ObservableCollection<Player> Allplayers = Player.CreateTeam();
        ObservableCollection<Player> SelectedPlayers = new ObservableCollection<Player>();

        
        


        
        public void WarnUser(string warning)
        {
            MessageBox.Show(warning, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }

}
