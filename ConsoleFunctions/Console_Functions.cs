using ConsoleFunctions.Dependencies.Interfaces;

namespace ConsoleFunctions
{
    public static class Console_Functions
    {
        #region Methods

        public static void PrintMessage(string msg, ConsoleColor color)
        { 
            Console.ForegroundColor = color;

            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.ResetColor();
        }

        public static Tout ConsoleInput<Tout>(string msg, ConsoleColor color, 
            IConverter<Tout, string> converter)
        {
            Tout output;

            string str = String.Empty;

            do
            {
                PrintMessage(msg, color);

                str = Console.ReadLine();
                                
            } while (!converter.Convert(str, out output));

            return output;
        }

        public static ConsoleKeyInfo KeyInput(string msg, ConsoleColor color)
        {
            PrintMessage(msg, color);
            
            var k =Console.ReadKey();

            return k;
        }

        #endregion
    }
}