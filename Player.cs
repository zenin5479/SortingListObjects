namespace SortingListObjects
{
    // Возьмем в качестве примера этот класс.
    public class Player
    {
        public string Name { get; set; }
        public int Total { get; set; }

        public Player(string name, int total)
        {
            Name = name;
            Total = total;
        }
    }
}