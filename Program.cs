namespace QuizMaker;
class Program
{
    public static readonly Random random = new Random();
    public static List<QuizCard> questionsList = new List<QuizCard>();
    const string PATH = "QuizData.xml";
    static void Main(string[] args)
    {
        int decider;

        decider = UIMethods.DisplayWelcomeMessage();

        if (decider == 1)
        {
            do
            {
                var Question = new QuizCard();

                Question.Question = UIMethods.GetQuestion();
                Question.Answers = UIMethods.GetAnswers();

                decider = UIMethods.PromptForSaveAndExit();
                questionsList.Add(Question);
            }
            while (decider == 1);

            LogicMethods.SerializeToXML(PATH, questionsList);
        }

        //TODO Add more decider variables so they "handle" one thing each. (One for gamemode, on for replay etc.)

        while (decider == 2)
        {
            bool win = false;

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

            decider = UIMethods.AskForReplay();
        }
    }
}

