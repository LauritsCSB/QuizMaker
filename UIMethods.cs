using System;
namespace QuizMaker
{
    public class UIMethods
    {
        public static int DisplayWelcomeMessage()
        {
            int decider;
            Console.WriteLine("Welcome user! This is a quiz maker program.\nWould you like to play latest saved quiz or create a new one?");
            Console.WriteLine("\tFor new quiz pres 1\n\tFor latest quiz press 2");

            Int32.TryParse(Console.ReadLine(), out decider);
            while (decider < 1 || decider > 2)
            {
                Console.WriteLine("Try again");
                Int32.TryParse(Console.ReadLine(), out decider);
            }
            Console.Clear();
            return decider;
        }

        public static int PromptForSaveAndExit()
        {
            int decider;
            Console.WriteLine("Press 1 if you'd like to add another question.\n Press 2 to save and start quiz.\n Press anything else to save the quiz and exit the program");
            Int32.TryParse(Console.ReadLine(), out decider);
            return decider;
        }

        public static string SetQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static void DisplayHowToAddCorrectAnswer()
        {
            Console.WriteLine("Note: For correct answer, add an '*' sign at the end of the string");
        }

        public static string SetAnswer()
        {
            Console.WriteLine("Enter possible answer: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void DisplayQuestion(List<QuestionClass> questions, int questionIndex)
        {
            Console.WriteLine(questions[questionIndex].Question);
        }

        public static void DisplayAnswers(List<QuestionClass> questions, string[] answersArray, int questionIndex)
        {
            answersArray[0] = questions[questionIndex].Answer1;
            answersArray[1] = questions[questionIndex].Answer2;
            answersArray[2] = questions[questionIndex].Answer3;
            answersArray[3] = questions[questionIndex].Answer4;

            for (int answersListIndex = 0; answersListIndex < answersArray.Length; answersListIndex++)
            {
                Console.WriteLine($"{answersListIndex + 1}. {answersArray[answersListIndex].TrimEnd('*')}");
            }
        }

        public static int PromptToPickAnswer()
        {
            int answer;
            Console.WriteLine("Pick a number for your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer);

            return answer - 1;
        }

        public static void DisplayFeedbackToAnswer(int pickedAnswer, string[] answersArray, bool win)
        {
            if (pickedAnswer < 0 || pickedAnswer > answersArray.Length)
            {
                Console.WriteLine("Try again");
            }

            if (win)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
            
        }

        public static int AskForReplay()
        {
            int decider;
            Console.WriteLine("For new question press 2, to exit press any other number");
            Int32.TryParse(Console.ReadLine(), out decider);
            return decider;
        }
    }
}

