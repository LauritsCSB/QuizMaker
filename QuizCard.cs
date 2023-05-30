using System;
namespace QuizMaker
{
    public class QuizCard
    {
        public string Question { get; set; }

        public List<string> Answers { get; set; } = new List<string>();
    }
}

