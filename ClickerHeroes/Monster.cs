using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClickerHeroes
{
    /*
     How this class works?
        When Level Class instatiate a Monster class, Level needs to pass the map_lvl to Monster constructor.
     */

    class Monster 
    {
        // Constants
        public int BASE_MONSTER_LIFE = 30;
        public int BASE_MONSTER_LOOT = 15;
        //Array of possible monster names
        private string[] m_MonsterNames = {"Rat","Crazy-B","Fat Dog","Frogy","Big Foot","Nassy","Curly","Yomama","Puririn","ShalOt","Sleepy",
                                   "Pikachu","Freak Bob","Gordon","Jack Killer","MarcoPolo","Alf","Altas","Samuray Jack","Stinky Pope",
                                   "Bloody Mary","Beer","Tequila"};


        /*Monster Variables===================================================================*/
        //Timer for BOSS
        private float m_Timer;

        //Monster name
        private string m_sName;

        //Monster status float
        private float m_fLife;
        private int m_iLevel;
        // Need Hero and Player to get good math
        public float m_fMonsterLoot
        {
            get
            {
                return BASE_MONSTER_LOOT * m_iLevel;
            }
        }

        //Pet status booleans
        private bool m_bIsAlive;

        //===================================================================*/

        //Monster Constructor
        public Monster(int map_lvl)
        {
            CreateNewMonster(map_lvl);
        }

        private void CreateNewMonster(int map_lvl)
        {
            Random rnd = new Random();
            Thread.Sleep(15);
            int rndNameIndex = rnd.Next(0, m_MonsterNames.Length);

            m_sName = m_MonsterNames[rndNameIndex];
            m_fLife = BASE_MONSTER_LIFE*map_lvl;
            m_iLevel = map_lvl;
            m_bIsAlive = true;
        }

        // Checkers *********************************************************************************************************************

        public bool isMonsterDied()
        {
            if (m_fLife <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //*******************************************************************************************************************************

        // Getters *********************************************************************************************************************

        public string getMonsterName()
        {
            return m_sName;
        }

        public float getMonsterLife()
        {
            return m_fLife;
        }

        public bool isMonsterAlive()
        {
            return m_bIsAlive;
        }


        // Setters *****************************************************************************************************************************
        public void SetMonsterLife(float fLife)
        {
            m_fLife = fLife;
        }


    }
}
