using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Boss : Ennemi
    {
        public int power;
        public Boss(int hp, int stre, int pow) : base(hp, stre)
        {
            power = pow;
            criticalStrikeRate = 30;
            missRate = 30;
        }
    }
}
