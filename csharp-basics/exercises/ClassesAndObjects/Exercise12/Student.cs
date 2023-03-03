namespace Exercise12
{
    public class Student : IStudent
    {
        private List<string> testsTaken = new List<string>();

        public string[] TestsTaken => testsTaken.Count == 0 ? new[] { "No tests taken" } : testsTaken.ToArray();

        public void TakeTest(ITestPaper paper, string[] answers)
        {
            var correctAnswers = 0;

            for (var i = 0; i < answers.Length; i++)
            {
                if (answers[i] == paper.MarkScheme[i])
                {
                    correctAnswers++;
                }
            }

            var percent = correctAnswers * 100 / answers.Length;
            var passOrFail = percent >= int.Parse(paper.PassMark.Replace("%", "")) ? "Passed!" : "Failed!";
            var result = $"{paper.Subject}: {passOrFail} ({percent}%)";
            testsTaken.Add(result);
        }
    }
}
