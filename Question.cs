using System;
namespace QuizMaker
{
    public class Question
    {
        public string question = UIMethods.SetQuestion();

        private List<string> answersList = new List<string>
        {
        };

        public void setAnswer()
        {
            int amountOfAnswers;
            Console.WriteLine("Please enter the amount of answers and press enter:");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out amountOfAnswers);

            if (isNumber)
            {
                for (int i = 1; i <= amountOfAnswers; i++)
                {
                    Console.WriteLine($"Set answer {i}");
                    answersList.Add(Console.ReadLine());
                }
            }
        }
    }
}

