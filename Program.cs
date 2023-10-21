using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Сортировка списка объектов

namespace SortingListObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание списка.
            List<Player> lst = new List<Player>();
            lst.Add(new Player("John", 100));
            lst.Add(new Player("Smith", 120));
            lst.Add(new Player("Cait", 97));
            lst.Add(new Player("Irene", 100));
            lst.Add(new Player("Ben", 100));
            lst.Add(new Player("Deniel", 88));


            lst.Sort(delegate (Player x, Player y)
            {
                return x.Total.CompareTo(y.Total);
            });

            lst.Sort(delegate (Player x, Player y)
            {
                return y.Total.CompareTo(x.Total);
            });

            lst.Sort(delegate (Player x, Player y)
            {
                // Sort by total in descending order
                int a = y.Total.CompareTo(x.Total);

                // Both player has the same total.
                // Sort by name in ascending order
                if (a == 0)
                    a = x.Name.CompareTo(y.Name);

                return a;
            });

            var result1 = lst.OrderBy(a => a.Total);

            var result3 = lst.OrderBy(a => a.Total).ThenBy(a => a.Name);

            var result2 = lst.OrderByDescending(a => a.Total).ThenByDescending(a => a.Name);
        }
    }
}
