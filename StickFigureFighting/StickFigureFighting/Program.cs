using System;
using System.Text;
namespace StickFigureFighting;

abstract class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; //wanted to add unicode
        
        ShowWelcomeScreen();
        Console.Clear(); // Clear the welcome screen

        Character player = ChooseCharacterClass();
        Console.Clear(); // Clear the selection screen

        Boss boss = new Boss(30, 5);
        CombatManager combatManager = new CombatManager(player, boss);
            
        combatManager.StartCombat();
    }
    static void ShowWelcomeScreen()
    {
        Console.WriteLine("**************************");
        Console.WriteLine("*                        *");
        Console.WriteLine("*   GET READY TO FIGHT   *");
        Console.WriteLine("*                        *");
        Console.WriteLine("**************************");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey(true); // Wait for the user to press a key
    }

    public static Character ChooseCharacterClass() //user character choice
    {
        Console.WriteLine("Choose your class:");
        Console.WriteLine("1. Berserker (2-handed axe)");
        Console.WriteLine("2. Warrior (shield and sword)");
        Console.WriteLine("3. Rogue (2 daggers)");
            
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                return new Berserker(5, 5); // Set initial position for Berserker
            case 2:
                return new Warrior(5, 5); // Set initial position for Warrior
            case 3:
                return new Rogue(5, 5); // Set initial position for Rogue
            default:
                Console.WriteLine("Invalid choice. Defaulting to Warrior.");
                return new Warrior(5, 5); // Set initial position for default Warrior
        }
    }

    static void DrawStickFigure(int x, int y) //User stick figure
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(" O ");
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine("/|\\");
        Console.SetCursorPosition(x, y + 2);
        Console.WriteLine(" | ");
        Console.SetCursorPosition(x, y + 3);
        Console.WriteLine("/ \\");
    }
    static void DrawBoss(int x, int y) //Boss stick figure
    {
        Console.SetCursorPosition(x, y - 2);
        Console.WriteLine("  O ");
        Console.SetCursorPosition(x, y - 1);
        Console.WriteLine(" /|\\ ");
        Console.SetCursorPosition(x, y);
        Console.WriteLine("/ | \\ ");
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine("  | ");
        Console.SetCursorPosition(x, y + 2);
        Console.WriteLine(" / \\");
    }
}
