namespace StickFigureFighting;

public class PlayerCombatManager
{
    private Character player;
    private Character boss;

    public PlayerCombatManager(Character player, Character boss)
    {
        this.player = player;
        this.boss = boss;
    }

    public void PlayerTurn()
    {
        bool validChoice = false;
        while (!validChoice)
        {
            Console.WriteLine("Your turn!");
            if (player is Warrior)
            {
                Console.WriteLine("1. Sword Slash");
                Console.WriteLine("2. Block");
                Console.WriteLine("3. Heroic Blast");
            }
            else if (player is Berserker)
            {
                Console.WriteLine("1. Reckless Slash");
                Console.WriteLine("2. Berserker Frenzy");
                Console.WriteLine("3. Pain Shrug");
            }
            else if (player is Rogue)
            {
                Console.WriteLine("1. Eviscerate");
                Console.WriteLine("2. Dodge");
                Console.WriteLine("3. Premeditate");
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        if (player is Warrior)
                            player.SwordSlash(boss);
                        else if (player is Berserker)
                            player.RecklessSlash(boss);
                        else if (player is Rogue)
                            player.Eviscerate(boss);
                        validChoice = true;
                        break;
                    case 2:
                        if (player is Warrior)
                            player.Block();
                        else if (player is Berserker)
                            player.BerserkerFrenzy();
                        else if (player is Rogue)
                            player.Dodge();
                        validChoice = true;
                        break;
                    case 3:
                        if (player is Warrior)
                            player.HeroicBlast();
                        else if (player is Berserker)
                            player.PainShrug();
                        else if (player is Rogue)
                            player.Premeditate();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
    