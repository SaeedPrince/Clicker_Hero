using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    class Input
    {
        // Variables
        private ConsoleKey cCurrentInput
        {
            get
            {
                ConsoleKey cReturn;
                do
                {
                    cReturn = Console.ReadKey(false).Key;
                } while (!IsValid(cReturn));
                return cReturn;
            }
        }
        private ConsoleKey[] cValidInputArray;
        public Input()
        {
            cValidInputArray = new ConsoleKey[] { ConsoleKey.Spacebar,ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5
            ,ConsoleKey.D6,ConsoleKey.D7,ConsoleKey.D8,ConsoleKey.D9,ConsoleKey.D0,ConsoleKey.OemPlus,ConsoleKey.OemMinus,ConsoleKey.Escape};
        }

        public ConsoleKey GetAnInput()
        {
            return cCurrentInput;
        }

        private bool IsValid(ConsoleKey cInput)
        {
            bool bReturn = false;
            for (int i=0;i<cValidInputArray.Length;i++)
            {
                if (cValidInputArray[i]==cInput)
                {
                    bReturn = true;
                    break;
                }
            }
            return bReturn;
        }

    }
}
