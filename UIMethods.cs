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

        public static string SetQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static string SetAnswer()
        {
            Console.WriteLine("Enter answer: \n Note: For correct answer, add an '*' sign at the end of the string");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void DisplayQuestion(List<QuestionCreator> questions)
        {
            foreach (var question in questions)
            {
                Console.WriteLine(question.Question);
                Console.WriteLine(question.Answer1);
                Console.WriteLine(question.Answer2);
                Console.WriteLine(question.Answer3);
                Console.WriteLine(question.Answer4);
            }
        }
    }
}

