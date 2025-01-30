namespace StickFigureFighting;

public abstract class Character
{
        public string ClassName { get; set; }
        public string Weapon { get; set; }
        public int Health { get; set; }
        public int NormalDamage { get; set; }

        public int BlockCooldown { get; set; }
        public int HeroicBlastCooldown { get; set; }
        public int BerserkerFrenzyCooldown { get; set; }
        public int PainShrugCooldown { get; set; }
        public int DodgeCooldown { get; set; }

        public bool IsBlocking { get; set; }
        public bool IsHeroicBlast { get; set; }
        public bool IsBerserk { get; set; }
        public bool IsDodging { get; set; }
        public bool IsPremeditated { get; set; }
        
        public bool IsBloockingNext { get; set; }
        public bool IsDodgingNext { get; set; }
        
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Character(string className, string weapon, int health, int normalDamage, int posX, int posY)
        {
            ClassName = className;
            Weapon = weapon;
            Health = health;
            NormalDamage = normalDamage;
            PositionX = posX;
            PositionY = posY;
        }

        public abstract void DisplayCharacter();

        public virtual void Draw()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.WriteLine(" O ");
            Console.SetCursorPosition(PositionX, PositionY + 1);
            Console.WriteLine("/|\\");
            Console.SetCursorPosition(PositionX, PositionY + 2);
            Console.WriteLine("/ \\");
        }

        public virtual void SwordSlash(Character target)
        {
            Console.WriteLine($"{ClassName} performs a Sword Slash at {target.ClassName}!");
            int damage = IsHeroicBlast ? NormalDamage * 3 : NormalDamage;
            target.Health -= damage;
            Console.WriteLine($"{target.ClassName} has {target.Health} health left.");
            IsHeroicBlast = false; // reset Heroic Blast state
        }

        public virtual void Block()
        {
            if (BlockCooldown > 0)
            {
                Console.WriteLine("Block is on cooldown!");
            }
            else
            {
                Console.WriteLine($"{ClassName} raises the shield to block the next attack!");
                IsBlocking = true;
                BlockCooldown = 2;
            }
        }

        public virtual void HeroicBlast()
        {
            if (HeroicBlastCooldown > 0)
            {
                Console.WriteLine("Heroic Blast is on cooldown!");
            }
            else
            {
                Console.WriteLine($"{ClassName} prepares for a Heroic Blast!");
                IsHeroicBlast = true;
                HeroicBlastCooldown = 2;
            }
        }

        public virtual void RecklessSlash(Character target)
        {
            Console.WriteLine($"{ClassName} performs a Reckless Slash at {target.ClassName}!");
            int damage = NormalDamage * 2;
            target.Health -= damage;
            Console.WriteLine($"{target.ClassName} has {target.Health} health left.");
        }

        public virtual void BerserkerFrenzy()
        {
            if (BerserkerFrenzyCooldown > 0)
            {
                Console.WriteLine("Berserker Frenzy is on cooldown!");
            }
            else
            {
                Console.WriteLine($"{ClassName} enters a Berserker Frenzy!");
                IsBerserk = true;
                BerserkerFrenzyCooldown = 3;
            }
        }

        public virtual void PainShrug()
        {
            if (PainShrugCooldown > 0)
            {
                Console.WriteLine("Pain Shrug is on cooldown!");
            }
            else
            {
                Console.WriteLine($"{ClassName} prepares to shrug off pain!");
                PainShrugCooldown = 3;
            }
        }

        public virtual void Eviscerate(Character target)
        {
            Console.WriteLine($"{ClassName} performs an Eviscerate at {target.ClassName}!");
            int damage = NormalDamage * 2;
            target.Health -= damage;
            Console.WriteLine($"{target.ClassName} has {target.Health} health left.");
        }

        public virtual void Dodge()
        {
            if (DodgeCooldown > 0)
            {
                Console.WriteLine("Dodge is on cooldown!");
            }
            else
            {
                Console.WriteLine($"{ClassName} prepares to dodge the next attack!");
                IsDodging = true;
                DodgeCooldown = 3;
            }
        }

        public virtual void Premeditate()
        {
            Console.WriteLine($"{ClassName} is premeditating!");
            IsPremeditated = true;
        }
}