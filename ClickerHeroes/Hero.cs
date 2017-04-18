using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    class Hero
    {
        // Constants
        public const int BASIC_HERO_TYPE = 0;
        public const int BASIC_HERO_DAMAGE = 1;
        public const float BASE_GOLD_NEED = 25;
        // Variables
        private string sName;
        private int iLevel;
        private int iType;                      // can be set between 0 to 9
        private int iBaseDamagePerClick;
        private int iBaseDamagePerSecond;
        public int iCurrentDamagePerClick
        {
            get
            {
                return iLevel * iBaseDamagePerClick;
            }
        }
        public int iCurrentDamagePerSecond
        {
            get
            {
                return iLevel * iBaseDamagePerSecond;
            }
        }
        public float fGoldNeedToUpgrade
        {
            get
            {
                return BASE_GOLD_NEED * (iLevel+1) * (iType+1);
            }
        }
        // Constructors
        public Hero(int iHeroType)
        {
            string[] HeroName = new string[] { "Cid   ", "TreBea", "Brawlr", "Prince", "Fisher", "Cliker", "Samuri", "Leon  ", "Seer  ", "Blades" };
            sName = HeroName[iHeroType];
            iType = iHeroType;
            iLevel = 0;
            // Only first hero type can make damage per click. The rest of heroes make damage per second.
            if (iHeroType == BASIC_HERO_TYPE)
            {
                iBaseDamagePerClick = BASIC_HERO_DAMAGE;
                iBaseDamagePerSecond = 0;
            }
            else
            {
                iBaseDamagePerClick = 0;
                iBaseDamagePerSecond = iHeroType;
            }
        }
        // Getters
        public string GetName()
        {
            return sName;
        }

        public int GetHeroType()
        {
            return iType;
        }

        public int GetLevel()
        {
            return iLevel;
        }

        // Public methods
        public void Upgrade()
        {
            iLevel++;
        }
        // Private Functions

        // Interfaces

    }
}
