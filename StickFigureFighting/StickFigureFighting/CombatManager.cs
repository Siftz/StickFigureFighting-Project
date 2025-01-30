namespace StickFigureFighting;

public class CombatManager
{
    private Character player; // I should have put this as _player and same with boss and the combat managers it does fit
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
            Console.Clear(); // Clear console at the start of loop
            DrawCharacters();

            // Turn-based combat

            // Player's turn
            playerCombatManager.PlayerTurn(); // Player's turn

            if (boss.Health <= 0) // Check to see if boss is defeated
            {
                // Instead of just displaying a message, we'll show the victory screen
                // Console.WriteLine("You defeated the boss!");
                ShowVictoryScreen(); // <-- Added call to ShowVictoryScreen()
                gameRunning = false;
                break;
            }

            // Pause to allow the player to see the results
            Console.WriteLine("\nPress any key for the boss's turn...");
            Console.ReadKey();

            // Clear console before the boss's turn
            Console.Clear();
            DrawCharacters();

            // Boss's turn
            bossCombatManager.BossTurn();

            if (player.Health <= 0) // Check if player is defeated
            {
                // Instead of just displaying a message, we'll show the defeat screen
                // Console.WriteLine("You were defeated by the boss...");
                ShowDefeatScreen(); // <-- Added call to ShowDefeatScreen()
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

    private void ReduceCooldowns() // cd block
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

    // Added methods for the victory and defeat screens

    private void ShowVictoryScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*   🎉 CONGRATULATIONS! YOUR EFFORTS   *");
        Console.WriteLine("*         HAVE BROUGHT YOU GLORY!!     *");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        Environment.Exit(0); // Exits the application
    }

    private void ShowDefeatScreen() // defeat screen
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*  💀 YOU FOUGHT VALIANTLY BUT IN VAIN *");
        Console.WriteLine("*           WOULD YOU LIKE             *");
        Console.WriteLine("*            TO TRY AGAIN?             *");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
        Console.WriteLine("\nPress 'Y' to retry or any other key to exit...");

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Y)
        {
            RestartGame();
        }
        else
        {
            Environment.Exit(0); // Exits the application
        }
    }

    private void RestartGame()
    {
        // Re-initialize the game
        Console.Clear();
        
        Character newPlayer = Program.ChooseCharacterClass();
        Console.Clear();

        Boss newBoss = new Boss(30, 5); // Initialize boss with appropriate stats

        CombatManager newCombatManager = new CombatManager(newPlayer, newBoss);
        newCombatManager.StartCombat();
    }
}
