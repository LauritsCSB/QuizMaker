using System;
namespace QuizMaker
{
    public class Question
    {
        public string question = UIMethods.TakeQuestion();

        public string answer1 = UIMethods.TakeAnswer();
        public string answer2 = UIMethods.TakeAnswer();
        public string answer3 = UIMethods.TakeAnswer();
        public string answer4 = UIMethods.TakeAnswer();
    }
}

