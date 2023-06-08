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

        public static int ChooseAmountOfAnswers()
        {
            int amount;
            Console.WriteLine("Please enter the amount of answers for current question");
            Int32.TryParse(Console.ReadLine(), out amount);
            return amount;
        }

        public static int PromptForSaveAndExit()
        {
            int decider;
            Console.WriteLine("Press 1 if you'd like to add another question.\n Press 2 to save and start quiz.\n Press anything else to save the quiz and exit the program");
            Int32.TryParse(Console.ReadLine(), out decider);
            Console.Clear();
            return decider;
        }

        public static string GetQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static List<string> GetAnswers(int amountOfAnswers)
        {
            List<string> answers = new List<string>();
            Console.WriteLine("Note: For correct answer, add an '*' sign at the end of the string");

            int correctAnswerCounter = 0;
            do
            {
            for (int answerIndex = 0; answerIndex <= (amountOfAnswers - 1); answerIndex++)
            {
                Console.WriteLine($"Enter answer {answerIndex+1}: ");
                answers.Add(Console.ReadLine());
            }

            foreach (var answer in answers)
            {
                if (answer.Contains('*'))
                {
                    correctAnswerCounter++;
                }
            }

            if (correctAnswerCounter < 1)
            {
                Console.WriteLine("No correct answer was detected, please try again");
            }

            } while (correctAnswerCounter < 1);

            Console.Clear();
            return answers;
        }

        public static void DisplayQuestionAndAnswers(QuizCard currentQuestion)
        {
            Console.WriteLine(currentQuestion.Question);
            for (int answerIndex = 0; answerIndex < currentQuestion.Answers.Count; answerIndex++)
            {
                Console.WriteLine($"{answerIndex + 1}. {currentQuestion.Answers[answerIndex].TrimEnd('*')}");
            }
        }


        public static int PromptToPickAnswer(QuizCard currentQuestion)
        {
            int answer;
            do
            {
                Console.WriteLine("Pick a number for your answer: ");
                Int32.TryParse(Console.ReadLine(), out answer);

            } while (answer < 0 || answer > currentQuestion.Answers.Count);

            return answer - 1;
        }

        public static void DisplayFeedbackToAnswer(int pickedAnswer, QuizCard currentQuestion, bool win)
        {
            if (win)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
            
        }

        public static bool AskForReplay()
        {
            int decider;
            bool replay;
            Console.WriteLine("For new question press 1, to exit press enter");
            Int32.TryParse(Console.ReadLine(), out decider);
            Console.Clear();
            if (decider == 1)
            {
                replay = true;
            }
            else
            {
                replay = false;
            }
            return replay;
        }
    }
}

