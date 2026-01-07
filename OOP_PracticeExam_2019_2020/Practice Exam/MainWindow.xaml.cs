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

    //public partial class MainWindow : Window
    //{
    //        ObservableCollection<Player> AllPlayers = new ObservableCollection<Player>();
    //        ObservableCollection<Player> SelectedPlayers = new ObservableCollection<Player>();
    //    public MainWindow()
    //    {
    //        InitializeComponent();

    //        AllPlayers = Player.CreateTeam();
    //        bxAllPlayers.ItemsSource = AllPlayers;
    //        bxAllPlayers.SelectedIndex = 0;



    //        DataContext = this;
    //    }

    //    private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
    //    {


    //        if () { }
    //        else
    //        {
    //            SelectedPlayers.Add(AllPlayers[bxAllPlayers.SelectedIndex]);
    //            AllPlayers.Remove(AllPlayers[bxAllPlayers.SelectedIndex]);

    //        }
    //    }

    //    static int maxGoalies = 1, maxDefenders = 4, maxMidfielders = 4, maxForwards = 2;
    //    private void CheckCapacity(int playerIndex)
    //    {
    //        Player player = AllPlayers[playerIndex];
    //        if () {
    //    }
    //}

    //    public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //    {
    //        if (cmbxFormations.SelectionBoxItem.ToString() == "4-4-2")
    //        {
    //            maxGoalies = 1;
    //            maxDefenders = 4;
    //            maxMidfielders = 4;
    //            maxForwards = 2;
    //        }
    //        else if (cmbxFormations.SelectionBoxItem.ToString() == "4-3-3")
    //        {
    //            maxGoalies = 1;
    //            maxDefenders = 4;
    //            maxMidfielders = 3;
    //            maxForwards = 3;
    //        }
    //        else if (cmbxFormations.SelectionBoxItem.ToString() == "4-5-1")
    //        {
    //            maxGoalies = 1;
    //            maxDefenders = 4;
    //            maxMidfielders = 5;
    //            maxForwards = 1;
    //        }
    //    }
    //}
    //other method
    // GitHub Repo: https://github.com/YourName/YourRepoLink
    // COMP06240 OOP Exam - Ticket Booking App (Jan 2024/25)

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    namespace TicketOasis
    {
        // Q1(f) enum
        public enum EventType
        {
            Music,
            Comedy,
            Theatre
        }

        // Q1(d) Ticket class
        public class Ticket
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int AvailableTickets { get; set; }

            public override string ToString()
            {
                return $"{Name} - €{Price:0.00} ({AvailableTickets} AVAILABLE)";
            }
        }

        // Q1(e) VIPTicket extends Ticket
        public class VIPTicket : Ticket
        {
            public string AdditionalExtras { get; set; }
            public decimal AdditionalCost { get; set; }

            public override string ToString()
            {
                decimal total = Price + AdditionalCost;
                return $"{Name} - €{total:0.00} ({AdditionalExtras}) ({AvailableTickets} AVAILABLE)";
            }
        }

        // Q1(f) + Q1(g) Event class implements IComparable by EventDate
        public class Event : IComparable<Event>
        {
            public string Name { get; set; }
            public DateTime EventDate { get; set; }
            public List<Ticket> Tickets { get; set; } = new List<Ticket>();
            public EventType TypeOfEvent { get; set; }

            public int CompareTo(Event other)
            {
                // Sort by date (earliest first)
                return EventDate.CompareTo(other.EventDate);
            }

            public override string ToString()
            {
                return $"{Name} - {EventDate:dd/MM/yyyy}";
            }
        }

        public partial class MainWindow : Window
        {
            // Holds the “master list” used for sorting + search reset
            private List<Event> _events = new List<Event>();

            public MainWindow()
            {
                InitializeComponent();
            }

            // Q1(i) On load: create data + display events in left listbox
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                GetData();               // Q1(h)
                _events.Sort();          // Q1(g) using IComparable
                lstEvents.ItemsSource = _events;

                // Optional: clear right side until user selects an event
                lstTickets.ItemsSource = null;
            }

            // Q1(h) Create objects exactly as specified in paper
            private void GetData()
            {
                _events = new List<Event>();

                // Events
                Event oasis = new Event
                {
                    Name = "Oasis Croke Park",
                    EventDate = new DateTime(2025, 06, 20),
                    TypeOfEvent = EventType.Music
                };

                Event picnic = new Event
                {
                    Name = "Electric Picnic",
                    EventDate = new DateTime(2025, 08, 20),
                    TypeOfEvent = EventType.Music
                };

                // Tickets
                Ticket earlyBird = new Ticket
                {
                    Name = "Early Bird",
                    Price = 100m,
                    AvailableTickets = 100
                };

                Ticket platinium = new Ticket
                {
                    Name = "Platinium",
                    Price = 150m,
                    AvailableTickets = 100
                };

                // VIP Tickets
                VIPTicket hotelPackage = new VIPTicket
                {
                    Name = "Ticket and Hotel Package",
                    Price = 150m,
                    AdditionalCost = 100m,
                    AdditionalExtras = "4* hotel",
                    AvailableTickets = 100
                };

                VIPTicket weekendTicket = new VIPTicket
                {
                    Name = "Weekend Ticket",
                    Price = 200m,
                    AdditionalCost = 100m,
                    AdditionalExtras = "with camping",
                    AvailableTickets = 100
                };

                // Add a regular + VIP ticket to each event (as requested)
                oasis.Tickets.Add(earlyBird);
                oasis.Tickets.Add(hotelPackage);

                picnic.Tickets.Add(platinium);
                picnic.Tickets.Add(weekendTicket);

                // Add events to list
                _events.Add(oasis);
                _events.Add(picnic);
            }

            // Q1(i) Selecting an event shows its tickets in the right listbox
            private void lstEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Event selectedEvent = lstEvents.SelectedItem as Event;

                if (selectedEvent == null)
                {
                    lstTickets.ItemsSource = null;
                    return;
                }

                lstTickets.ItemsSource = selectedEvent.Tickets;
            }

            // Q1(j) Book ticket logic
            private void Book_Click(object sender, RoutedEventArgs e)
            {
                Ticket selectedTicket = lstTickets.SelectedItem as Ticket;

                if (selectedTicket == null)
                {
                    MessageBox.Show("Please select a ticket first.");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid number of tickets.");
                    return;
                }

                if (selectedTicket.AvailableTickets >= quantity)
                {
                    selectedTicket.AvailableTickets -= quantity;

                    // Refresh right list to show new "AVAILABLE" count
                    lstTickets.Items.Refresh();

                    MessageBox.Show($"Booked {quantity} ticket(s) for '{selectedTicket.Name}'.");
                }
                else
                {
                    MessageBox.Show("Not enough tickets available.");
                }
            }

            // Q1(k) Search events by name (filters left listbox)
            private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
            {
                string search = (txtSearch.Text ?? "").Trim().ToLower();

                if (string.IsNullOrWhiteSpace(search))
                {
                    lstEvents.ItemsSource = _events;
                    return;
                }

                var filtered = _events
                    .Where(ev => ev.Name != null && ev.Name.ToLower().Contains(search))
                    .ToList();

                lstEvents.ItemsSource = filtered;
            }
        }
    }