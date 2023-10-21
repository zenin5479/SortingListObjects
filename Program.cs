using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Сортировка списка объектов

namespace SortingListObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание списка.
            List<Player> lst = new List<Player>
            {
                new Player("John", 100),
                new Player("Smith", 120),
                new Player("Cait", 97),
                new Player("Irene", 100),
                new Player("Ben", 100),
                new Player("Deniel", 88)
            };

            // Сортировка с помощью list<t>. Sort() - метод
            // Сортировка по элементу Total в порядке возрастания: 
            lst.Sort(delegate (Player x, Player y)
            {
                return x.Total.CompareTo(y.Total);
            });

            Console.WriteLine("Сортировка по элементу Total в порядке возрастания:");
            foreach (var variable in lst)
            {
                Console.WriteLine(variable.Total);
            }

            // Сортировка по элементу Total в порядке убывания: 
            lst.Sort(delegate (Player x, Player y)
            {
                return y.Total.CompareTo(x.Total);
            });

            Console.WriteLine("\n" + "Сортировка по элементу Total в порядке убывания:");
            foreach (var variable in lst)
            {
                Console.WriteLine(variable.Total);
            }

            // Сортировка по нескольким элементам:
            lst.Sort(delegate (Player x, Player y)
            {
                // Сортировка по Total в порядке убывания
                int a = y.Total.CompareTo(x.Total);

                // У обоих игроков одинаковый Total.
                // Сортировка по Name в порядке возрастания
                if (a == 0)
                    a = string.Compare(x.Name, y.Name, StringComparison.Ordinal);

                return a;
            });

            Console.WriteLine("\n" + "Сортировка по нескольким элементам. " +
                              "\n" + "Сортировка по Total в порядке убывания." +
                              "\n" + "Сортировка по Name в порядке возрастания.");
            foreach (var variable in lst)
            {
                Console.WriteLine(variable.Name + " " + variable.Total);
            }

            // Сортировка с помощью Linq требует меньшего количества синтаксиса.
            var result1 = lst.OrderBy(a => a.Total);
            Console.WriteLine("\n" + "Сортировка по Total в порядке возрастания Linq:");
            foreach (var variable in result1)
            {
                Console.WriteLine(variable.Total);
            }

            var result2 = lst.OrderByDescending(a => a.Total).ThenByDescending(a => a.Name);

            Console.WriteLine("\n" + "Сортировка по нескольким элементам Linq." +
                              "\n" + "Сортировка по Total в порядке убывания." +
                              "\n" + "Сортировка по Name в порядке убывания.");
            foreach (var variable in result2)
            {
                Console.WriteLine(variable.Name + " " + variable.Total);
            }

            var result3 = lst.OrderBy(a => a.Total).ThenBy(a => a.Name);
            Console.WriteLine("\n" + "Сортировка по нескольким элементам Linq." +
                              "\n" + "Сортировка по Total в порядке возрастания." +
                              "\n" + "Сортировка по Name в порядке возрастания.");
            foreach (var variable in result3)
            {
                Console.WriteLine(variable.Name + " " + variable.Total);
            }

            Console.WriteLine("\n" + "Сортировка по нескольким элементам IComparer." +
                              "\n" + "Сортировка по Total в порядке возрастания." +
                              "\n" + "Сортировка по Name в порядке возрастания.");
            IComparer<Player> comparer = new MyPlayerClass();
            lst.Sort(comparer);
            foreach (var variable in lst)
            {
                Console.WriteLine(variable.Name + " " + variable.Total);
            }
        }
    }

    public class MyPlayerClass : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            int compare = x.Total.CompareTo(y.Total);
            if (compare == 0)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
            return compare;
        }
    }
}