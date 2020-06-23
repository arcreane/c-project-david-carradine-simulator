using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;
using System.IO;

namespace Pendu
{
    class Program
    {
        #region Variable de jeu
        public const int MAX_ERROR = 10; //nombre d'erreur max
        public const string FILE_PATH = @"C:\Users\ASUS\source\repos\c-project-david-carradine-simulator\pendu\Ressources\liste_francais.txt"; //chemin du fichier
        #endregion

        static void Main(string[] args)
        {

            var file = File.ReadAllLines(FILE_PATH, Encoding.GetEncoding("iso-8859-1"));

            List<Word> Wordsfrompath = new List<Word>();

            foreach (var item in file)
            {
                var word = new Word(item);
            Wordsfrompath.Add(word);
            };

            var pendu = new GameInstance( MAX_ERROR) ;
            pendu.Play();
        }
    }
}