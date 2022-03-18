using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class BossSalle : SalleCombat
    {
        // new boss

        public BossSalle(bool isARoom) : base(false, isARoom)
        {
            symbol = 'B';
            visible = false; //on initialise à false par la suite car invisible au départ
            containsPlayer = false;
            // new boss
        }


        public override void displayRoomOnMap()
        {
            if (visible)
            {
                if (containsPlayer)
                {
                    Program.setColorAndDrawRoom(ConsoleColor.Cyan, 'P');
                }
                else
                {
                    Program.setColorAndDrawRoom(ConsoleColor.Red, symbol);
                }
            }
            else
            {
                Console.Write(' ');
                Console.Write(" | ");
            }
        }
    }
}
