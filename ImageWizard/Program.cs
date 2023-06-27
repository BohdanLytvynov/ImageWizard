using ConsoleFunctions.Dependencies;
using static ConsoleFunctions.Console_Functions;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Image Wizard!");

#region Common vars

string[] options = { "Create Style Shit" };

byte Option;

string pathToExe = Environment.CurrentDirectory;

string pathToInput = Environment.CurrentDirectory +
    Path.DirectorySeparatorChar + "Input";

string pathToOutput = Environment.CurrentDirectory +
    Path.DirectorySeparatorChar + "Output";

bool resize = false;

float newWidth;

float newHeight;

ImageWizardCore.ImageWizard imgwiz = new ImageWizardCore.ImageWizard(pathToInput, pathToOutput);

#region Converters

StringToBoolConverter stringToBool = new StringToBoolConverter();

StringToByteConverter stringToByteOption = new StringToByteConverter(
    (v)=>
    {
        switch (v)
        {
            case 1:
                return true;
            default:

                PrintMessage("Incorrect Command!", ConsoleColor.Red);

                return false;
        }
    }
    );

#endregion

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

    Option = ConsoleInput<byte>("Wait for Input", ConsoleColor.Yellow,
        stringToByteOption);

    switch (Option)
    {
        case 1:

            PrintMessage($"Selected Option: {options[0]}", ConsoleColor.Green);

            //Build Sprite Shit

            int CanvasWidth = ConsoleInput("Enter Canvas Width", ConsoleColor.Yellow,
                new StringToIntConverter(v => { return v > 0; }));

            int CanvasHeight = ConsoleInput("Enter Canvas Height", ConsoleColor.Yellow,
                new StringToIntConverter(v => { return v > 0; }));

            float imgWidth = ConsoleInput("Enter Image Width", ConsoleColor.Yellow,
                new StringToIntConverter(v => { return v > 0; }));

            float imgHeight = ConsoleInput("Enter Image Height", ConsoleColor.Yellow,
                new StringToIntConverter(v => { return v > 0; }));

            resize = ConsoleInput("Do You need resize? Y/N", ConsoleColor.Yellow,
                stringToBool);

            if (resize)
            {
                PrintMessage($"Resize Option was checked!", ConsoleColor.Yellow);
            }

            imgwiz.CreateSpriteShit(imgWidth, imgHeight, CanvasWidth, CanvasHeight, 
                resize);

            break;

        default:
            break;
    }


} while (!(KeyInput("Press q if you want to quite application, otherwise press any key", ConsoleColor.Red).Key.Equals(ConsoleKey.Q)));




