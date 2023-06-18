using System;
using System.Text;

namespace QuizMaker
{
    public class UIMethods
    {
        /// <summary>
        /// prints instructions to user. Asks for input to decide playmode
        /// </summary>
        /// <returns>decider integer to determine playmode</returns>
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

        /// <summary>
        /// asks user to input the amount of answers they want for the following question
        /// </summary>
        /// <returns>integer deciding the amount of answers</returns>
        public static int ChooseAmountOfAnswers()
        {
            int amount;
            do
            {
                Console.WriteLine("Please enter the amount of answers for the current question:");
                Int32.TryParse(Console.ReadLine(), out amount);
        
            } while (amount < 1);
            return amount;
        }

        /// <summary>
        /// gives user the ability to choose between adding more questions, save and start the quiz or exit
        /// </summary>
        /// <returns>decider integer to dertermine thir choise</returns>
        public static int PromptForSaveAndExit()
        {
            int decider;
            Console.WriteLine("Press 1 if you'd like to add another question.\n Press 2 to save and start quiz.\n Press anything else to save the quiz and exit the program");
            Int32.TryParse(Console.ReadLine(), out decider);
            Console.Clear();
            return decider;
        }

        /// <summary>
        /// asking user to enter question
        /// </summary>
        /// <returns>string containing question</returns>
        public static string GetQuestion()
        {
            Console.WriteLine("Enter question: ");
            string question = Console.ReadLine();
            return question;
        }

        /// <summary>
        /// asking user to imput the answers they want for the current question
        /// </summary>
        /// <param name="amountOfAnswers"></param>
        /// <returns>list of strings containing the given answers</returns>
        public static List<string> GetAnswers(int amountOfAnswers)
        {
            List<string> answers = new List<string>();
            Console.WriteLine("Note: Only one correct answer per question. This will be set after all possible answers is given.");
            
            for (int answerIndex = 0; answerIndex <= (amountOfAnswers - 1); answerIndex++)
            {
                Console.WriteLine($"Enter answer {answerIndex+1}: ");
                answers.Add(Console.ReadLine());
            }

            Console.Clear();
            return answers;
        }

        /// <summary>
        /// asks the user to specify which one of the given answers is correct 
        /// </summary>
        /// <param name="answersList"></param>
        /// <returns>a list of answers whith and indicator at the end of the correct one</returns>
        public static List<string> GetCorrectAnswer(List<string> answersList)
        {
            int correctAnswerIndex;
            Console.WriteLine("Given answers:");
            do
            {
                for (int answerIndex = 0; answerIndex < answersList.Count; answerIndex++)
                {
                    Console.WriteLine($"{answerIndex+1}. {answersList[answerIndex]}");
                }

                Console.WriteLine("What number of answer is the correct one?");
                Int32.TryParse(Console.ReadLine(), out correctAnswerIndex);
                Console.Clear();
            } while (correctAnswerIndex < 0 && correctAnswerIndex > answersList.Count);

            answersList[correctAnswerIndex - 1] += '*';

            return answersList;
        }

        /// <summary>
        /// prints question with all related answers to user
        /// </summary>
        /// <param name="currentQuestion"></param>
        public static void DisplayQuestionAndAnswers(QuizCard currentQuestion)
        {
            Console.WriteLine(currentQuestion.Question);
            for (int answerIndex = 0; answerIndex < currentQuestion.Answers.Count; answerIndex++)
            {
                Console.WriteLine($"{answerIndex + 1}. {currentQuestion.Answers[answerIndex].TrimEnd('*')}");
            }
        }

        /// <summary>
        /// asks user to input their answer
        /// </summary>
        /// <param name="currentQuestion"></param>
        /// <returns>users input decremented by one</returns>
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

        /// <summary>
        /// prints feedback based on users answer to question
        /// </summary>
        /// <param name="pickedAnswer"></param>
        /// <param name="currentQuestion"></param>
        /// <param name="win"></param>
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

        /// <summary>
        /// asks user to decide whether they want another question or exit
        /// </summary>
        /// <returns>boolean based on users input referring to replay</returns>
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

