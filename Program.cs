using AutoCar.Application;
using AutoCar.Domain.ValueObjects;

Console.WriteLine("Enter width and height of the field in integer");
int GetValidIntegerInput(string message)
{
    int value;
    bool isValid;

    do
    {
        Console.Write(message);
        isValid = int.TryParse(Console.ReadLine(), out value);

        if (!isValid)
        {
            Console.WriteLine("Invalid integer value. Please enter a valid integer.");
        }

    } while (!isValid);

    return value;
}

char GetValidDirection()
{ 
    char value;
    bool isValid;
    do
    {
        Console.Write("Enter a direction: ");
        value = Console.ReadKey().KeyChar;
        isValid = IsValidDirection(value);
        if (!isValid)
        {
            Console.WriteLine("Invalid direction. Please enter a valid direction");
        }
        Console.WriteLine();
    } while (!isValid);
    return value;
}

string GetValidCommands()
{
    string command;
    bool isValid;
    do
    {
        Console.Write("Enter commands: ");
        command = Console.ReadLine();
        isValid = !string.IsNullOrEmpty(command) && command.Trim().All(c => c == 'R' || c == 'r' || c == 'L' || c == 'l' || c == 'F' || c == 'f');
        if (!isValid)
        {
            Console.WriteLine("Invalid commands. Only allow commands are R/r/L/l/F/f. Please enter valid command");
        }
    }while (!isValid);
    return command;
}


bool IsValidDirection(char direction)
{
    if (direction == 'N' || direction == 'n'|| direction == 'S' || direction == 's' || direction == 'E' || direction == 'e' || direction == 'W' || direction == 'w')
    {
        return true;
    }
    return false;
}


int width = GetValidIntegerInput("Enter width: ");
int height = GetValidIntegerInput("Enter height: ");
Console.WriteLine("Enter initial positon in X and Y coordinates");
int xCordinate = GetValidIntegerInput("Enter X cordinate: ");
int yCordinate = GetValidIntegerInput("Enter Y cordinate: ");
var direction = GetValidDirection();
var commands = GetValidCommands();
var autoDrivingCarService = new AutoDrivingCarService();
autoDrivingCarService.SimulateAutoDrivingCar(width, height, new Position(xCordinate, yCordinate, direction.ToString()), commands);


