using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C)]
        [DataRow(93, "Ryan NugentHopkins", Position.C)]
        [DataRow(91, "Evander Kane", Position.LW)]
        public void Constructor_ValidData_ShouldPass(int playerNumber, string playerName, Position position)
        {
            //Arrange and Act
            //Player currentPlayer = new Player(97, "Connor McDavid", Position.C);
            Player currentPlayer = new Player(playerNumber, playerName, position);

            //Assert
            Assert.AreEqual(/*97*/playerNumber, currentPlayer.PlayerNumber);
            Assert.AreEqual(/*"Connor McDavid"*/playerName, currentPlayer.PlayerName);
            Assert.AreEqual(/*Position.C*/position, currentPlayer.Position);
        }

        [TestMethod]
        [DataRow(0, "Connor McDavid", Position.C)]
        [DataRow(99, "Connor McDavid", Position.C)]
        [DataRow(-1, "Connor McDavid", Position.C)]
        [DataRow(100, "Connor McDavid", Position.C)]
        public void PlayerNumber_InvalidValue_ThrowsArgumentException(int playerNumber, string playerName, Position position)
        {
            try
            {
                Player player = new Player(playerNumber, playerName, position);
                Assert.Fail("ArgumentException should have been thrown");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "Player Number must be between 1 and 98.");
                Assert.AreEqual(ex.Message, "Player Number must be between 1 and 98.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect exception type thrown.");
            }
        }

        [TestMethod]
        [DataRow(97, "", Position.C)]
        [DataRow(93, "        ", Position.C)]
        [DataRow(91, null, Position.C)]
        [DataRow(91, "abc", Position.C)]
        public void PlayerName_InvalidValue_ThrowsArgumentException(int playerNumber, string playerName, Position position)
        {
            try
            {
                Player player = new Player(playerNumber, playerName, position);
                Assert.Fail("ArgumentException should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                //StringAssert.Contains(ex.Message, "Player Name cannot be blank.");
                Assert.AreEqual(ex.Message, "Player Name cannot be blank.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect exception type thrown.");
            }
        }

        //to do
        //test data for games played, assists, goals 
        //test data for add games played, add assists, add goals

        [TestMethod]
        public void GamesPlayed_IsPositiveOrZero()
        {
            
        }
        [TestMethod]
        public void Assists_IsPositiveOrZero()
        {

        }
        [TestMethod]
        public void Goals__IsPositiveOrZero()
        {

        }
        [TestMethod]
        public void AddGamesPlayed_IsIncremented()
        {

        }
        [TestMethod]
        public void AddAssists_IsIncremented()
        {

        }
        [TestMethod]
        public void AddGoals_IsIncremented()
        {

        }
    }
}