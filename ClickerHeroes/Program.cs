using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClickerHeroes
{
    /*
    New features will be: 
    1- Complex Screen
    2- Audio
    3- Boss
    */
    class Program
    {
        const int TIME_MILI_SECONDS = 1000;
        static void Main(string[] args)
        {
            // Constants
            bool bTimerAlreadyEnabled = false;
            const int GAME_STATUS_CONTINUE = 1;
            const int GAME_STATUS_QUIT = 2;
            int iGameStatus = GAME_STATUS_CONTINUE;
            Game theGame;
            Input theInput;
            Player thePlayer;
            Level theLevel;
            theGame = new Game();
            thePlayer = theGame.GetPlayer();
            theLevel = theGame.GetLevel();
            string sActionFeedback = "";
            theGame.GetScreen().ShowPlayerInstructions();
            do
            {
                if (!bTimerAlreadyEnabled && thePlayer.bHaveAnyDamagePerSecondHero)
                {
                    bTimerAlreadyEnabled = true;
                    SetTimer(theGame,iGameStatus);
                }
                theInput = new Input();
                theGame.SetInput(theInput.GetAnInput());
                sActionFeedback = theGame.DoAction();
                if (sActionFeedback=="QUIT")
                {
                    iGameStatus = GAME_STATUS_QUIT;
                }
                theGame.GetScreen().SimpleScreenShow(iGameStatus , theGame.sCombineAction, sActionFeedback, thePlayer.GetHeroArray(), thePlayer.GetGold(), theLevel, theLevel.getActive_Monster());
            } while (iGameStatus==GAME_STATUS_CONTINUE);

            // End of program
            Console.ReadLine();
        }

        private static void SetTimer(Game theGame, int gameStatus)
        {
            // Create a timer with a two second interval.
            Timer aTimer = new Timer(TIME_MILI_SECONDS);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += (sender, e) => OnTimedEvent(sender, e, theGame,gameStatus);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e,Game theGame, int gameStatus)
        {
            Player thePlayer;
            Level theLevel;
            thePlayer = theGame.GetPlayer();
            theLevel = theGame.GetLevel();
            string sActionFeedback = "";
            theGame.ClearInput();
            sActionFeedback = theGame.DoAction();
            theGame.GetScreen().SimpleScreenShow(gameStatus,theGame.sCombineAction, sActionFeedback, thePlayer.GetHeroArray(), thePlayer.GetGold(), theLevel, theLevel.getActive_Monster());
        }
    }
}
