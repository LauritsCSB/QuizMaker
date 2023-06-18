using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
        const string PATH = "QuizData.xml";

        public static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        /// <summary>
        /// uses random method to pick a random integer from 0 and max amount of questions in XML file
        /// </summary>
        /// <param name="max"></param>
        /// <returns>random number</returns>
        public static int SelectRandomQuestion(int max)
        {
            int randomNumber = Program.random.Next(max);
            return randomNumber;
        }

        /// <summary>
        /// checks if the answer index given by user refers to the correct answer saved in list
        /// </summary>
        /// <param name="currentQuestion"></param>
        /// <param name="pickedAnswer"></param>
        /// <returns>boolean referring to if answer was correct</returns>
        public static bool CheckAnswer(QuizCard currentQuestion, int pickedAnswer)
        {
            bool win;

            if (currentQuestion.Answers[pickedAnswer].Contains('*'))
            {
                win = true;
            }
            else
            {
                win = false;
            }
          
            return win;
        }

        /// <summary>
        /// serealizes list of QuizCards til XML list
        /// </summary>
        /// <param name="data"></param>
        public static void SerializeToXML(List<QuizCard> data)
        {
            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, data);
            }
        }

        /// <summary>
        /// deserealizes from XML file
        /// </summary>
        /// <returns>list of quizcards</returns>
        public static List<QuizCard> DeSerealizeFromXML()
        {
            using (FileStream file = File.OpenRead(PATH))
            {
                return serializer.Deserialize(file) as List<QuizCard>;
            }
        }
    }

}

