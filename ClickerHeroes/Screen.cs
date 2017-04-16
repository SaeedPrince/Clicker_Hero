using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
