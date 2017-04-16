using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    class Level : IDamageable, IGiveGold
    {
        // Constants
        public const int MAX_MONSTERS_PER_LEVEL = 10;

        //Monster in Lvl
        private Monster m_ActiveMonster;
        private int m_MonstersKilled;

        //Strings
        private string[] sMapNamesArray = { "Tutorial", "Tundra", "Desert", "Mom's City", "Jungle", "Beach", "Dark Desert", "Ocean", "Heaven", "Hell" };
        public string sMapName
        {
            get
            {
                return sMapNamesArray[m_iActualLevelLvl / 10];
            }
        }

        //Integers
        private int m_iActualLevelLvl;

        //Booleans
        public bool m_bIsLevelEnded
        {
            get
            {
                bool bReturn = false;
                if (m_MonstersKilled >= MAX_MONSTERS_PER_LEVEL)
                {
                    bReturn = true;
                }
                return bReturn;
            }
        }

        //Level Constructor ************************************************************************************************************
        public Level()
        {
            m_ActiveMonster = new Monster(m_iActualLevelLvl);
            m_iActualLevelLvl = 1;
            m_MonstersKilled = 0;

        }
        //******************************************************************************************************************************

        public void killMonsterInLvl()
        {
            if (m_MonstersKilled < MAX_MONSTERS_PER_LEVEL)
            {
                m_ActiveMonster = null;
                m_MonstersKilled++;
                m_ActiveMonster = new Monster(m_iActualLevelLvl);
            }
            else
            {
                goNextLevel();
            }



        }



        //*******************************************************************************************************************************

        // Getters **********************************************************************************************************************

        public int getActualLvl()
        {
            return m_iActualLevelLvl;
        }

        public Monster getActive_Monster()
        {
            return m_ActiveMonster;
        }

        public int getNumbersOfMonsterKilled()
        {
            return m_MonstersKilled;
        }

        //  *****************************************************************************************************************************


        // Setters **********************************************************************************************************************

        public bool goNextLevel()
        {
            // Here we can create an dificulty constant using Hero and Player Class
            // To set a lvl we need some simple math like:
            // Difficult_Constant = totalOfherosActive + playerdamage + TotalDPS / Magic number.
            // We can use that constant to create a new lvl with new monsters dificulties each time the player pass an lvl.
            bool bReturn = false;
            if (m_bIsLevelEnded)
            {
                m_iActualLevelLvl++;
                m_MonstersKilled = 0;
                Monster new_Monster = new Monster(m_iActualLevelLvl);
                m_ActiveMonster = new_Monster;
                bReturn = true;
            }
            /*
            else
            {
                Console.WriteLine("Need to kill all monsters first.");
            }
            */
            return bReturn;
        }

        public bool goPreviousLevel()
        {
            bool bReturn = false;
            if (m_iActualLevelLvl>1)
            {
                m_iActualLevelLvl--;
                m_MonstersKilled = 0;
                Monster new_Monster = new Monster(m_iActualLevelLvl);
                m_ActiveMonster = new_Monster;
                bReturn = true;
            }
            return bReturn;
        }

        //  *****************************************************************************************************************************

        // Take Damage ******************************************************************************************************************

        public void MonsterTakeDamage(int amount, IHaveGold source)
        {
            Monster theMonster = getActive_Monster();
            if (theMonster.isMonsterAlive())
            {
                theMonster.SetMonsterLife(theMonster.getMonsterLife() - amount);
            }
            if (theMonster.getMonsterLife() <= 0)
            {
                //m_bIsAlive = false;
                GiveGold(theMonster.m_fMonsterLoot, source);
                //m_ActiveMonster = null;
                m_MonstersKilled++;
                m_ActiveMonster = new Monster(m_iActualLevelLvl);
            }
        }

        // Give Gold
        public void GiveGold(float fAmount, IHaveGold target)
        {
            target.TakeGold(fAmount);
        }

    }
}
