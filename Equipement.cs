using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Equipement : Item
    {
        public int value;

        public Equipement(int val, String noon, int weight, int price) : base(noon, weight, price)
        {
            value = val;
        }

    }
}
