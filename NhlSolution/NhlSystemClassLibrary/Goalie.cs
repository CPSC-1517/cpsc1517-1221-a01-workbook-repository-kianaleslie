using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Goalie /*derived class*/ : Player //Goalie inherites from the BASE class Player - whatever class is being inheritated from is called the base class - can only inheritate from one class, some languages can inheriate from multiple classes but it's still not reccomended
    {
        private double _savevaluepercentage;
        public double GoalsAgainstAverage { get; set; }
        public double SavePercentage 
        {
            get => _savevaluepercentage;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Save percentage must be between 0 and 1.");
                }
                _savevaluepercentage = value;   
            }
        }
        public double Shutouts { get; private set; }
        public Goalie(int playerNumber, string name /*Position position - don't need bc Goalies position is goalie*/) /* : base - calls inheritance from player*/ : base(playerNumber, name, /*position*/Position.G /*we can hardcode the G under the Position enum*/)
        {
            
        }
        public Goalie(int playerNumber, string name, int gamesPlayed) : base(playerNumber, name, Position.G)
        {
            base.GamesPlayed = gamesPlayed; //to access property use the base.
        }
        public void AddShutout()
        {
            Shutouts += 1;
        }
    }
}
