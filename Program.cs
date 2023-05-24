namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    public static readonly Random random = new Random();
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionClass>));
        var path = Directory.GetCurrentDirectory() + @"/QuizData.xml";
        
        List<QuestionClass> QuestionsList = new List<QuestionClass>();
        string[] answersArray = new string[4];
        int decider;

        decider = UIMethods.DisplayWelcomeMessage();

        if (decider == 1)
        {
            do
            {
                var Question = new QuestionClass();

                Question.Question = UIMethods.SetQuestion();
                UIMethods.DisplayHowToAddCorrectAnswer();
                Question.Answer1 = UIMethods.SetAnswer();
                Question.Answer2 = UIMethods.SetAnswer();
                Question.Answer3 = UIMethods.SetAnswer();
                Question.Answer4 = UIMethods.SetAnswer();

                decider = UIMethods.PromptForSaveAndExit();
                QuestionsList.Add(Question);
            }
            while (decider == 1);

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, QuestionsList);
            }
        }


        while (decider == 2)
        {
            bool win = false;
            using (FileStream file = File.OpenRead(path))
            {
                QuestionsList = serializer.Deserialize(file) as List<QuestionClass>;
            }

            int questionIndex = LogicMethods.SelectRandomQuestion(QuestionsList.Count);
            UIMethods.DisplayQuestion(QuestionsList, questionIndex);
            UIMethods.DisplayAnswers(QuestionsList, answersArray, questionIndex);

            int pickedAnswer;
            do
            {
                pickedAnswer = UIMethods.PromptToPickAnswer();
                win = LogicMethods.CheckAnswer(answersArray, pickedAnswer);

                UIMethods.DisplayFeedbackToAnswer(pickedAnswer, answersArray, win);

            } while (pickedAnswer < 0 || pickedAnswer > answersArray.Length);

            decider = UIMethods.AskForReplay();
        }
    }
}

