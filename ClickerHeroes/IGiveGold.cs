using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    interface IGiveGold
    {
        void GiveGold(float fAmount, IHaveGold target);
    }
}
