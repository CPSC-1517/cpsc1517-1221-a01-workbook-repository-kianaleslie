using NHLSystemClassLibrary;
using System.Text.Json;

namespace NHLConsoleApp
{
    internal class Program
    {
        const string jsonFilePath = @"..\..\..\team.json";
        static void Main(string[] args)
        {
            static void ConsolAppOne()
            {
                //Prompt and read in the team name
                //Console.Write("Enter the team name: ");
                //string teamName = Console.ReadLine();
                try
                {
                    Team oilers = new Team("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific);
                    Console.WriteLine($"Team Name: {oilers.Name}\n" +
                        $"Team City: {oilers.City}\n" +
                        $"Team Arena: {oilers.Arena}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("Incorrect exception thrown.");
                }
            }

            //Serialization:
            //Team team = ReadPlayerDataFromCSV();
            //PrintTeamInfo(team);
            //WriteTeamInfoToJsonFile(team, jsonFilePath);

            //Deserialization:
            Team currentTeam = ReadTeamFromJsonFile();
            PrintTeamInfo(currentTeam);

            static void LinQMethods()
            {
                //TODO: Create a new array with the names of 12 of your favourite game titles
                string[] favouriteGames = new string[12];

                string[] faveGames = //array instializer syntax
                { "Apex Legends",
              "Call of Duty: Black Ops 1",
              "Gears of War",
              "Dead by Daylight",
              "Minecraft",
              "Grand Theft Auto",
              "Mario Kart",
              "Overcooked",
              "Elden Ring",
              "Halo",
              "Call of Duty: Black Ops 2",
              "Rainbow Six Siege",
              "Super Mario Bros"
            };

                //Print the name of each game title using a foreach loop
                Console.WriteLine("\nThis list of my favourite game titles is in a foreach loop: \n");
                foreach (string gameTitle in faveGames) //process all elements - use foreach 
                {
                    Console.WriteLine(gameTitle);
                }

                //Print the name of each game title using a for loop 
                Console.WriteLine("\nThis list of my favourite game titles is in a for loop: \n");
                for (int index = 0; index < faveGames.Length; index++)
                {
                    Console.WriteLine(faveGames[index]);
                }

                //Print the name of each title using the LinQ Enumerable ForEach method
                Console.WriteLine("\nThis list of my favourite game titles is in a LinQ Enumerable ForEach method: \n");
                faveGames.ToList().ForEach(currentGame => Console.WriteLine(currentGame));

                //Sort the game titles in ascending order then print the name of each game 
                //HINT: can use the Order LinQ Numerable method
                Console.WriteLine("\nThis is the list in ascending order using the Order LinQ Numerable method: \n");
                faveGames.ToList().OrderBy(currentGame => currentGame).ToList().ForEach(currentGame => Console.WriteLine(currentGame));

                //Use the LinQ Enumerable method Where() to include only games with a keyword
                Console.WriteLine("\nThis is the game title that contains \"Legends\" as a keyword using the Where LinQ Numerable method: \n");
                faveGames.Where(currentGame => currentGame.Contains("Legends")).ToList().ForEach(currentGame => Console.WriteLine(currentGame));

                //Use the LinQ Enumerable method to determine if any of the games contain the Call of Duty title
                Console.WriteLine("\nIs there a game title in the array that contains the \"Call of Duty\" title?");
                bool anyCODTitle = faveGames.Any(currentGame => currentGame.Contains("Call of Duty"));
                if (anyCODTitle)
                {
                    Console.WriteLine("\nYes, there are games with the title Call of Duty.");
                }
                else
                {
                    Console.WriteLine("\nNo, there are no games with the title Call of Duty.");
                }

                //Use the LinQ Enumerable method First()/FirstOrDefault() to return the first game with the title "Super Mario"
                //FirstOrDefault() - makes sure the value is not null  //First() - made to handle exceptions 
                string? queryGame = faveGames.Where(currentGame => currentGame.Contains("Super Mario")).FirstOrDefault();
                Console.WriteLine($"\nThe first game title that contains \"Super Mario\" is {queryGame}");
            }
            static Team ReadPlayerDataFromCSV()
            {
                //Create a CSV file with 5 sample players
                //Create a new Team instance 
                Team newTeam = new Team("NewBestTeam", "Toronto", "Rogers Arena", Conference.Western, Division.Central);
                //Write the code to read from the CSV file using the Player TryParse method and add player to the Team instance
                string[] allLines = File.ReadAllLines(@"..\..\..\HockeyTeam.txt");
                foreach (var line in allLines)
                {
                    try
                    {
                        Player currentPlayer = null;
                        if (Player.TryParse(line, out currentPlayer))
                        {
                            newTeam.AddPlayer(currentPlayer);
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error reading file with exception {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading from file with exception {ex.Message}");
                    }
                }
                return newTeam;
            }
            static void PrintTeamInfo(Team newTeam)
            {
                //Display the team info and all the players in the team (name, city, arena, confernce, division, players)
                Console.WriteLine($"{newTeam.Name},{newTeam.City},{newTeam.Arena},{newTeam.Division}");
                foreach (var currentPlayer in newTeam.Players)
                {
                    Console.WriteLine(currentPlayer.ToString());
                }
            }
            static void WriteTeamInfoToJsonFile(Team currentTeam, string jsonFilePath)
            {
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true,
                    };
                    string jsonString = JsonSerializer.Serialize<Team>(currentTeam, options);
                    File.WriteAllText(jsonFilePath, jsonString);
                    Console.WriteLine("Write to JSON file was successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error serializing to JSON file with exception: {ex.Message}");
                }
            }
            static Team ReadTeamFromJsonFile()
            {
                Team currentTeam = null;
                try
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true,
                    };
                    currentTeam = JsonSerializer.Deserialize<Team>(jsonString, options);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error deserialize JSON file with exception {ex.Message}");
                }
                return currentTeam;
            }
        }
    }
}