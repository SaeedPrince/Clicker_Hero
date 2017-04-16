using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    class Player : IHaveGold, IDealDamage
    {
        // Constants
        public const int HERO_MAX_COUNT = 10;
        public const int HERO_DAMAGE_PER_CLICK_INDEX = 0;
        public const int HERO_DAMAGE_PER_SECOND_INDEX_START = 1;
        // Variables
        private Hero[] hero;
        public int iDamagePerClick
        {
            get
            {
                return hero[HERO_DAMAGE_PER_CLICK_INDEX].iCurrentDamagePerClick;
            }
        }
        public int iDamagePerSecond
        {
            get
            {
                int iSumDamage = 0;
                for (int i = HERO_DAMAGE_PER_SECOND_INDEX_START; i < hero.Length; i++)
                {
                    iSumDamage += hero[i].iCurrentDamagePerSecond;
                }
                return iSumDamage;
            }
        }
        private float fGold;
        public bool bHaveAnyDamagePerSecondHero
        {
            get
            {
                bool bReturn = false;
                for (int i=HERO_DAMAGE_PER_SECOND_INDEX_START;i<hero.Length;i++)
                {
                    if(hero[i].GetLevel()>0)
                    {
                        bReturn = true;
                        break;
                    }
                }
                return bReturn;
            }
        }
        
        // Constructor
        public Player()
        {
            fGold = 0;
            hero = new Hero[HERO_MAX_COUNT];
            for (int i = 0; i < HERO_MAX_COUNT; i++)
            {
                hero[i] = new Hero(i);
            }
            hero[0].Upgrade();
        }
        
        // Getters
        public Hero[] GetHeroArray()
        {
            return hero;
        }

        public float GetGold()
        {
            return fGold;
        }

        // Public method
        public bool HeroUpgrade(int iHeroIndex)
        {
            bool bReturn = false;
            if (fGold>=hero[iHeroIndex].fGoldNeedToUpgrade)
            {
                fGold -= hero[iHeroIndex].fGoldNeedToUpgrade;
                hero[iHeroIndex].Upgrade();
                bReturn = true;
            }
            return bReturn;
        }


        // Interfaces
        public void TakeGold(float fAmount)
        {
            fGold += fAmount;
        }

        public void DealDamage(int amount, IDamageable target,IHaveGold source)
        {
            target.MonsterTakeDamage(amount,source);
        }
    }
}
