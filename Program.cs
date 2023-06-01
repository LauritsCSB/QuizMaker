namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> QuestionsList = new List<QuizCard>();
    static void Main(string[] args)
    {
        int decider;

        decider = UIMethods.DisplayWelcomeMessage();

        if (decider == 1)
        {
            do
            {
                var Question = new QuizCard();

                Question.Question = UIMethods.SetQuestion();
                UIMethods.DisplayHowToAddCorrectAnswer();
                UIMethods.SetAnswers(Question.Answers);

                decider = UIMethods.PromptForSaveAndExit();
                QuestionsList.Add(Question);
            }
            while (decider == 1);

            LogicMethods.SerializeToXML();
        }


        while (decider == 2)
        {
            bool win = false;

            int questionIndex = LogicMethods.SelectRandomQuestion(QuestionsList.Count);
            UIMethods.DisplayQuestion(QuestionsList, questionIndex);
            UIMethods.DisplayAnswers(QuestionsList, questionIndex, QuestionsList[questionIndex].Answers);

            int pickedAnswer;
            do
            {
                pickedAnswer = UIMethods.PromptToPickAnswer();
                win = LogicMethods.CheckAnswer(QuestionsList[questionIndex].Answers, pickedAnswer);

                UIMethods.DisplayFeedbackToAnswer(pickedAnswer, QuestionsList[questionIndex].Answers, win);

            } while (pickedAnswer < 0 || pickedAnswer > QuestionsList[questionIndex].Answers.Count);

            decider = UIMethods.AskForReplay();
        }
    }
}

