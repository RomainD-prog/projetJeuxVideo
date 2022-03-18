using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Joueur : Personnage
    {
        public int Maxhealth { get; set; }
        public int power { get; set; }
        public int money { get; set; }
        public int currentLine { get; set; }
        public int currentCol { get; set; }
        public bool hasTheKey { get; set; }
        public Inventaire inventory;


        public Joueur(int hp, int stren, int pow, int posLine, int posCol) : base(hp, stren)
        {
            Maxhealth = hp;
            power = pow;
            money = 150;
            criticalStrikeRate = 50;
            missRate = 20;
            currentLine = posLine;
            currentCol = posCol;
            hasTheKey = false;
            inventory = new Inventaire(500);
            inventory.addWeapon(new Arme(50, 10, false, "pistolet laser", 50, 100));
            inventory.addConsusable(new Consommable(50, "Boisson energisante", 0, 20, 3));
            inventory.addWeapon(new Arme(strength, 0, true, "coup de pied", 0, 0));
        }

        public void move(ref Salle[,] grid)
        {
            List<String> possibleDirections = new List<String>();
            possibleDirections = Initialisation.connectedRooms(grid, currentLine, currentCol);
            bool validChoice = false;
            String typeOfKey;


            Initialisation.revealConnectedRooms(possibleDirections, ref grid, currentLine, currentCol);
            Program.clearAndDisplayInterface(grid, this, true, Program.centerText("Vous pouvez changer de salle", " ") + "\n\n" + Program.header(""));


            while (!validChoice)
            {

                do
                {
                    typeOfKey = Program.typeOfKeyEntered(Console.ReadKey(true));
                }
                while (typeOfKey != "upArrow" && typeOfKey != "downArrow" && typeOfKey != "leftArrow" && typeOfKey != "rightArrow");

                if (possibleDirections.Contains(typeOfKey))
                {
                    switch (typeOfKey)
                    {
                        case "upArrow":
                            grid[currentLine, currentCol].containsPlayer = false;
                            currentLine -= 1;
                            validChoice = true;
                            grid[currentLine, currentCol].containsPlayer = true;
                            break;
                        case "downArrow":
                            grid[currentLine, currentCol].containsPlayer = false;
                            currentLine += 1;
                            validChoice = true;
                            grid[currentLine, currentCol].containsPlayer = true;
                            break;
                        case "leftArrow":
                            grid[currentLine, currentCol].containsPlayer = false;
                            currentCol -= 1;
                            validChoice = true;
                            grid[currentLine, currentCol].containsPlayer = true;
                            break;
                        case "rightArrow":
                            grid[currentLine, currentCol].containsPlayer = false;
                            currentCol += 1;
                            validChoice = true;
                            grid[currentLine, currentCol].containsPlayer = true;
                            break;
                    }
                }
                else
                {
                    Program.clearAndDisplayInterface(grid, this, true, Program.centerText("Vous pouvez changer de salle", " ") + "\n\n" + Program.centerText("Direction non valide", " ") + "\n\n" + Program.header(""));
                }
            }
        }

        public int attack(Personnage target, Arme weapon)
        {
            int damageVariation = (int)(weapon.damage * 0.2);
            Random rand = new Random();
            int strikeSuccess = rand.Next(1, 101);
            power -= weapon.powerCost;

            if (strikeSuccess <= missRate) return 0;

            else if (strikeSuccess > 100 - criticalStrikeRate)
            {
                return 2 * (rand.Next(weapon.damage - damageVariation, weapon.damage + damageVariation + 1));
            }
            else
            {
                return rand.Next(weapon.damage - damageVariation, weapon.damage + damageVariation + 1);
            }
        }

        public void buyItem(Item it)
        {

        }

        public void useConsumable(Consommable conso)
        {
            switch (conso.name)
            {
                case "Boisson energisante":
                    if (this.health + conso.value < this.Maxhealth)
                    {
                        this.health = this.health + conso.value;
                    }
                    else
                    {
                        this.health = this.Maxhealth;
                    }
                    break;
                case "Pillule de force":
                    this.strength = this.strength + conso.value;
                    break;
                case "Pillule de santé":
                    this.health = this.health + conso.value;
                    this.Maxhealth = this.Maxhealth + conso.value;
                    break;
                case "Energie":
                    this.power = this.power + conso.value;
                    break;
            }
            conso.quantity--;
        }
    }
}