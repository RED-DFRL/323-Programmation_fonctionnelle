using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "bonjour", "hello", "monde", "vert", "roxuge", "bleu", "jaune" };
            string[] words2 = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };
            string[] words3 = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };

            //Fonctions de filtrage
            Func<string, bool> noX = word => !word.Contains("x");
            Func<string, bool> noX2 = word => !Regex.IsMatch(word, "x");

            Func<string, bool> fourOrMore = word => word.Length >= 4;

            Func<string, bool> sameAsAvg =
                word => word.Length == words.Average(word2 => word2.Length);

            Func<string[], string[]> reverse = word => word.Reverse().ToArray();
            Func<string[], string[]> sortAsc = word => word.OrderBy(word2 => word2).ToArray();
            Func<string[], string[]> sortDesc = word => word.OrderByDescending(word2 => word2).ToArray();

            Func<string[], string[]> filtered = word => word.Skip(1).Take(7).ToArray();


            string[] sortedAsc = sortAsc(words);
            string[] sortedDesc = sortDesc(words);
            string[] filter = filtered(words2);

            foreach (string s in filter) { Console.WriteLine(s); }

            /*//Recueil de fonctions
            var filters = new List<Func<string, bool>>();
            filters.Add(noX);
            filters.Add(noX2);
            filters.Add(fourOrMore);
            filters.Add(sameAsAvg);

            var filters1 = new List<Func<string[], string[]>>();
            filters1.Add(sortAsc);

            //Menu
            Console.WriteLine($"Liste de mots : {String.Join(',', words)}");
            Console.WriteLine("1. Pas de x v1");
            Console.WriteLine("2. Pas de x v2");
            Console.WriteLine("3. >= 4");
            Console.WriteLine("4. = moyenne de longueur dans la liste");
            Console.Write("\nChoix: ");

            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine($"Résultat: {String.Join(',', words.Where(filters[choice]))}");*/ 


        }
    }
}
