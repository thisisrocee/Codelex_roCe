var namesList = new HashSet<string>();

while (true)
{
    Console.Write("Enter name:");
    var name = Console.ReadLine();

    if (name == "")
    {
        break;
    }

    namesList.Add(name);
}

Console.WriteLine($"Unique name list contains: {string.Join(", ", namesList)}");