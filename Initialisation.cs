using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Initialisation
    {
        public enum Direction { upArrow, downArrow, rightArrow, leftArrow }


        public struct Point
        {
            public int lin;
            public int col;

            public Point(int l, int c)
            {
                lin = l;
                col = c;
            }
        }

        public static char[,] createWorld(char[,] grid)
        {
            int roomNumber = 0; // max 25
            //int bossNumber = 0; // max 1
            //int shopNumber = 0; // max 1
            //int healNumber = 0; // max 1
            //int exitNumber = 0; // max 1

            List<int> listRoomsToBuild = new List<int>();

            List<Point> listPositions = new List<Point>();

            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);  // créer une heure actuelle en fonction du nombre aléatoire
            int rand;

            fillGridWithVacantPositions(ref grid);

            rand = r.Next(1, 4);
            grid[0, rand] = Constants.player;  // définir le personnage à une position aléatoire dans la première ligne, à part la première et la dernière position
            listPositions.Add(new Point(0, rand));  // on ajoute cette pièce à une liste de points avec ses coordonnées

            do
            {

                if (grid[listPositions[listPositions.Count - 1].lin, listPositions[listPositions.Count - 1].col] == Constants.player)
                {
                    Point tempPoint;
                    int numberOfConnetion;

                    do
                    {
                        rand = r.Next(0, listPositions.Count);  // un nouveau chemin commencera à partir d'un point aléatoire parmi les 5 précédemment créés
                        tempPoint = listPositions[rand];
                        numberOfConnetion = vacantConnectedPositions(grid, tempPoint.lin, tempPoint.col).Count;
                    } while (numberOfConnetion < 1);   // le nouveau point doit avoir au moins une case affectée autour 

                    listPositions = new List<Point>();   // la liste des points est réinitialisée
                    listPositions.Add(tempPoint);  // le point aléatoire choisi est affecté à la liste

                }

                for (int i = 0; i < 5; i++)  // on crée un chemin de 5 salles aléatoires
                {
                    int lin = listPositions[listPositions.Count - 1].lin;  // on récupére la ligne de la dernière pièce créée dans la liste de positions
                    int col = listPositions[listPositions.Count - 1].col;  // et sa colomne

                    listRoomsToBuild = vacantConnectedPositions(grid, lin, col);  //on récupére la liste des codes de direction référencés aux pièces possibles à construire
                    rand = r.Next(0, listRoomsToBuild.Count);  // on spécifie une direction aléatoire pour créer une pièce parmi celles possibles


                    ////// PROBELEME ICI
                    buildRoom(ref grid, lin, col, listRoomsToBuild[rand], Constants.fight); // on construit une salle à cette position
                                                                                            //////



                    addToPointList(ref listPositions, lin, col, listRoomsToBuild[rand]);  // Les coodonnées de cette salle sont ajoutées comme a point dans la liste
                }
            } while (roomNumber < 10);  // 25
            Console.WriteLine("il y a {0} salles", roomNumber); /////////////////////////////////////////////////


 

            return grid;
        }

        public static void fillGridWithVacantPositions(ref char[,] grid)
        {
            for (int i = 0; i < Constants.ymax; i++)
            {
                for (int j = 0; j < Constants.xmax; j++)
                {
                    grid[i, j] = Constants.vacant;
                }
            }
        }

        public static List<String> connectedRooms(Salle[,] grid, int lin, int col)
        {
            List<String> a = new List<String>();

            if (lin == 0)  // first line
            {
                if (col == 0)  // first col, first line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                }
                else if (col == Constants.xmax - 1)  // last col, first line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
                else  // any col, first line line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
            }
            else if (lin == Constants.ymax - 1)  // last line
            {
                if (col == 0)  // first col, last line
                {
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                }
                else if (col == Constants.xmax - 1)  // last col, last line
                {
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
                else  // any col, last line
                {
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
            }
            else  // any line
            {
                if (col == 0)  // first col, any line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                }
                else if (col == Constants.xmax - 1)  // last col, any line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
                else  // any col, any line
                {
                    if (grid[lin + 1, col].symbol != ' ') a.Add(Direction.downArrow.ToString());
                    if (grid[lin - 1, col].symbol != ' ') a.Add(Direction.upArrow.ToString());
                    if (grid[lin, col + 1].symbol != ' ') a.Add(Direction.rightArrow.ToString());
                    if (grid[lin, col - 1].symbol != ' ') a.Add(Direction.leftArrow.ToString());
                }
            }
            return a;
        }

        public static List<int> vacantConnectedPositions(char[,] grid, int lin, int col)
        {
            List<int> a = new List<int>(); // l'ordre dans la liste est organisé pour avoir le bas et la droite en premier afin de développer la génération de carte
            if (lin == 0)  // première ligne
            {
                if (col == 0)  // première colomne, premiere ligne
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                }
                else if (col == Constants.xmax - 1)  // dernière colomne, première ligne
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
                else  // any col, first line line
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
            }
            else if (lin == Constants.ymax - 1)  // dernière ligne
            {
                if (col == 0)  // première colomne, dernière ligne
                {
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                }
                else if (col == Constants.xmax - 1)  // derniere colomne, dernière ligne
                {
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
                else  // any col, last line
                {
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
            }
            else  // any line
            {
                if (col == 0)  // premiere colomne, toute ligne
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                }
                else if (col == Constants.xmax - 1)  // dernière colomne, toute ligne
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
                else  // any col, any line
                {
                    if (grid[lin + 1, col] == Constants.vacant) a.Add((int)Direction.downArrow);
                    if (grid[lin, col + 1] == Constants.vacant) a.Add((int)Direction.rightArrow);
                    if (grid[lin - 1, col] == Constants.vacant) a.Add((int)Direction.upArrow);
                    if (grid[lin, col - 1] == Constants.vacant) a.Add((int)Direction.leftArrow);
                }
            }

            return a;
        }

        public static void buildRoom(ref char[,] grid, int lin, int col, int dir, char type)
        {
            switch (dir)
            {
                case (int)Direction.upArrow:
                    grid[lin - 1, col] = type;
                    break;
                case (int)Direction.downArrow:
                    grid[lin + 1, col] = type;
                    break;
                case (int)Direction.rightArrow:
                    grid[lin, col + 1] = type;
                    break;
                case (int)Direction.leftArrow:
                    grid[lin, col - 1] = type;
                    break;
            }
        }

        public static void addToPointList(ref List<Point> list, int lin, int col, int dir)
        {
            switch (dir)
            {
                case (int)Direction.upArrow:
                    list.Add(new Point(lin - 1, col));
                    break;
                case (int)Direction.downArrow:
                    list.Add(new Point(lin + 1, col));
                    break;
                case (int)Direction.rightArrow:
                    list.Add(new Point(lin, col + 1));
                    break;
                case (int)Direction.leftArrow:
                    list.Add(new Point(lin, col - 1));
                    break;
            }
        }

        public static void display(char[,] grid)
        {
            for (int i = 0; i < Constants.ymax; i++)
            {
                for (int j = 0; j < Constants.xmax; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.Write("\n");
            }
        }

        public static void revealConnectedRooms(List<String> connectedRooms, ref Salle[,] grid, int lin, int col)
        {
            foreach (String room in connectedRooms)
            {
                switch (room)
                {
                    case "upArrow":
                        grid[lin - 1, col].visible = true;
                        break;
                    case "downArrow":
                        grid[lin + 1, col].visible = true;
                        break;
                    case "leftArrow":
                        grid[lin, col - 1].visible = true;
                        break;
                    case "rightArrow":
                        grid[lin, col + 1].visible = true;
                        break;
                }
            }

        }
    }

}