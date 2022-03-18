using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Arme : Item
    {
        public int damage { get; set; }
        public int powerCost { get; set; }
        public bool meleeAttack { get; set; }
        public Arme(int dam, int cost, bool melee, String noun, int weight, int price) : base(noun, weight, price)
        {
            damage = dam;
            powerCost = cost;
            meleeAttack = melee;
        }

        public override string ToString()
        {
            String str = name + ": " + damage + " dégats prévus, " + powerCost + " d'énergie requis";

            return str;
        }
    }
}