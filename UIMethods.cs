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

        public static string TakeAnswer()
        {
            Console.WriteLine("Enter answer: ");
            string answer = Console.ReadLine();
            return answer;
        }

        /*public static void TakeFirstAnswer()
        {
            Console.WriteLine("Enter first answer: ");
            QuestionCreator.answer1 = Console.ReadLine();
        }

        public static void TakeSecondAnswer()
        {
            Console.WriteLine("Enter second answer: ");
            QuestionCreator.answer2 = Console.ReadLine();
        }

        public static void TakeThirdAnswer()
        {
            Console.WriteLine("Enter third answer: ");
            QuestionCreator.answer3 = Console.ReadLine();
        }

        public static void TakeFourthAnswer()
        {
            Console.WriteLine("Enter fourth answer: ");
            QuestionCreator.answer4 = Console.ReadLine();
        }*/
    }
}

