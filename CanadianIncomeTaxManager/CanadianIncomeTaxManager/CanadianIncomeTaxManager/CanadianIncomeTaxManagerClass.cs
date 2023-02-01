namespace CanadianIncomeTaxManager
{
    public class CanadianIncomeTaxManagerClass
    {
        public List<CanadianIncomeTaxData> ConvertToCanadianIncomeTax(List<string> lines)
        {
            List<CanadianIncomeTaxData> dataList = new List<CanadianIncomeTaxData>();
            //iterate through each line
            foreach(string aLine in lines)
            {
                string[] tokens = aLine.Split(',');
                CanadianIncomeTaxData data = new CanadianIncomeTaxData();
                data.RegionAbbreviation = tokens[0];
                data.RegionName = tokens[1];
                data.TaxYear = int.Parse(tokens[2]);
                data.StartingIncome = decimal.Parse(tokens[4]);
                data.EndingIncome = decimal.Parse(tokens[5]);
                data.TaxRate = double.Parse(tokens[6]);
                data.BaseTaxAmount = decimal.Parse(tokens[7]);

                dataList.Add(data);
            }
            return dataList;
        }
        public List<string> LoadFromCSVFile(string csvFilePath)
        {
            //Can use StreamReader or File class to read data from a file/text //File.
            List<string> lines = new List<string>();

            //StreamReader sr = new StreamReader(csvFilePath);
            //sr.Close(); // close the reader 

            //OR

            //using (StreamReader sr = new StreamReader(csvFilePath))
            //{
            //    string currentLine;
            //    //skip the first line as it conatins column headings and not data we want to read
            //    sr.ReadLine();
            //    while ((currentLine = sr.ReadLine()) != null)
            //    {
            //        lines.Add(currentLine);
            //    }
            //}this curly brace closes the reader

            //OR

            string[] lineArray = File.ReadAllLines(csvFilePath);
            //foreach (string currentLine in lineArray)
            //{
            //    lines.Add(currentLine);
            //}

            //OR

            for (int i = 1; i < lineArray.Length; i++)
            {
                lines.Add(lineArray[i]);
            }

            return lines;
        }
    }
}