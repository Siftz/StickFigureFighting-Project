namespace StickFigureFighting;

public class CombatManager
{
    private Character player; //I should have put this as _player and same with boss and the combat managers it does fit
    private Boss boss;
    private PlayerCombatManager playerCombatManager;
    private BossCombatManager bossCombatManager;

    public CombatManager(Character player, Boss boss)
    {
        this.player = player;
        this.boss = boss;
        playerCombatManager = new PlayerCombatManager(player, boss);
        bossCombatManager = new BossCombatManager(boss, player);
    }

    public void StartCombat() // Combat overall start and setting the game is running and needs loops
    {
        bool gameRunning = true;
        while (gameRunning)
        {
            Console.Clear(); //clear console at the start of loop
            DrawCharacters();
            // Turn-based combat
            playerCombatManager.PlayerTurn(); //players turn
            if (boss.Health <= 0) //check to see if boss is defeated
            {
                Console.WriteLine("You defeated the boss!");
                gameRunning = false;
                break;
            }
            
            // Pause to allow the player to see the results
            Console.WriteLine("\nPress any key for the boss's turn...");
            Console.ReadKey();

            // Clear console before the boss's turn
            Console.Clear();
            DrawCharacters();

            bossCombatManager.BossTurn();
            if (player.Health <= 0) //check if player is dead
            {
                Console.WriteLine("You were defeated by the boss...");
                gameRunning = false;
                break;
            }
            // Pause to allow the player to see the results
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            // Reduce cooldowns
            ReduceCooldowns();
        }
    }

    private void DrawCharacters()
    {
        player.Draw();
        boss.Draw();
    }

    private void ReduceCooldowns() //cd block
    {
        if (player.BlockCooldown > 0)
            player.BlockCooldown--;
        if (player.HeroicBlastCooldown > 0)
            player.HeroicBlastCooldown--;
        if (player.BerserkerFrenzyCooldown > 0)
            player.BerserkerFrenzyCooldown--;
        if (player.PainShrugCooldown > 0)
            player.PainShrugCooldown--;
        if (player.DodgeCooldown > 0)
            player.DodgeCooldown--;
        if (boss.HealCooldown > 0)
            boss.HealCooldown--;
        if (boss.MiseryStrikeCooldown > 0)
            boss.MiseryStrikeCooldown--;
    }
}
