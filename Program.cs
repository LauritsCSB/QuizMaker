namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> questionsList = new List<QuizCard>();
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
                UIMethods.SetAnswers(Question.Answers);

                decider = UIMethods.PromptForSaveAndExit();
                questionsList.Add(Question);
            }
            while (decider == 1);

            LogicMethods.SerializeToXML();
        }


        while (decider == 2)
        {
            bool win = false;

            int questionIndex = LogicMethods.SelectRandomQuestion(questionsList.Count);
            UIMethods.DisplayQuestion(questionsList, questionIndex);
            UIMethods.DisplayAnswers(questionsList, questionIndex, questionsList[questionIndex].Answers);

            int pickedAnswer;
            do
            {
                pickedAnswer = UIMethods.PromptToPickAnswer();
                win = LogicMethods.CheckAnswer(questionsList[questionIndex].Answers, pickedAnswer);

                UIMethods.DisplayFeedbackToAnswer(pickedAnswer, questionsList[questionIndex].Answers, win);

            } while (pickedAnswer < 0 || pickedAnswer > questionsList[questionIndex].Answers.Count);

            decider = UIMethods.AskForReplay();
        }
    }
}

