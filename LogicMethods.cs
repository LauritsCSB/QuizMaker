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
    }
}

