using ConsoleFunctions.Dependencies;
using static ConsoleFunctions.Console_Functions;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Image Wizard!");

#region Common vars

string[] options = { "Create Style Shit" };

ConsoleKeyInfo Option;

string pathToExe = Environment.CurrentDirectory;

string pathToInput = Environment.CurrentDirectory + 
    Path.DirectorySeparatorChar + "Input";

string pathToOutput = Environment.CurrentDirectory +
    Path.DirectorySeparatorChar + "Output";

bool? resize = null;

float newWidth;

float newHeight;

ImageWizardCore.ImageWizard imgwiz = new ImageWizardCore.ImageWizard(pathToInput, pathToOutput);

#endregion

PrintMessage("Welcome! This software will help you to process images.", ConsoleColor.Green);

do
{    
    PrintMessage("Choose an Option:(Just press option number)", ConsoleColor.Yellow);

    int iter = 1;

    foreach (var option in options)
    {
        PrintMessage($"To {option} press {iter}", ConsoleColor.Cyan);

        iter++;
    }

    Option = Console.ReadKey();

    switch (Option.Key)
    {
        case ConsoleKey.NumPad1:

            PrintMessage($"Selected Option: {options[0]}", ConsoleColor.Green);

            //Build Sprite Shit



            resize = ConsoleInput<bool?>("Do You need resize? Y/N", ConsoleColor.Yellow,
                new StringToBoolConverter(), new NullableBoolValidator());

            if (resize != null)
            {
                if ((bool)resize)
                {
                    PrintMessage($"Selected Option: {options[0]}", ConsoleColor.Green);
                }                
            }

            imgwiz.CreateSpriteShit();

            break;

        default:
            break;
    }


} while (!(KeyInput("Press q if you want to quite application, otherwise press any key", ConsoleColor.Red).Key.Equals(ConsoleKey.Q)));




