﻿using System;
namespace QuizMaker
{
    public class Question
    {
        public string question = UIMethods.TakeQuestion();

        public static List<string> answersList = new List<string>
        {
        };

        public Question()
        {
            UIMethods.TakeAnswers();
        }
    }
}

