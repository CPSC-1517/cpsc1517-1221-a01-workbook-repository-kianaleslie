using NHLSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    //track and store team data 
    //need: team name : string (not blank, contain only letters A -  Z)
    //      city : string (not blank, contain at least 3 characters)
    //      arena : string (not blank)
    //      conference : conference 
    //      division : division 

    //test plan 
    //valid name, invalid name = "null", invalid name = "empty string", invalid name = "whitespaces only"
    public class Team
    {
        //Define fully implemented properties for Name, City, and Arena
        private string _name;
        private string _city;
        private string _arena;

        public List<Player> Players = new List<Player>();

        //default constructor
        public Team()
        {

        }
        //greedy constructor
        public Team(string name, string city, string arena, Conference conference, Division division) /*OR*/ /*public Team(string Name)*/
        {                                                                                                    /*{*/
            Name = name;                                                                                     /*this.Name = Name;*/ /*different naming convention*/
            City = city;
            Arena = arena;
            Conference = conference;
            Division = division;
        }
        public override string ToString()
        {
            return $"Team Name: {Name}, Team City: {City}, Team Arena: {Arena}, Conference: {Conference}, Division: {Division}";
        }
        public void AddPlayer(Player newPlayer)
        {
            //cannot be null, 
            //cannot add player if they are already on the team (check player number)
            //maximum of 23 players
            if (newPlayer == null)
            {
                throw new ArgumentNullException(nameof(AddPlayer), "Player cannot be null.");
            }
            foreach(var existingPlayer in Players)
            {
                if(newPlayer.PlayerNumber == existingPlayer.PlayerNumber)
                {
                    throw new ArgumentException($"Player Number {newPlayer.PlayerNumber} is already on the team.");
                }
            }
            if(Players.Count == 23)
            {
                throw new ArgumentException("Team is full. Cannot add anymore players.");
            }
            Players.Add(newPlayer);
        }

        //check Name is not blank and contains only letters A -  Z
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be blank.");
                }
                //string lettersOnly = @"^[a-zA-Z\s_-]+$"; //@"^[a-zA-Z]{1, }$"
                if (!Regex.IsMatch(value, @"^[a-zA-Z\s]+$") /*|| value.ToUpper() == "NULL"*/)
                {
                    throw new ArgumentException(nameof(Name), "Name must only contain letters.");
                }
                _name = value.Trim(); //removes leading ("     hello") and trailing ("hello     ") white spaces
            }
        }
        //check City is not blank and contains at least 3 characters
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(City), "City cannot be blank.");
                }
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("City must have at least 3 characters.");
                }
                _city = value.Trim();
            }
        }
        //check Arena is not blank
        public string Arena
        {
            get
            {
                return _arena;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(City), "Arena cannot be blank.");
                }
                _arena = value.Trim();
            }
        }
        //Define auto-implemented properties for Conference and Division
        public Conference Conference { get; set; }
        public Division Division { get; set; }
    }
}