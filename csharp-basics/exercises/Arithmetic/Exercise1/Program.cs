Console.WriteLine("Insert first integer");
var firstNum = int.Parse(Console.ReadLine());
Console.WriteLine("Insert second integer");
var secondNum = int.Parse(Console.ReadLine());

var result = firstNum == 15 || secondNum == 15 || firstNum + secondNum == 15 || Math.Abs(firstNum - secondNum) == 15;

Console.WriteLine(result);