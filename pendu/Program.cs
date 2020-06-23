using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;
using System.IO;
using pendu.Ressources;

namespace Pendu
{
    class Program
    {
        #region Variable de jeu
        public const int MAX_ERROR = 10; //nombre d'erreur max
        public static string FILE_PATH = Resource.liste_francais; //chemin du fichier
        #endregion

        static void Main(string[] args)
        {

            var file = File.ReadAllLines(path: FILE_PATH, Encoding.GetEncoding("iso-8859-1"));

            List<Word> Wordsfrompath = new List<Word>();

            foreach (var item in file)
            {
                var word = new Word(item);
            Wordsfrompath.Add(word);
            };

            var pendu = new GameInstance(Wordsfrompath, MAX_ERROR);
            pendu.Play();
        }
    }
}