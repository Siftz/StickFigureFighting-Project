namespace StickFigureFighting;

class Warrior : Character
{
    public Warrior(int posX, int posY) : base("Warrior", "shield and sword", 30, 4, posX, posY) { }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"You have chosen: {ClassName} wielding a {Weapon}");
    }
}