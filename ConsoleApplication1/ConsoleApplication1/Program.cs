using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Walker Krebs
 * Section 001
 * Group 10
 * 
 * This program allows users to enter the number of teams as well as team names and points. It then ranks the teams based on points. 
 * 
 */
namespace ConsoleApplication1
{
    class Team
    {
        public String name;
        public int wins;
        public int losses;
        public List<Game> lGames = new List<Game>();
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
            int iPoints = 0;
            bool bTest = true;
            List<SoccerTeam> lSoccerTeams = new List<SoccerTeam>();


            Console.Write("How many Teams? ");

            //test to make sure input is an integer
            while(bTest)
            {
                try
                {
                    sNumTeams = Console.ReadLine();
                    iNumberTeams = Convert.ToInt32(sNumTeams);
                    break;
                }
                catch
                {
                    Console.Write("Please enter an integer: ");
                }
            }

            //prompt for and record team names and points
            for(iCount1 = 0; iCount1 < iNumberTeams; iCount1++)
            {
                Console.Write("\nEnter Team " + (iCount1 + 1) + "'s name: ");
                sName = Console.ReadLine();

                sName = UppercaseFirst(sName);

                Console.Write("Enter " + sName + "'s points: ");

                //test for int
                while (bTest)
                {
                    try
                    {
                        sPoints = Console.ReadLine();
                        iPoints = Convert.ToInt32(sPoints);
                        bTest = false;
                        //break;
                    }
                    catch(Exception ex)
                    {
                        Console.Write("\nPlease enter an integer: ");
                    }
                  
                }


                lSoccerTeams.Add(new SoccerTeam(sName, iPoints));
            }

            //sort teams
            List<SoccerTeam> oSortedList = lSoccerTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

            //table header
            Console.WriteLine("\nHere is the sorted list:");
            Console.WriteLine(("\nPosition").PadRight(25, ' ') + ("Name").PadRight(25,' ') + ("Points"));
            Console.WriteLine(("--------").PadRight(24, ' ') + ("----").PadRight(25, ' ') + ("------"));

            //print results for each team
            iCount2 = 1;
            foreach (SoccerTeam teamPrint in oSortedList)
            {

                Console.Write(Convert.ToString(iCount2).PadRight(24, ' '));
                Console.Write(teamPrint.name.PadRight(26,' '));
                Console.WriteLine(Convert.ToString(teamPrint.points));
                iCount2++;
            }

            Console.Read();
        }
    }
}
