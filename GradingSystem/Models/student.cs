namespace GradingSystem.Models
{
    public class Student
    {
        public int Id { get; }
        public string FullName { get; }
        public int Score { get; }
// Constructor to initialize the student object
        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        public string GetGrade() => Score switch
        {
            >= 80 and <= 100 => "A",
            >= 70 and < 80 => "B",
            >= 60 and < 70 => "C",
            >= 50 and < 60 => "D",
            _ => "F"
        };
    }
}