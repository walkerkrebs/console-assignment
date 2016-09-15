using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Walker Krebs
 * Section 001
 * Group 10
 * 9/14/2016
 * 
 * This program allows users to enter the number of teams as well as team names and points. It then ranks the teams based on points. 
 * The game class was implemented to keep track of the number of games played. Games played is a sample of the functionality. More features,
 * like a game ID, can be easily implemented.
 */
namespace ConsoleApplication1
{
    class Team
    {
        public String name;
        public int wins;
        public int losses;
        public Game ogame = new Game();
    }

    class SoccerTeam : Team
    {
        public int draw { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
        public int differential { get; set; }
        public int points { get; set; }

        public SoccerTeam(String sName, int iPoints)
        {
            this.name = sName;
            this.points = iPoints;
        }

        public SoccerTeam()
        {
        }
    }

    class Game
    {
        public int numgames { get; set; }
        public int gameID { get; set; }
        public bool homeTeam { get; set; }

        public Game()
        {
        }
    }

    class Program
    {
        // make first letter of team uppercase
         static string UppercaseFirst(string s)
        {
             // check for empty string
             if (string.IsNullOrEmpty(s))
             {
                 return string.Empty;
             }
             return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {
            int iNumberTeams = 0;
            int iCount1 = 0;
            int iCount2 = 0;
            String sName;
            String sNumTeams;
            String sPoints;
            String sGames;
            int iGames = 0;
            int iPoints = 0;
            bool bTest = true;
            List<SoccerTeam> lSoccerTeams = new List<SoccerTeam>();


            Console.Write("How many Teams? ");

            //test to make sure input is an integer greater than 0
            while(bTest)
            {
                try
                {
                    sNumTeams = Console.ReadLine();
                    iNumberTeams = Convert.ToInt32(sNumTeams);
                    if (iNumberTeams <= 0)
                    {
                        Convert.ToInt32("break");
                    }
                    bTest = false;
                }
                catch(Exception ex)
                {
                    Console.Write("Please enter an integer greater than 0: ");
                }
            }

            //prompt for and record team names and points
            for(iCount1 = 0; iCount1 < iNumberTeams; iCount1++)
            {
                Console.Write("\nEnter Team " + (iCount1 + 1) + "'s name: ");
                sName = Console.ReadLine();

                sName = UppercaseFirst(sName);

                Console.Write("How many games did " + sName + " play? ");
                
                //test for int
                bTest = true;
                while (bTest)
                {
                    try
                    {
                        
                        sGames = Console.ReadLine();
                        iGames = Convert.ToInt32(sGames);
                        if (iGames < 0)
                        {
                            Convert.ToInt32("break");
                        }
                        bTest = false;
                    }
                    catch (Exception ex)
                    {
                        Console.Write("\nPlease enter a positive integer: ");
                    }

                }
               
                Console.Write("Enter " + sName + "'s points: ");

                //test for int
                bTest = true;
                while (bTest)
                {
                    try
                    {                        
                        sPoints = Console.ReadLine();
                        iPoints = Convert.ToInt32(sPoints);
                        if(iPoints < 0)
                        {
                            Convert.ToInt32("break");
                        }
                        bTest = false;
                        
                    }
                    catch(Exception ex)
                    {
                        Console.Write("\nPlease enter a positive integer: ");
                    }
                  
                }


                lSoccerTeams.Add(new SoccerTeam(sName, iPoints));
                lSoccerTeams[iCount1].ogame.numgames = iGames;
            }

            //sort teams
            List<SoccerTeam> oSortedList = lSoccerTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

            //table header
            Console.WriteLine("\nHere is the sorted list:");
            Console.WriteLine(("\nPosition").PadRight(25, ' ') + ("Name").PadRight(25, ' ') + ("Games").PadRight(25, ' ') + ("Points").PadRight(25, ' '));
            Console.WriteLine(("--------").PadRight(24, ' ') + ("----").PadRight(25, ' ') + ("-----").PadRight(25, ' ') + ("------"));

            //print results for each team
            iCount2 = 1;
            foreach (SoccerTeam teamPrint in oSortedList)
            {

                Console.Write(Convert.ToString(iCount2).PadRight(24, ' '));                
                Console.Write(teamPrint.name.PadRight(26,' '));
                Console.Write(Convert.ToString(teamPrint.ogame.numgames).PadRight(25, ' '));
                Console.WriteLine(Convert.ToString(teamPrint.points));
                iCount2++;
            }

            Console.Read();
        }
    }
}
