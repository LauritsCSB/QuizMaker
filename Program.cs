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
                quizCard.Answers = UIMethods.GetCorrectAnswer(quizCard.Answers);

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

                QuizCard currentQuestion = questionsList[LogicMethods.SelectRandomQuestion(questionsList.Count)];
                UIMethods.DisplayQuestionAndAnswers(currentQuestion);

                int pickedAnswer;
                do
                {
                    pickedAnswer = UIMethods.PromptToPickAnswer(currentQuestion);
                    bool win = LogicMethods.CheckAnswer(currentQuestion, pickedAnswer);

                    UIMethods.DisplayFeedbackToAnswer(pickedAnswer, currentQuestion, win);

                } while (pickedAnswer < 0 || pickedAnswer > currentQuestion.Answers.Count);

                replayDecider = UIMethods.AskForReplay();
            }
        }
    }
}

