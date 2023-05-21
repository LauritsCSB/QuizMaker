namespace QuizMaker;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionClass>));
        var path = Directory.GetCurrentDirectory() + @"/QuizData.xml";
        List<QuestionClass> QuestionsList = new List<QuestionClass>();
        List<string> answersList = new List<string>();

        UIMethods.WelcomeMessage();

        int decider = 0;
        while (decider < 1 || decider > 2)
        {
            Int32.TryParse(Console.ReadLine(), out decider);
            Console.WriteLine("Try again: ");
        }

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
                QuestionsList = serializer.Deserialize(file) as List<QuestionClass>;
            }

            int questionIndex = LogicMethods.SelectRandomQuestion(QuestionsList.Count);
            UIMethods.DisplayQuestion(QuestionsList, questionIndex);
            UIMethods.DisplayAnswers(QuestionsList, answersList, questionIndex);

            int pickedAnswer = -1;

            do
            {
                pickedAnswer = UIMethods.PickAnswer(answersList) - 1;
                if (pickedAnswer < 0 || pickedAnswer > answersList.Count)
                {
                    Console.WriteLine("Try again");
                    continue;
                }

                if (pickedAnswer > 0 && pickedAnswer <= answersList.Count)
                {
                    if (answersList[pickedAnswer].Contains('*'))
                    {
                        Console.WriteLine("Correct!");
                    }

                }
            } while (pickedAnswer < 0 || pickedAnswer > answersList.Count);
        }
    }
}

