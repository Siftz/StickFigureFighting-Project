namespace StickFigureFighting;

class Berserker : Character
{
    public Berserker(int posX, int posY) : base("Berserker", "2-handed axe", 40, 5, posX, posY) { }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"You have chosen: {ClassName} wielding a {Weapon}");
    }
}