using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
        const string PATH = "QuizData.xml";

        public static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        public static int SelectRandomQuestion(int max)
        {
            int randomNumber = Program.random.Next(max);
            return randomNumber;
        }

        public static bool CheckAnswer(QuizCard currentQuestion, int pickedAnswer)
        {
            return currentQuestion.Answers[pickedAnswer].Contains("*");
        }

        public static void SerializeToXML(List<QuizCard> data)
        {
            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, data);
            }
        }

        public static List<QuizCard> DeSerealizeFromXML()
        {
            using (FileStream file = File.OpenRead(PATH))
            {
                return serializer.Deserialize(file) as List<QuizCard>;
            }
        }
    }

}

