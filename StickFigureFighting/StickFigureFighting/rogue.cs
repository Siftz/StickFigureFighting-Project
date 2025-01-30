namespace StickFigureFighting;

class Rogue : Character
{
    public Rogue(int posX, int posY) : base("Rogue", "2 daggers", 25, 3, posX, posY) { }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"You have chosen: {ClassName} wielding a {Weapon}");
    }
}