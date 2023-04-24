using System;
namespace QuizMaker
{
    public class UIMethods
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome user! This is a quiz maker program. You can either save new questions or run program with saved questions," +
                " if no prior questions has been saved, no output will be given");
        }

        public static string TakeQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static void TakeAnswers()
        {
            int amountOfAnswers;
            Console.WriteLine("Please enter the amount of answers and press enter:");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out amountOfAnswers);

            if (isNumber)
            {
                for (int i = 1; i <= amountOfAnswers; i++)
                {
                    Console.WriteLine($"Set answer {i}");
                    Question.answersList.Add(Console.ReadLine());
                }
            }
        }
    }
}

