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
            Game theGame;
            Input theInput;
            Player thePlayer;
            Level theLevel;
            theGame = new Game();
            thePlayer = theGame.GetPlayer();
            theLevel = theGame.GetLevel();
            string sActionFeedback = "";
            do
            {
                if(!bTimerAlreadyEnabled && thePlayer.bHaveAnyDamagePerSecondHero)
                {
                    bTimerAlreadyEnabled = true;
                    SetTimer(theGame);
                }
                theInput = new Input();
                theGame.SetInput(theInput.GetAnInput());
                sActionFeedback = theGame.DoAction();
                theGame.GetScreen().SimpleScreenShow(theGame.sCombineAction, sActionFeedback, thePlayer.GetHeroArray(), thePlayer.GetGold(), theLevel, theLevel.getActive_Monster());
            } while (true);

            // End of program
            Console.ReadLine();
        }

        private static void SetTimer(Game theGame)
        {
            // Create a timer with a two second interval.
            Timer aTimer = new Timer(TIME_MILI_SECONDS);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += (sender, e) => OnTimedEvent(sender, e, theGame);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e,Game theGame)
        {
            Player thePlayer;
            Level theLevel;
            thePlayer = theGame.GetPlayer();
            theLevel = theGame.GetLevel();
            string sActionFeedback = "";
            theGame.ClearInput();
            sActionFeedback = theGame.DoAction();
            theGame.GetScreen().SimpleScreenShow(theGame.sCombineAction, sActionFeedback, thePlayer.GetHeroArray(), thePlayer.GetGold(), theLevel, theLevel.getActive_Monster());
        }
    }
}
