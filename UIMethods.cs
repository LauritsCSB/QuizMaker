using System;
namespace QuizMaker
{
    public class UIMethods
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome user! This is a quiz maker program.\nWould you like to play latest saved quiz or create a new one?");
            Console.WriteLine("\tFor new quiz pres 1\n\tFor latest quiz press 2");
        }

        public static void PromptForSaveAndExit()
        {
            Console.WriteLine("Press 2 if you'd like to save the quiz and exit the program");
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

