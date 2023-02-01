using NHLSystemClassLibrary;
using System.Reflection.Metadata;

namespace NHLSystemTestProject
{
    [TestClass] //[] = attribute - data about data
    public class TeamTest
    {
        [TestMethod]
        [DataRow("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific)] /*[DateRow] allows us to test more data at once*/
        [DataRow("Flames", "Calgary", "Scotiabank Saddledome", Conference.Western, Division.Pacific)]
        [DataRow("Canucks", "Vancouver", "Rogers Arena", Conference.Western, Division.Pacific)]
        [DataRow("MapleLeafs", "Toronto","Scotiabank Arena", Conference.Eastern, Division.Atlantic)]
        [DataRow("Senators", "Ottawa", "Canadian Tire Centre", Conference.Eastern, Division.Atlantic)]
        [DataRow("Canadiens", "Montreal", "Centre Bell", Conference.Eastern, Division.Atlantic)]
        [DataRow("Jets", "Winnipeg", "Canadian Life Centre", Conference.Eastern, Division.Central)]
        public void Name_ValidName_NameSet(string teamName, string city, string arena, Conference conference, Division division)
        {
            //Arrange
            //Act
            Team currentTeam = new Team(teamName, city, arena, conference, division);
            //Assert
            Assert.AreEqual(teamName, currentTeam.Name);
            Assert.AreEqual(city, currentTeam.City);
            Assert.AreEqual(arena, currentTeam.Arena);
            Assert.AreEqual(conference, currentTeam.Conference);
            Assert.AreEqual(division, currentTeam.Division);
        }

        [TestMethod]
        [DataRow(null, "Name cannot be blank.", Conference.Western, Division.Pacific)]
        [DataRow("", "Name cannot be blank.", Conference.Western, Division.Pacific)]
        [DataRow("     ", "Name cannot be blank.", Conference.Western, Division.Pacific)]
        public void Name_InvalidName_ThrowsArgumentNullException(string teamName, string expectedErrorMessage, string city, string arena, Conference conference, Division division)
        {
            //Arrange and Act 
            try
            {
                Team currentTeam = new Team(teamName, city, arena, conference, division);
                //Assert
                Assert.Fail("An ArgumentNullException should have been thrown.");
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, expectedErrorMessage);
            }
        }
    }
}