namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
        var path = "/Users/Cecilie/Projects/QuizMaker/QuizData.xml";
        List<Question> QuestionsList = new List<Question>();
        UIMethods.WelcomeMessage();

        int decider;
        Int32.TryParse(Console.ReadLine(), out decider);

        if (decider == 1)
        {
            while (decider == 1)
            {
                var Question = new Question();
                UIMethods.TakeQuestion();
                UIMethods.TakeFirstAnswer();
                UIMethods.TakeSecondAnswer();
                UIMethods.TakeThirdAnswer();
                UIMethods.TakeFourthAnswer();
                UIMethods.PromptForSaveAndExit();
                QuestionsList.Add(Question);
                Int32.TryParse(Console.ReadLine(), out decider);
            }

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, QuestionsList);
            }
        }


        if (decider == 2)
        {
            using (FileStream file = File.OpenRead(path))
            {
                QuestionsList = serializer.Deserialize(file) as List<Question>;
            }

            foreach (var Question in QuestionsList)
            {
                Console.WriteLine(Question.question);
                Console.WriteLine(Question.answer1);
                Console.WriteLine(Question.answer2);
                Console.WriteLine(Question.answer3);
                Console.WriteLine(Question.answer4);
            }
        }


    }
}

