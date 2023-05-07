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
            while (decider == 1)
            {
                var Question1 = new QuestionCreator();

                Question1.Question = UIMethods.SetQuestion();
                Question1.Answer1 = UIMethods.SetAnswer();
                Question1.Answer2 = UIMethods.SetAnswer();
                Question1.Answer3 = UIMethods.SetAnswer();
                Question1.Answer4 = UIMethods.SetAnswer();
                
                UIMethods.PromptForSaveAndExit();
                QuestionsList.Add(Question1);
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
                QuestionsList = serializer.Deserialize(file) as List<QuestionCreator>;
            }

            foreach (var Question in QuestionsList)
            {
                Console.WriteLine(Question.Question);
                Console.WriteLine(Question.Answer1);
                Console.WriteLine(Question.Answer2);
                Console.WriteLine(Question.Answer3);
                Console.WriteLine(Question.Answer4);
            }
        }


    }
}

