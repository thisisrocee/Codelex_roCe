namespace Exercise12
{
    public interface IStudent
    {
        string[] TestsTaken { get; }
        void TakeTest(ITestPaper paper, string[] answers);
    }
}
