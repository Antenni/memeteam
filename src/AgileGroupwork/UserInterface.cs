namespace MemeTeamPro
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    
    public class UserInterface
    {
        public UserInterface()
        {}
        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter command");
                Console.WriteLine("1 - Add a score for a person");
                Console.WriteLine("2 - Show a person's score");
                Console.WriteLine("3 - Show all scores");
                Console.WriteLine("x - Quit");
                string command = Console.ReadLine();
                Console.WriteLine();
                if (command == "x" || command == "X")
                {
                    Console.WriteLine("Thank you! Bye!");
                    break;
                }
                if (command == "1")
                {
                    Console.WriteLine("Person's name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Score");
                    int score = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type of score");
                    string type = Console.ReadLine();
                    Console.WriteLine("Thank you! Added " + name + "'s " + score + " scores to the " + type + " scorelist!");
                }
                if (command == "2")
                {
                    Console.WriteLine("Which person's score would you like to see");
                    string person = Console.ReadLine();
                    Console.WriteLine("Here are all the scores for " + person + ":");
                }
                if (command == "3")
                {
                    Console.WriteLine("Here are all the scores:");
                    
                    // Open a database connection
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                    m_dbConnection.Open();


                    // Read the data from the database
                    string sql = "SELECT * FROM Highscores ORDER BY score DESC";
                    SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"] + "\tType of score: " + reader["type"]);
                    }

                    // Close the connection
                    m_dbConnection.Close();
                }
            }
        }
    }
}
