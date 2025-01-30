namespace StickFigureFighting;

class Berserker : Character
{
    public Berserker(int posX, int posY) : base("Berserker", "2-handed axe", 60, 5, posX, posY) { }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"You have chosen: {ClassName} wielding a {Weapon}");
    }
    public override void Draw()
    {
        // Drawing the Berserker's body
        Console.SetCursorPosition(PositionX, PositionY - 1);
        Console.WriteLine("  O(<x>)    ");  //Head and axe head
        Console.SetCursorPosition(PositionX, PositionY);
        Console.WriteLine(" /|\\ |"); // Arms and weapon handle
        Console.SetCursorPosition(PositionX, PositionY + 1);
        Console.WriteLine("/ | \\|");  // Body and weapon handle
        Console.SetCursorPosition(PositionX, PositionY + 2);
        Console.WriteLine(" / \\ |"); // Legs and weapon handle
    }
}