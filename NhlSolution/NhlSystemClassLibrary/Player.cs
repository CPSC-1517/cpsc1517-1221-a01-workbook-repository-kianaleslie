using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NHLSystemClassLibrary
{
    public class Player
    {
        //make a const min and max so it's easier to change in one place
        const int MINPLAYERNUMBER = 1;
        const int MAXPLAYERNUMBER = 98;

        //fields 
        private int _playernumber; /*1 -98*/
        private string _playername; /*not blank, letters only*/
        private int _gamesplayed; /* >= 0*/
        private int _goals; /* >= 0*/
        private int _assists; /* >= 0*/
        private int _points; /*goals + assists*/

        //constructors
        public Player(int playerNumber, string name, Position position)
        {
            PlayerNumber = playerNumber;
            PlayerName = name;
            Position = position;
        }
        public Player(int playerNumber, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNumber = playerNumber;
            PlayerName = name;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }
        public Player()
        {

        }
        //methods
        public void AddGamesPlayed()
        {
            GamesPlayed += 1;
        }
        public void AddGoals()
        {
            Goals += 1;
        }
        public void AddAssist()
        {
            Assists++;
        }
        //properties
        public int PlayerNumber
        {
            get => _playernumber; // - body modifier syntax is used for single statements (VS tries to suggest "set => value", but you can't)
            //get
            //{
            //    return _playernumber;
            //}
            private set //can only be changed within this class - used for values that should not change once they are set
            {
                if (value < MINPLAYERNUMBER || value > MAXPLAYERNUMBER)
                {
                    throw new ArgumentException(nameof(PlayerNumber), $"Player Number must be between {MINPLAYERNUMBER} and {MAXPLAYERNUMBER}.");
                }
                _playernumber = value;
            }
        }
        public string PlayerName
        {
            get => _playername;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(PlayerName), "Player Name cannot be blank.");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
                {
                    throw new ArgumentException(nameof(PlayerName), "Player Name must only contain letters.");
                }
                _playername = value.Trim();
            }
        }
        public int GamesPlayed
        {
            get => _gamesplayed;
            protected set //public/ private/ protected: used with inheritance
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentNullException(nameof(GamesPlayed), "Games played must be a positive number or zero.");
                }
                _gamesplayed = value;
            }
        }
        public int Goals
        {
            get => _goals;
            private set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentNullException(nameof(Goals), "Goals must be a positive number or zero.");
                }
                _goals = value;
            }
        }
        public int Assists
        {
            get => _assists;   
            set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentNullException(nameof(Assists), "Assists cmust be a positive number or zero.");
                }
                _assists = value;
            }
        }
        /*public int Points => Goals + Assists;*/ //short syntax / computer property = only get, no set 
        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }
        public Position Position { get; private set; }
        public override string ToString()
        {
            return $"{PlayerNumber}, {PlayerName}, {Position}, {GamesPlayed}, {Goals}, {Assists}";
        }
        public static Player Parse(string csvLine)
        {
            const char DELIMITER = ',';
            /*
             The order of the column value are (as defined in ToString() method):
             0 PlayerNumber
             1 PlayerName
             2 Position 
             3 GamesPLayed
             4 Goals
             5 Assists
             */
            const int EXPECTEDCOLUMNCOUNT = 6;
            string[] tokens = csvLine.Split(DELIMITER);
            //verify the length of the array
            if (tokens.Length != EXPECTEDCOLUMNCOUNT)
            {
                throw new FormatException($"CSV line must contain exactly {EXPECTEDCOLUMNCOUNT} values.");
            }
            int playerNumber = int.Parse(tokens[0]);
            string playerName = tokens[1];
            Position position = Enum.Parse<Position>(tokens[2]);
            //OR
            //Position position = (Position)Enum.Parse(typeof(Position), (tokens[2]);
            int gamesPlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);
            return new Player(playerNumber, playerName, position, gamesPlayed, goals, assists);
        }
        public static bool TryParse(string csvLine, out Player currentPlayer) //"ref" - don't have to change currentPlayer whereas "out" you must
        {
            bool success = false;
            try
            {
                currentPlayer = Parse(csvLine);
                success = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse method failed with exception {ex.Message}");
            }
            return success;
        }
    }
}
//inheritance - override, abstract: designed and created for inheritance specifically