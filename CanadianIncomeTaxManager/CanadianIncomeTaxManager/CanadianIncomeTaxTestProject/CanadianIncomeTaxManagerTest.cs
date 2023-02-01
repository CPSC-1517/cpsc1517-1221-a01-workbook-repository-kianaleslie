using CanadianIncomeTaxManager;
namespace CanadianIncomeTaxTestProject
{
    [TestClass]
    public class CanadianIncomeTaxManagerTest
    {
        [TestMethod]
        [DataRow(@"..\..\..\Data\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void LoadFromCSVFile_RowCount_CorrectCount(string csvFilePath, int expectedCount)
        {
            //Arrange - create an object to test
            var dataManager = new CanadianIncomeTaxManagerClass();

            //Act - preform some task with the object 
            //this is the path straight from downloads
            //List<string> linesFromFile = dataManager.LoadFromCSVFile(@"C:\Users\kleslie7\Downloads\CanadianPersonalIncomeTaxRates.csv");
            //copy and paste csv from downloads into a folder named data - uses a different path 
            List<string> linesFromFile = dataManager.LoadFromCSVFile(csvFilePath);

            //Assert - call an Assert method
            //verify that there are 439 records
            Assert.AreEqual(expectedCount, linesFromFile.Count);
        }

        [TestMethod]
        [DataRow(@"..\..\..\Data\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void ConvertToCanadianIncomeTax_CorrectConversion_ExpectedResults(string csvFilePath, int expectedCount)
        {
            //Arrange - create an object to test
            var dataManager = new CanadianIncomeTaxManagerClass();

            //Act - preform some task with the object
            List<string> linesFromFile = dataManager.LoadFromCSVFile(csvFilePath);
            List<CanadianIncomeTaxData> incomeTaxData = dataManager.ConvertToCanadianIncomeTax(linesFromFile);
            //Assert - call an Assert method
            Assert.AreEqual(expectedCount, incomeTaxData.Count);
            //check the content of the first element and the last element
            int firstIndex = 0;
            int lastIndex = incomeTaxData.Count - 1;
            Assert.AreEqual("CAN", incomeTaxData[firstIndex].RegionAbbreviation);
            Assert.AreEqual(2023, incomeTaxData[firstIndex].TaxYear);
            Assert.AreEqual("NU", incomeTaxData[lastIndex].RegionAbbreviation);
            Assert.AreEqual(2015, incomeTaxData[lastIndex].TaxYear);
        }
    }
}