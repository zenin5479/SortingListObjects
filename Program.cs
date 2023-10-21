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

            // Сортировка с помощью list<t>. Sort() - метод
            // Сортировка по одному элементу "" в порядке возрастания: Total
            lst.Sort(delegate (Player x, Player y)
            {
                return x.Total.CompareTo(y.Total);
            });

            // Сортировка по одному элементу "" в порядке убывания: Total
            lst.Sort(delegate (Player x, Player y)
            {
                return y.Total.CompareTo(x.Total);
            });

            // Сортировка по нескольким элементам:
            lst.Sort(delegate (Player x, Player y)
            {
                // Сортировка по общему количеству в порядке убывания
                int a = y.Total.CompareTo(x.Total);

                // У обоих игроков одинаковый Total.
                // Сортировка по названию в порядке возрастания
                if (a == 0)
                    a = x.Name.CompareTo(y.Name);

                return a;
            });

            // Сортировка с помощью Linq требует меньшего количества синтаксиса.
            var result1 = lst.OrderBy(a => a.Total);

            var result3 = lst.OrderBy(a => a.Total).ThenBy(a => a.Name);

            var result2 = lst.OrderByDescending(a => a.Total).ThenByDescending(a => a.Name);
        }
    }
}
