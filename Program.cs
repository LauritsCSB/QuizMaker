namespace QuizMaker;
class Program
{
    static void Main(string[] args)
    {
        UIMethods.WelcomeMessage();

        while (Console.ReadKey(true).Key != ConsoleKey.D2)
        {
            var question1 = new Question();
            UIMethods.PromptForSaveAndExit();
        }

        
    }
}

