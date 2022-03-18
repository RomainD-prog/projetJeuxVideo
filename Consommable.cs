using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Consommable : Item
    {
        public int value;
        public int quantity;
        public Consommable(int val, String noon, int weight, int price, int nb) : base(noon, weight, price)
        {
            value = val;
            quantity = nb;
        }

        public override string ToString()
        {
            String str = "";
            switch (name)
            {
                case "Boisson energisante":
                    str = name + ": +" + value + " de santé (reste " + quantity + ")";
                    break;
                case "Pillule de santé":
                    str = name + ": +" + value + " de santé maximum pour cet étage";
                    break;
                case "Pillule de force":
                    str = name + ": +" + value + " de force pour cet étage";
                    break;
            }
            return str;
        }
    }
}