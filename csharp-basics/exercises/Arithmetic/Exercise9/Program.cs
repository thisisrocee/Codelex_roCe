var weightPounds = 150;
var heightInches = 72;

Console.WriteLine(CalculateBmi(weightPounds, heightInches));

static string CalculateBmi(int weightPounds, int heightInches)
{
    var weightKgs = weightPounds * 0.453;
    var heightMeters = heightInches * 0.0254;
    var bmiInMetric = weightKgs / Math.Pow(heightMeters, 2);
    var str = $"Your BMI is {bmiInMetric:F2}";

    if (bmiInMetric < 18.5)
    {
        return "Underweight, " + $"Your BMI is {bmiInMetric:F2}";
    }

    if (bmiInMetric > 25)
    {
        return "Overweight, " + $"Your BMI is {bmiInMetric:F2}";
    }

    return "Optimal, " + str;
}