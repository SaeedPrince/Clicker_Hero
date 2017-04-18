using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClickerHeroes
{
    class Screen
    {
        // Constants
        public const int SCREEN_WIDTH = 230;
        public const int SCREEN_HEIGHT = 60;

        // Constructors
        public Screen()
        {

        }


        // Public methods
        public void SimpleScreenShow(string sAction, string sFeedback, Hero[] inpHero, float inpGold, Level inpLevel, Monster inpMonster)
        {
            // will be replaced by ComplexScreenShow
            Console.Clear();
            Console.WriteLine("You choosed to {0}.", sAction);
            Console.WriteLine("{0}", sFeedback);
            Console.WriteLine("Gold={0}", inpGold);
            Console.WriteLine("Heroes:");
            int iSumDmgClick = 0;
            int iSumDmgSecond = 0;
            for (int i = 0; i < inpHero.Length; i++)
            {
                Console.WriteLine("{0}- Name:{1}    Damage Per Click:{2}    Damage Per Second:{3}    Level:{4}    GoldNeed:{5}", i + 1, inpHero[i].GetName(), inpHero[i].iCurrentDamagePerClick, inpHero[i].iCurrentDamagePerSecond, inpHero[i].GetLevel(), inpHero[i].fGoldNeedToUpgrade);
                iSumDmgClick += inpHero[i].iCurrentDamagePerClick;
                iSumDmgSecond += inpHero[i].iCurrentDamagePerSecond;
            }
            Console.WriteLine("Damage Per Click Summary:{0}    Damage Per Second Summary:{1}", iSumDmgClick, iSumDmgSecond);
            Console.WriteLine("Monster:");
            Console.WriteLine("Name:{0}    HP:{1}", inpMonster.getMonsterName(), inpMonster.getMonsterLife());
            Console.WriteLine("Level:{0} {1}    MonsterBeenKilled:{2}", inpLevel.getActualLvl(), inpLevel.sMapName, inpLevel.getNumbersOfMonsterKilled());
        }

        public void ComplexScreenShow(string sAction, string sFeedback, Hero[] inpHero, float inpGold, Level inpLevel, Monster inpMonster)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*-------------- Player Infos ------------------*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("* GOLD: {0}  ||  LEVEL: {1} || MONSTER IN LVL: {2}",inpGold,inpLevel.getActualLvl(),inpMonster.getMonsterName());
            Console.WriteLine("                                                  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*-------------- Heros to Upgrade --------------*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*                                              ");
            Console.WriteLine("*{0}                                           ",inpHero[0].GetName());
           
            //Saee Here we can see first with is possible to buy the hero before print on the screen on heros to upgrade.
            //Im trying to figure it out how we can clear the console and print it this again, i tried to use the program class loop that you did
            //but its not working.
        }

        public void ShowPlayerInstructions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*- Welcome to Clicker Hero Game! -*\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("How to play : Use keyboard numbers to select wich Hero\nyou want to upgrade based on how much of gold you have.\n");
            Console.WriteLine("Instructions : 1,2,3,4,5,6,7,8,9,0 to upgrade specific hero.");
            Console.WriteLine("Instructions:: spacebar to hit monsters.");
            ShowCountDown(15);
            Console.Clear();
        }

        public void ShowCountDown(int value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            while (value >= 0)
            {
                Console.WriteLine("\nGame will begin in {0} sec..", value);
                Thread.Sleep(1000);
                value--;
                ClearLastLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
