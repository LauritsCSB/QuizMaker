using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
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

        public static void SerializeToXML(string path, List<QuizCard> data)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, data);
            }
        }

        public static List<QuizCard> DeSerealizeFromXML(string path, List<QuizCard> data)
        {
            using (FileStream file = File.OpenRead(path))
            {
                return serializer.Deserialize(file) as List<QuizCard>;
            }
        }
    }

}

