namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> questionsList = new List<QuizCard>();
    const string PATH = "QuizData.xml";
    static void Main(string[] args)
    {
        int gamemodeDecider;
        gamemodeDecider = UIMethods.DisplayWelcomeMessage();

        if (gamemodeDecider == 1)
        {
            do
            {
                int amountOfAnswers = UIMethods.ChooseAmountOfAnswers();
                var Question = new QuizCard
                {
                    Question = UIMethods.GetQuestion(),
                    Answers = UIMethods.GetAnswers(amountOfAnswers)
                };

                gamemodeDecider = UIMethods.PromptForSaveAndExit();
                questionsList.Add(Question);
            }
            while (gamemodeDecider == 1);

            LogicMethods.SerializeToXML(PATH, questionsList);
        }

        bool replayDecider = true;
        if (gamemodeDecider == 2)
        {
            while (replayDecider)
            {
                bool win;

                questionsList = LogicMethods.DeSerealizeFromXML(PATH, questionsList);

                var CurrentQuestion = questionsList[LogicMethods.SelectRandomQuestion(questionsList.Count)];
                UIMethods.DisplayQuestionAndAnswers(CurrentQuestion);

                int pickedAnswer;
                do
                {
                    pickedAnswer = UIMethods.PromptToPickAnswer();
                    win = LogicMethods.CheckAnswer(CurrentQuestion, pickedAnswer);

                    UIMethods.DisplayFeedbackToAnswer(pickedAnswer, CurrentQuestion, win);

                } while (pickedAnswer < 0 || pickedAnswer > CurrentQuestion.Answers.Count);

                replayDecider = UIMethods.AskForReplay();
            }
        }
    }
}

