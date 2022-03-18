using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Item
    {
        public String name { get; set; }
        public int weight { get; set; }
        public int price { get; set; }
        public bool equipped { get; set; }

        public Item(String noun, int wei)
        {
            name = noun;
            weight = wei;
            equipped = false;
        }

        public Item(String noun, int wei, int cost)
        {
            name = noun;
            weight = wei;
            price = cost;
            equipped = false;
        }
    }
}