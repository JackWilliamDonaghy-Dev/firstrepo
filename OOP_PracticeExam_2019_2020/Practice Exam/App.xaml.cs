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
        ObservableCollection<Player> players = Player.CreateTeam();
        
    }

}
