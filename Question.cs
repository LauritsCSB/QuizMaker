using System;
namespace QuizMaker
{
    public class Question
    {
        private string question = "-";
        private List<string> answersList = new List<string>
        {
        };

        public void setQuestion(string userInput)
        {
            question = userInput;
        }

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

