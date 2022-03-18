using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Constants
    {
        public readonly static int DungeonHeight = 20;
        public readonly static int xmax = 10;
        public readonly static int ymax = 10;
        public readonly static int gridSize = 10;
        public readonly static int heightConsole = 50;
        public readonly static int widthConsole = 100;

        public readonly static char player = 'p';
        public readonly static char vacant = '.';
        public readonly static char fight = 'x';
        public readonly static char boss = 'b';
        public readonly static char shop = 's';
        public readonly static char heal = 'h';
        public readonly static char exit = 'o';

        public readonly static ConsoleColor MonsterColor = ConsoleColor.Blue;
        public readonly static ConsoleColor TileColor = ConsoleColor.White;
        public readonly static String InvalidCommandText = "That is not a valid command";
        public readonly static String OKCommandText = "OK";

        // Histoire et instructions
        public readonly static String storyPart1 = "\n\n"
            + Program.centerText("En l'an 2132, le Soleil s'est considérablement rapproché de la Terre,", " ") + "\n"
            + Program.centerText("et a détruit les élements de l'atmosphère terrestre, qui constituaient également .", " ") + "\n"
            + Program.centerText("une barrière à bon nombre de menaces extraterrestres", " ") + "\n\n"
            + Program.centerText("Ceci étant, cette absence de protection atmosphérique fut à l'origine", " ") + "\n"
            + Program.centerText("d'un virus extremement contagieux, le Watbilaï, qui" , " ") + "\n"
            + Program.centerText("attaque les cellules du cerveau humain et rend les sujets affamés", " ") + "\n"
            + Program.centerText("de la chair de ceux qui n'ont pas été encore infectés.", " ") + "\n"
            + Program.centerText("Le monde est désormais dominé par la violence et la peur,", " ") + "\n\n"
            + Program.centerText("des milliers de groupes d'humains faibles se sont rassemblés", " ") + "\n"
            + Program.centerText("pour former des gangs ultras-violent prêt à tout pour survivre et isolés dans des", " ") + "\n"
            + Program.centerText("forteresses sécurisées. Des armes sophistiquées et mortelles", " ") + "\n"
            + Program.centerText("ont ainsi été conçues. Dans le même temps, des pilules rendant surpuissant", " ") + "\n"
            + Program.centerText("et des implants ont été mis au point pour booster les performances humaines.", " ") + "\n\n"
            + Program.centerText("La Terre étant au bord de l’asphyxie, un projet titanesque commun", " ") + "\n"
            + Program.centerText("aux plus puissantes forteresses a vu le jour afin de partir à la recherche", " ") + "\n"
            + Program.centerText("d’une nouvelle planète habitable et ainsi prendre un “nouveau départ”.", " ") + "\n"
            + Program.centerText("Un vaisseau gigantesque a donc été construit dans le but de lancer", " ") + "\n"
            + Program.centerText("une nouvelle conquête spatiale, pour fuire la situation sur Terre. ", " ") + "\n\n"
            + Program.centerText("La plupart des tickets pour l'espace ont été mis en vente à prix d'or", " ") + "\n"
            + Program.centerText("et les cent derniers ont quant à eux été offert à cent familles du peuple", " ") + "\n"
            + Program.centerText("à l'issue d'un grand tirage au sort international. Malheureusement,", " ") + "\n"
            + Program.centerText("ces places furent volées un mois avant le départ", " ") + "\n"
            + Program.centerText("et il fut impossible de remettre la main dessus.", " ") + "\n\n\n\n"
            + Program.centerText("APPUYEZ SUR UNE TOUCHE POUR CONTINUER", " ");

        public readonly static String storyPart2 = "\n\n\n\n"
            + Program.centerText("Cette aventure est celle de Zack Efron, un homme solitaire qui", " ") + "\n"
            + Program.centerText("vit toujours à l’air libre et qui avait été tiré au sort", " ") + "\n"
            + Program.centerText("pour quitter la Terre.", " ") + "\n\n"
            + Program.centerText("Ancien agent de sécurité dans des forteresse, il a été renvoyé", " ") + "\n"
            + Program.centerText("à de nombreuses reprises, refusant l'oligarchie imposée", " ") + "\n"
            + Program.centerText("dans chacune de celle-ci. De ce fait,", " ") + "\n"
            + Program.centerText("il connaît bien leur fonctionnement.", " ") + "\n\n"
            + Program.centerText("Après une semaine d'enquête il apprit que Adler ", " ") + "\n"
            + Program.centerText("(un des plus malveillants oligarques)", " ") + "\n"
            + Program.centerText("se cache derrière le larcin. Il prépare secrètement une centaine", " ") + "\n"
            + Program.centerText("de ses hommes au voyage dans l’espace dans le but de prendre", " ") + "\n"
            + Program.centerText("le contrôle du vaisseau.", " ") + "\n\n"
            + Program.centerText("Grâce à ses connaissances du milieux, Zack Efron est parvenu", " ") + "\n"
            + Program.centerText("à s'infiltrer dans la forteresse de Adler", " ") + "\n"
            + Program.centerText("et ne reviendra qu’avec les tickets vers un nouveau monde.", " ") + "\n\n\n\n"
            + Program.centerText("APPUYEZ SUR UNE TOUCHE POUR CONTINUER", " ");

        public readonly static String instructions = "\n\n"
            + Program.centerText("INSTRUCTIONS", " ") + "\n\n\n"
            + Program.centerText("La forteresse est constituée de plusieurs étages.", " ") + "\n"
            + Program.centerText("Votre but est de les traverser afin d'arriver jusqu'à Adler.", " ") + "\n\n"
            + Program.centerText("Pour pouvoir accéder à l'étage supérieur, vous devrez trouver la sortie, ", " ") + "\n"
            + Program.centerText("ainsi que sa clé. Il n'y a qu'une seule clé par étage,", " ") + "\n"
            + Program.centerText("et elle est détenue par un disciple de Adler.", " ") + "\n\n"
            + Program.centerText("A chaque étage, vous pourrez trouver un marchand, une infirmerie et un boss.", " ") + "\n"
            + Program.centerText("Combattre le boss n'est pas indispensable à l'avancée de", " ") + "\n"
            + Program.centerText("l'aventure, mais le vaincre vous permettra d'obtenir une belle récompense.", " ") + "\n\n"
            + Program.centerText("Attention tout de même, les étages sont truffés de disciples", " ") + "\n"
            + Program.centerText("de Adler prêts à vous barrer la route.", " ") + "\n\n"
            + Program.centerText("A chaque tour vous pourrez vous déplacez de salle en salle", " ") + "\n"
            + Program.centerText("à l'aide des flèches directionnelles. Vous naviguerez dans les", " ") + "\n"
            + Program.centerText("différents menu également avec les flèches, et vous", " ") + "\n"
            + Program.centerText("validerez votre choix en utilisant la touche “entrée”.", " ") + "\n\n"
            + Program.centerText("Les combats se passeront au tour par tour. Vous aurez la possibilité", " ") + "\n"
            + Program.centerText("de lancer des attaques, d'utiliser un objet de votre", " ") + "\n"
            + Program.centerText("inventaire, ou même de fuire le combat.", " ") + "\n\n"
            + Program.centerText("Il ne reste plus qu'à vous lancer dans l'aventure", " ") + "\n\n"
            + Program.centerText("Bon courage, et que la force soit avec vous !!!", " ") + "\n\n\n\n"
            + Program.centerText("APPUYEZ SUR UNE TOUCHE POUR DEMARRER L'AVENTURE", " ") + "\n";

        public readonly static String deathMessage = "\n\n"
            + Program.centerText("VOUS AVEZ ETE VAINCU", " ") + "\n\n\n"
            + Program.centerText("Merci d'avoir joué.", " ") + "\n";


    }
}