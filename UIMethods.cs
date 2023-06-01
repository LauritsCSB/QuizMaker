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
            Console.Clear();
            return decider;
        }

        public static string SetQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static void SetAnswers(List<string> answers)
        {
            Console.WriteLine("Note: For correct answer, add an '*' sign at the end of the string");

            for (int answerIndex = 0; answerIndex <= 3; answerIndex++)
            {
            Console.WriteLine($"Enter answer {answerIndex+1}: ");
            answers.Add(Console.ReadLine());
            }
            Console.Clear();
        }

        public static void DisplayQuestion(List<QuizCard> questions, int questionIndex)
        {
            Console.WriteLine(questions[questionIndex].Question);
        }

        public static void DisplayAnswers(List<QuizCard> questions, int questionIndex, List<string> answersList)
        {
            for (int answerIndex = 0; answerIndex < answersList.Count; answerIndex++)
            {
                Console.WriteLine($"{answerIndex + 1}. {questions[questionIndex].Answers[answerIndex].TrimEnd('*')}");
            }
        }

        public static int PromptToPickAnswer()
        {
            int answer;
            Console.WriteLine("Pick a number for your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer);

            return answer - 1;
        }

        public static void DisplayFeedbackToAnswer(int pickedAnswer, List<string> answersList, bool win)
        {
            if (pickedAnswer < 0 || pickedAnswer > answersList.Count)
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
            Console.Clear();
            return decider;
        }
    }
}

