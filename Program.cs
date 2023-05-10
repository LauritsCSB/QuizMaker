namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionCreator>));
        var path = @"/Users/Cecilie/Projects/QuizMaker/QuizData.xml";
        List<QuestionCreator> QuestionsList = new List<QuestionCreator>();
        UIMethods.WelcomeMessage();

        int decider;
        Int32.TryParse(Console.ReadLine(), out decider);

        if (decider == 1)
        {
            do
            {
                var Question = new QuestionCreator();

                Question.Question = UIMethods.SetQuestion();
                UIMethods.DisplayHowToAddCorrectAnswer();
                Question.Answer1 = UIMethods.SetAnswer();
                Question.Answer2 = UIMethods.SetAnswer();
                Question.Answer3 = UIMethods.SetAnswer();
                Question.Answer4 = UIMethods.SetAnswer();

                UIMethods.PromptForSaveAndExit();
                QuestionsList.Add(Question);
                Int32.TryParse(Console.ReadLine(), out decider);
            }
            while (decider == 1);

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, QuestionsList);
            }
        }


        if (decider == 2)
        {
            bool win = false;
            using (FileStream file = File.OpenRead(path))
            {
                QuestionsList = serializer.Deserialize(file) as List<QuestionCreator>;
            }

            int questionIndex = LogicMethods.SelectRandomQuestion(QuestionsList.Count);
            UIMethods.DisplayQuestion(QuestionsList, questionIndex);

            int pickedAnswer = UIMethods.TakeAnswer() - 1;

            string[] answersArray = new string[]
            {
                QuestionsList[questionIndex].Answer1,
                QuestionsList[questionIndex].Answer2,
                QuestionsList[questionIndex].Answer3,
                QuestionsList[questionIndex].Answer4
            };

            if (answersArray[pickedAnswer].Contains('*'))
            {
                Console.WriteLine("Correct!");
            }
            
        }


    }
}

