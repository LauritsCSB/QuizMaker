namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
        var QuestionsList = new List<Question>();
        UIMethods.WelcomeMessage();

        while (Console.ReadKey(true).Key != ConsoleKey.D2)
        {
            var Question = new Question();
            QuestionsList.Add(Question);
            UIMethods.PromptForSaveAndExit();
        }

        var path = "/Users/Cecilie/Projects/QuizMaker/QuizData.xml";
        using (FileStream file = File.Create(path))
        {
            serializer.Serialize(file, QuestionsList);
        }

        using (FileStream file = File.OpenRead(path))
        {
            QuestionsList = serializer.Deserialize(file) as List<Question>;
        }
    }
}

