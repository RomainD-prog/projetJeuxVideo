using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Ennemi : Personnage
    {


        public Ennemi(int hp, int stren) : base(hp, stren)
        {
            criticalStrikeRate = 15;
            missRate = 30;
        }

        public override String ToString()
        {
            String str = "Le disciple de Adler " + this.health + " points de vie";
            return str;

        }

        public int attack(Personnage target) // on affiche le montant des dommages causés
        {
            int damageVariation = (int)(strength * 0.2);
            Random rand = new Random();
            int strikeSuccess = rand.Next(1, 101);

            if (strikeSuccess <= missRate) return 0;

            else if (strikeSuccess > 30 - criticalStrikeRate)
            {
                return 2 * (rand.Next(strength - damageVariation, strength + damageVariation + 1));
            }
            else
            {
                return rand.Next(strength - damageVariation, strength + damageVariation + 1);
            }
        }
    }
}
