using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    class Game
    {
        // Constants
        public const int ACTION_CLICK = 1;
        public const int ACTION_UPGRADE_HERO = 2;
        public const int ACTION_CHANGE_LEVEL = 3;
        public const int ACTION_SECOND = 4;
        public const int PARAMETER_PLUS = 10;
        public const int PARAMETER_MINUS = 11;
        public const int KEY_MINUS = 49;
        public const int FEEDBACK_SUCCESS = 0;
        public const int FEEDBACK_KILL_MONTSERS_FIRST = 1;
        public const int FEEDBACK_NOT_ENOUGH_GOLD = 2;
        public const int FEEDBACK_FIRST_LEVEL = 3;
        // Variables
        private Player myPlayer;
        private Screen myScreen;
        private Audio myAudio;
        private Level myLevel;
        public ConsoleKey cCurrentInput;
        private int iAction
        {
            get
            {
                int iReturn = 0;
                switch (cCurrentInput)
                {
                    case ConsoleKey.Spacebar :
                        iReturn = ACTION_CLICK;
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        iReturn = ACTION_UPGRADE_HERO;
                        break;
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.OemMinus:
                        iReturn = ACTION_CHANGE_LEVEL;
                        break;
                    default:
                        iReturn = ACTION_SECOND;
                        break;
                }
                return iReturn;
            }
        }
        private int iParameter
        {
            get
            {
                int iReturn=-1;
                switch (cCurrentInput)
                {
                    case ConsoleKey.D0:
                        iReturn = 9;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        iReturn = Convert.ToInt32(cCurrentInput)-KEY_MINUS;
                        break;
                    case ConsoleKey.OemPlus:
                        iReturn = PARAMETER_PLUS;
                        break;
                    case ConsoleKey.OemMinus:
                        iReturn = PARAMETER_MINUS;
                        break;
                }
                return iReturn;
            }
        }
        public string sCombineAction
        {
            get
            {
                string sReturn="";
                switch (iAction)
                {
                    case ACTION_CLICK:
                        sReturn = "Click";
                        break;
                    case ACTION_UPGRADE_HERO:
                        sReturn = "Upgrade hero";
                        break;
                    case ACTION_CHANGE_LEVEL:
                        sReturn = "Change level";
                        break;
                }

                return sReturn;
            }
        }
        public string[] sActionFeedbacks;
        // Constructors
        public Game()
        {
            myPlayer = new Player();
            myScreen = new Screen();
            myAudio = new Audio();
            myLevel = new Level();
            sActionFeedbacks = new string[] { "Action Done.", "You need to kill all the monsters first.", "Not enough gold.", "You are at the first level." };
        }
        
        // Getters
        public Screen GetScreen()
        {
            return myScreen;
        }

        public Player GetPlayer()
        {
            return myPlayer;
        }

        public Level GetLevel()
        {
            return myLevel;
        }

        // Setters
        public void SetInput(ConsoleKey cInput)
        {
            cCurrentInput = cInput;
        }

        public void ClearInput()
        {
            cCurrentInput = ConsoleKey.Clear;
        }

        // Public methods
        public string DoAction()
        {
            string sReturn = "";
            switch (iAction)
            {
                case ACTION_CLICK:
                    myPlayer.DealDamage(myPlayer.iDamagePerClick, myLevel, myPlayer);
                    sReturn = sActionFeedbacks[FEEDBACK_SUCCESS];
                    break;
                case ACTION_SECOND:
                    myPlayer.DealDamage(myPlayer.iDamagePerSecond, myLevel, myPlayer);
                    break;
                case ACTION_UPGRADE_HERO:
                    if (myPlayer.HeroUpgrade(iParameter))
                    {
                        sReturn = sActionFeedbacks[FEEDBACK_SUCCESS];
                    }
                    else
                    {
                        sReturn = sActionFeedbacks[FEEDBACK_NOT_ENOUGH_GOLD];
                    }
                    break;
                case ACTION_CHANGE_LEVEL:
                    if (iParameter == PARAMETER_PLUS)
                    {
                        if (myLevel.goNextLevel())
                        {
                            sReturn = sActionFeedbacks[FEEDBACK_SUCCESS];
                        }
                        else
                        {
                            sReturn = sActionFeedbacks[FEEDBACK_KILL_MONTSERS_FIRST];
                        }
                    }
                    else if(iParameter == PARAMETER_MINUS)
                    {
                        if (myLevel.goPreviousLevel())
                        {
                            sReturn = sActionFeedbacks[FEEDBACK_SUCCESS];
                        }
                        else
                        {
                            sReturn = sActionFeedbacks[FEEDBACK_FIRST_LEVEL];
                        }
                    }
                    break;
            }
            return sReturn;
        }

    }
}
