namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> questionsList = new List<QuizCard>();
    static void Main(string[] args)
    {
        int gamemodeDecider = UIMethods.DisplayWelcomeMessage();


        if (gamemodeDecider == 1)
        {
            do
            {
                int amountOfAnswers = UIMethods.ChooseAmountOfAnswers();
                QuizCard quizCard = new QuizCard();

                quizCard.Question = UIMethods.GetQuestion();
                quizCard.Answers = UIMethods.GetAnswers(amountOfAnswers);

                questionsList.Add(quizCard);
                gamemodeDecider = UIMethods.PromptForSaveAndExit();
            }
            while (gamemodeDecider == 1);

            LogicMethods.SerializeToXML(questionsList);
        }

        if (gamemodeDecider == 2)
        {
            bool replayDecider = true;
            while (replayDecider)
            {

                questionsList = LogicMethods.DeSerealizeFromXML();

                QuizCard CurrentQuestion = questionsList[LogicMethods.SelectRandomQuestion(questionsList.Count)];
                UIMethods.DisplayQuestionAndAnswers(CurrentQuestion);

                int pickedAnswer;
                do
                {
                    pickedAnswer = UIMethods.PromptToPickAnswer();
                    bool win = LogicMethods.CheckAnswer(CurrentQuestion, pickedAnswer);

                    UIMethods.DisplayFeedbackToAnswer(pickedAnswer, CurrentQuestion, win);

                } while (pickedAnswer < 0 || pickedAnswer > CurrentQuestion.Answers.Count);

                replayDecider = UIMethods.AskForReplay();
            }
        }
    }
}

