using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Exam
{
    internal class Player
    {
        public enum position { Goalkeeper, Defender, Midfielder, Forward }

        public string FirstName { get; set; }
        public string SurName { get; set; }

        public position PreferredPosition { get; set; }

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        Random random = new Random();
        int firstNameIndex, surNameIndex;

        string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannah", "Harry", "Jack", "James",
                "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie"};

        string[] surNames = {
                "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh",
                "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien",
                "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh"};


        public Player(string firstName, string surName, position prefPosition, DateTime dateOfBirth)
        {
            FirstName = firstName;
            SurName = surName;

            PreferredPosition = prefPosition;
            DOB = dateOfBirth;

            Age = DateTime.Now.Year - dateOfBirth.Year;

            if (DateTime.Now < dateOfBirth.AddYears(Age))
            {
                Age--;
            }
        }

        public Player(position prefPosition, DateTime dateOfBirth)
        {
            firstNameIndex = random.Next(firstNames.Length);
            FirstName = firstNames[firstNameIndex];

            surNameIndex = random.Next(surNames.Length);
            SurName = surNames[firstNameIndex];

            PreferredPosition = prefPosition;
            DOB = dateOfBirth;

            Age = DateTime.Now.Year - dateOfBirth.Year;

            if (DateTime.Now < dateOfBirth.AddYears(Age))
            {
                Age--;
            }
        }

        public Player() { }


        static public ObservableCollection<Player> CreateTeam()
        {
            var team = new ObservableCollection<Player>();
            int teamsize = 18;

            //2 GoalKeepers
            for (int i = 0; i < 2; i++)
            {
                team.Add(new Player(position.Goalkeeper, RandomDOB()));
            }

            //6 Defenders
            for (int i = 0; i < 6; i++)
            {
                team.Add(new Player(position.Defender, RandomDOB()));
            }

            //6 Midfielders
            for (int i = 0; i < 6; i++)
            {
                team.Add(new Player(position.Midfielder, RandomDOB()));
            }

            //4 Forwards
            for (int i = 0; i < 4; i++)
            {
                team.Add(new Player(position.Forward, RandomDOB()));
            }

            return team;
        }

        static public DateTime RandomDOB()
        {
            Random random = new Random();
            return new DateTime(random.Next(1996, 2005), random.Next(1, 12), random.Next(1, 28));
        }
    
    }
}
