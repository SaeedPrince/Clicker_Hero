using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes
{
    interface IDealDamage
    {
        void DealDamage(int amount, IDamageable target, IHaveGold source);
    }
}
