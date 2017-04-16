using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    interface IDamageable
    {
        void MonsterTakeDamage(int amount, IHaveGold source);
    }
}
