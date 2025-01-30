namespace StickFigureFighting;

public class BossCombatManager
{
    
    private Boss boss;
    private Character player;
    private Random random = new Random();

    public BossCombatManager(Boss boss, Character player)
    {
        this.boss = boss;
        this.player = player;
    }

    public void BossTurn()
    {
        bool actionTaken = false;
        while (!actionTaken)
        {
            int choice = random.Next(1, 4);
            switch (choice)
            {
                case 1:
                    boss.Attack(player);
                    actionTaken = true;
                    break;
                case 2:
                    if (boss.HealCooldown == 0)
                    {
                        boss.Heal();
                        actionTaken = true;
                    }
                    break;
                case 3:
                    if (boss.MiseryStrikeCooldown == 0)
                    {
                        boss.MiseryStrike(player);
                        actionTaken = true;
                    }
                    break;
            }
        }
    }
}