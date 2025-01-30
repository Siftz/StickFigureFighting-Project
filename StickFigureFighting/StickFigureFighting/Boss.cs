namespace StickFigureFighting;

public class Boss : Character
{
    public int HealCooldown { get; set; }
    public int MiseryStrikeCooldown { get; set; }

    public Boss(int posX, int posY) : base("Boss", "2-handed sword", 40, 4, posX, posY) { }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"An enemy {ClassName} appears, wielding a {Weapon}!");
    }

    public override void Draw()
    {
        Console.SetCursorPosition(PositionX, PositionY - 2);
        Console.WriteLine("  O ");
        Console.SetCursorPosition(PositionX, PositionY - 1);
        Console.WriteLine(" /|\\ ");
        Console.SetCursorPosition(PositionX, PositionY);
        Console.WriteLine("/ | \\ ");
        Console.SetCursorPosition(PositionX, PositionY + 1);
        Console.WriteLine("  | ");
        Console.SetCursorPosition(PositionX, PositionY + 2);
        Console.WriteLine(" / \\");
    }

    public void Attack(Character target)
    {
        Console.WriteLine($"{ClassName} attacks {target.ClassName} with {Weapon}!");
        int damage = NormalDamage;
        target.Health -= damage;
        Console.WriteLine($"{target.ClassName} has {target.Health} health left.");
    }

    public void Heal()
    {
        Console.WriteLine($"{ClassName} heals!");
        Health += Health / 1; // heal for 10%
        Console.WriteLine($"{ClassName} now has {Health} health.");
        HealCooldown = 3;
    }

    public void MiseryStrike(Character target)
    {
        Console.WriteLine($"{ClassName} performs a Misery Strike at {target.ClassName}!");
        int damage = NormalDamage * 2;
        target.Health -= damage;
        Console.WriteLine($"{target.ClassName} has {target.Health} health left.");
        MiseryStrikeCooldown = 2;
    }
}