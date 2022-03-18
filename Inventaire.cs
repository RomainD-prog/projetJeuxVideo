using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Inventaire
    {
        public int maxCapacity { get; set; }
        public int currentCapacity { get; set; }
        List<Item> items { get; set; }

        public Inventaire(int size)
        {
            maxCapacity = size;
            currentCapacity = 0;
            items = new List<Item>();
        }

        public void addConsusable(Consommable consumable)
        {
            if (currentCapacity + consumable.weight <= maxCapacity)
            {
                items.Add(consumable);
                currentCapacity = currentCapacity + consumable.weight;
            }
            else
            {
                Console.WriteLine("Place insuffisante dans l'inventaire pour cet item");
            }
        }

        public void addEquipment(Equipement equipment, Joueur player)
        {
            if (currentCapacity + equipment.weight <= maxCapacity)
            {
                items.Add(equipment);
                currentCapacity = currentCapacity + equipment.weight;
                switch (equipment.name)
                {
                    case "helmet":
                        player.Maxhealth = player.Maxhealth + equipment.value;
                        player.health = player.health + equipment.value;
                        break;
                    case "armour":
                        player.Maxhealth = player.Maxhealth + equipment.value;
                        player.health = player.health + equipment.value;
                        player.missRate++;
                        break;
                    case "glasses":
                        // double rate = eq.value / 100; /////////////////////////////////////////////////
                        player.criticalStrikeRate += 1;
                        player.missRate -= 1;
                        break;
                    case "handbag":
                        this.maxCapacity = this.maxCapacity + equipment.value;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Place insuffisante dans l'inventaire pour cet item");
            }

        }

        public void addWeapon(Arme weapon)
        {
            if (currentCapacity + weapon.weight <= maxCapacity)
            {
                items.Add(weapon);
                currentCapacity = currentCapacity + weapon.weight;
            }
            else
            {
                Console.WriteLine("Place insuffisante dans l'inventaire pour cet item");
            }
        }

        public List<Arme> listOfWeapons()
        {
            List<Arme> weapons = new List<Arme>();

            foreach (Item item in items)
            {
                if (item is Arme) weapons.Add((Arme)item);

            }

            return weapons;
        }

        public String[] arrayofWeaponsNames()
        {
            String[] weapons = new String[listOfWeapons().Count];

            for (int i = 0; i < weapons.Length; i++) weapons[i] = listOfWeapons()[i].ToString();

            return weapons;
        }

        public List<Consommable> listOfConsumables()
        {
            List<Consommable> consumables = new List<Consommable>();

            foreach (Item item in items)
            {
                if (item is Consommable) consumables.Add((Consommable)item);

            }

            return consumables;
        }

        public String[] arrayofRemainingConsumablesNames()
        {
            String[] consumables;
            int arraySize = 0;

            foreach (Consommable conso in listOfConsumables())
            {
                if (conso.quantity > 0) arraySize++;
            }

            if (arraySize > 0)
            {
                consumables = new String[arraySize];
                for (int i = 0; i < consumables.Length; i++)
                {
                    if (listOfConsumables()[i].quantity > 0) consumables[i] = listOfConsumables()[i].ToString();
                }
            }
            else
            {
                consumables = new String[] { "Aucun objet" };
            }

            return consumables;
        }

        public List<Equipement> listOfEquipment()
        {
            List<Equipement> equipments = new List<Equipement>();

            foreach (Item item in items)
            {
                if (item is Equipement) equipments.Add((Equipement)item);

            }

            return equipments;
        }

        public String[] arrayofEquipmentsNames()
        {
            String[] Equipments = new String[listOfEquipment().Count];

            for (int i = 0; i < Equipments.Length; i++) Equipments[i] = listOfEquipment()[i].name;

            return Equipments;
        }

        public void removeItem(Item item)
        {
            items.Remove(item);
        }
    }
}