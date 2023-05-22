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

        public static int DecideNewOrOldQuiz()
        {
            int decider;
            Int32.TryParse(Console.ReadLine(), out decider);
            if (decider < 1 || decider > 2)
            {
                Console.WriteLine("Try again");
            }
            return decider;
        }

        public static void PromptForSaveAndExit()
        {
            Console.WriteLine("Press 1 if you'd like to add another question.\n Press 2 to save and start quiz.\n Press anything else to save the quiz and exit the program");
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
            Console.WriteLine("Enter answer: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void DisplayQuestion(List<QuestionClass> questions, int questionIndex)
        {
            Console.WriteLine(questions[questionIndex].Question);
        }

        public static void DisplayAnswers(List<QuestionClass> questions, string[] answersArray, int questionIndex)
        {
           /* answersList.Add(questions[questionIndex].Answer1);
            answersList.Add(questions[questionIndex].Answer2);
            answersList.Add(questions[questionIndex].Answer3);
            answersList.Add(questions[questionIndex].Answer4);*/

            answersArray[0] = questions[questionIndex].Answer1;
            answersArray[1] = questions[questionIndex].Answer2;
            answersArray[2] = questions[questionIndex].Answer3;
            answersArray[3] = questions[questionIndex].Answer4;

            for (int answersListIndex = 0; answersListIndex < answersArray.Length; answersListIndex++)
            {
                Console.WriteLine($"{answersListIndex + 1}. {answersArray[answersListIndex].TrimEnd('*')}");
            }
        }

        public static int PickAnswer(string[] answersArray)
        {
            int answer;
            Console.WriteLine("Pick a number for your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer);

            return answer;
        }

        public static void CheckAnswer(int pickedAnswer, string[] answersArray)
        {
            if (pickedAnswer < 0 || pickedAnswer > answersArray.Length)
            {
                Console.WriteLine("Try again");
            }

            if (pickedAnswer > 0 && pickedAnswer <= answersArray.Length)
            {
                if (answersArray[pickedAnswer].Contains('*'))
                {
                    Console.WriteLine("Correct!");
                }
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

