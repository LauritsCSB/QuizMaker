using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
        public const string path = "QuizData.xml";
        public static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        public static int SelectRandomQuestion(int max)
        {
            int randomNumber = Program.random.Next(max);
            return randomNumber;
        }

        public static bool CheckAnswer(List<string> answersList, int pickedAnswer)
        {
            bool win = false;

            if (pickedAnswer > 0 && pickedAnswer <= answersList.Count)
            {
                if (answersList[pickedAnswer].Contains('*'))
                {
                    win = true;
                }
                else
                {
                    win = false;
                }
            }

            return win;
        }

        public static void SerializeToXML()
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, Program.QuestionsList);
            }
        }

        public static void DeSerealizeFromXML()
        {
            using (FileStream file = File.OpenRead(path))
            {
                Program.QuestionsList = serializer.Deserialize(file) as List<QuizCard>;
            }
        }
    }

}

