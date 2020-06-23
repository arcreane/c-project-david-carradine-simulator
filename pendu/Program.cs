using pendu.Ressources;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

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
            var stop = false;
            var file = File.ReadAllLines(path: FILE_PATH, Encoding.GetEncoding("iso-8859-1"));

            List<Word> Wordsfrompath = new List<Word>();

            foreach (var item in file)
            {
                var word = new Word(item);
                Wordsfrompath.Add(word);
            };

            while (!stop)
            {
                var pendu = new GameInstance(Wordsfrompath, MAX_ERROR);
                pendu.Play();
                Console.WriteLine("arreter là ? o/n");
                var entry = Console.ReadLine();
                if(entry == "o")
                {
                    stop = true;
                }
            }

        }
    }
}