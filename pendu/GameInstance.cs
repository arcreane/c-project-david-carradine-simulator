using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pendu
{
    class GameInstance
    {
        public List<char> Guesses { get; }

        public List<char> Misses { get; }

        public List<Word> Words { get; }

        public Word WordToGuess { get; }

        private int maxErrors { get; set; }

        private bool isWin { get; set; }

        private Random rand;

        private string currentWordGuessed;

        /// <summary>
        /// Créer une nouvelle instance du jeu du pendu.
        /// </summary>
        /// <param name="maxErrors">Nombre d'erreurs maximum autorisés</param>
        public GameInstance(int maxErrors = 10)
        {
            rand = new Random();
            this.maxErrors = maxErrors;

            Words = new List<Word>
            {
                new Word("onlyfan"),
                new Word("belle-delphine"),
                new Word("webstart"),
                new Word("test"),
            };

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rand.Next(0, Words.Count)];

            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);
            currentWordGuessed = PrintWordToGuess();
        }

        /// <summary>
        /// Créer une nouvelle instance du jeu du pendu avec votre propre liste de mots à deviner.
        /// </summary>
        /// <param name="words">Liste de mots</param>
        /// <param name="maxErrors">Nombre d'erreurs maximum autorisé</param>
        public GameInstance(List<Word> words, int maxErrors)
        {
            rand = new Random();

            this.maxErrors = maxErrors;

            Words = words;

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rand.Next(0, Words.Count)];

            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);
            currentWordGuessed = PrintWordToGuess();
        }

        /// <summary>
        /// Permet de jouer au jeu du pendu.
        /// </summary>
        public void Play()
        {
            while (!isWin)
            {
                Console.WriteLine("Entrez une lettre :");

                char letter = char.ToUpper(Console.ReadKey(true).KeyChar);

                int letterIndex = WordToGuess.GetIndexOf(letter);

                Console.WriteLine();

                if (letterIndex != -1)
                {
                    Console.WriteLine("Vous avez trouvé la lettre : {0}", letter);
                    Guesses.Add(letter);
                }
                else
                {
                    Console.WriteLine("La lettre {0} ne se trouve pas dans le mot", letter);
                    Misses.Add(letter);
                }

                Console.WriteLine($"Erreurs ({Misses.Count}) : {string.Join(", ", Misses)}");

                currentWordGuessed = PrintWordToGuess();

                if (currentWordGuessed.IndexOf('_') == -1)
                {
                    isWin = true;
                    Console.WriteLine("Gagné");
                    Console.ReadKey();
                }

                if (Misses.Count >= maxErrors)
                {
                    Console.WriteLine("Perdu !");
                    Console.ReadKey();
                    break;
                }
            }
        }

        /// <summary>
        /// Affiche le mot à deviner 
        /// </summary>
        /// <returns></returns>
        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }
            }

            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();

            return currentWordGuessed;
        }
    }
}