var bmwHashSet = new HashSet<string>();

bmwHashSet.Add("e30");
bmwHashSet.Add("e36");
bmwHashSet.Add("e46");
bmwHashSet.Add("e90");
bmwHashSet.Add("f30");

Console.WriteLine($"HashSet: {string.Join(", ", bmwHashSet)}");

bmwHashSet.Clear();

Console.WriteLine($"All items removed HashSet: {string.Join(", ", bmwHashSet)}");

bmwHashSet.Add("e30");
bmwHashSet.Add("e30");

Console.WriteLine($"HashSet: {string.Join(", ", bmwHashSet)} \n" +
                  $"no, it is not possible to add duplicates, because it is HashSet :)");