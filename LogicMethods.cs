using System;
namespace QuizMaker
{
    public class LogicMethods
    {
        public static int SelectRandomQuestion(int max)
        {
            Random random = new Random();
            int randomNumber = random.Next(max);
            return randomNumber;
        }

        public static bool CheckAnswer(string[] answersArray, int pickedAnswer)
        {
            bool win = false;

            if (pickedAnswer > 0 && pickedAnswer <= answersArray.Length)
            {
                if (answersArray[pickedAnswer].Contains('*'))
                {
                    win = true;
                }
                else
                {
                    win = false;
                }
            }

            return win;
        }
    }

}

