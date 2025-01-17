using System;

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Explore");
    Console.WriteLine("2. Check Status");
    Console.WriteLine("3. Quit");
    Console.Write("Choose an option: ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("You explore the world...");
            break;
        case "2":
            Console.WriteLine("Your health is 100. Your score is 0.");
            break;
        case "3":
            Console.WriteLine("Goodbye!");
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}

