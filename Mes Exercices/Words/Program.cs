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
           

            //Fonctions de filtrage
            Func<string, bool> noX = word => !word.Contains("x");
            Func<string, bool> noX2 = word => !Regex.IsMatch(word, "x");

            Func<string, bool> fourOrMore = word => word.Length >= 4;

            Func<string, bool> sameAsAvg =
                word => word.Length == words.Average(word2 => word2.Length);

            Func<string[], string[]> reverse = words => words.Reverse().ToArray();
            Func<string[], string[]> sortAsc = words => words.OrderBy(word => word).ToArray();
            Func<string[], string[]> sortDesc = words => words.OrderByDescending(word => word).ToArray();

            Func<string[], string[]> filtered = word => word.Skip(1).Take(7).ToArray();

            Func<IEnumerable<string>> c = () =>
            {
                string[] words3 = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };
                var clean = words3.Where(word => word.All(letter => char.IsLetterOrDigit(letter)));
                return clean;
            };

            string[] sortedAsc = sortAsc(words);
            string[] sortedDesc = sortDesc(words);
            string[] filter = filtered(words2);

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
