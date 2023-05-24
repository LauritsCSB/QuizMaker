namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionClass>));
        var path = Directory.GetCurrentDirectory() + @"/QuizData.xml";
        List<QuestionClass> QuestionsList = new List<QuestionClass>();
        string[] answersArray = new string[4];
        int decider;

        decider = UIMethods.WelcomeMessage();

        if (decider == 1)
        {
            do
            {
                UIMethods.ClearConsole();
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
            UIMethods.ClearConsole();
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
                pickedAnswer = UIMethods.PickAnswer(answersArray);

                UIMethods.CheckAnswer(pickedAnswer, answersArray);

            } while (pickedAnswer < 0 || pickedAnswer > answersArray.Length);

            decider = UIMethods.AskForReplay();
        }
    }
}

