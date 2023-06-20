namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> quizCardList = new List<QuizCard>();
    static void Main(string[] args)
    {
        int gamemodeDecider = UIMethods.DisplayWelcomeMessage();

        do
        {
            switch (gamemodeDecider)
            {
                case 1:
                    quizCardList = LogicMethods.DeSerealizeFromXML();

                    UIMethods.DisplayAllQuizcardsFromList(quizCardList);
                    //TODO Method returning gamemodeDecider
                    break;

                case 2:
                    do
                    {
                        int amountOfAnswers = UIMethods.ChooseAmountOfAnswers();
                        QuizCard quizCard = new QuizCard();

                        quizCard.Question = UIMethods.GetQuestion();
                        quizCard.Answers = UIMethods.GetAnswers(amountOfAnswers);
                        quizCard.Answers = UIMethods.GetCorrectAnswer(quizCard.Answers);

                        quizCardList.Add(quizCard);
                        gamemodeDecider = UIMethods.PromptForSaveAndExit();
                    }
                    while (gamemodeDecider == 1);
                    //TODO new newQuizCard method returning int deciding whether do/while should loop, gamemodeDecider is for switch
                    LogicMethods.SerializeToXML(quizCardList);

                    break;

                case 3:
                    bool replayDecider = true;
                    while (replayDecider)
                    {

                        quizCardList = LogicMethods.DeSerealizeFromXML();

                        QuizCard currentQuestion = quizCardList[LogicMethods.SelectRandomQuestion(quizCardList.Count)];
                        UIMethods.DisplayQuestionAndAnswers(currentQuestion);

                        int pickedAnswer;
                        do
                        {
                            pickedAnswer = UIMethods.PromptToPickAnswer(currentQuestion);
                            //TODO CheckAnswer throws an error
                            bool win = LogicMethods.CheckAnswer(currentQuestion, pickedAnswer);

                            UIMethods.DisplayFeedbackToAnswer(pickedAnswer, currentQuestion, win);

                        } while (pickedAnswer < 0 || pickedAnswer > currentQuestion.Answers.Count);

                        replayDecider = UIMethods.AskForReplay();
                    }

                    break;

                default:
                    break;
            }
        } while (gamemodeDecider > 1 && gamemodeDecider < 3);
    }
}

