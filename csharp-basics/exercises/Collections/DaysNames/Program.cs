var namesOfDays = Enumerable.Range(0, 7).Select(i => ((DayOfWeek)i).ToString()).ToList();

Console.WriteLine(string.Join(", ", namesOfDays));