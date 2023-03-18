namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var steve = new Employee("Steve", "Jobs", "USA", 12345, "C# developer");
            var mark = new Student("Mark", "Zucker", "Germany", 67890, 12.5);

            steve.Display();
            mark.Display();
        }
    }
}