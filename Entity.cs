namespace TextRPG
{
    class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Luck { get; set; }
        public int Speed { get; set; }
        public int Dexterity { get; set; }
        public int Defense { get; set; }

        public Entity(string name, int health, int damage, int luck, int speed, int dexterity, int defense) 
        {
            Name = name;
            Health = health;
            Damage = damage;
            Luck = luck;
            Speed = speed;
            Dexterity = dexterity;
            Defense = defense;
        }

        public Entity()
        {
            Name = "Unknown";
            Health = -1;
            Damage = -1;
            Luck = -1;
            Speed = -1;
            Dexterity = -1;
        }


        public string displayStats()
        {
            string msg = "";
            if(this.Health == -1)
            {
                msg += "Name: unknown\n" +
                        "Health: unknown\n" +
                        "Damage: unknown\n" +
                        "Luck: unknown\n" +
                        "Speed: unknown\n" +
                        "Dexterity: unknown\n" +
                        "Defense: unknown";
            }
            else
            {
                msg += "Name: " + this.Name + 
                    "\nHealth: " + this.Health + 
                    "\nDamage: " + this.Damage + 
                    "\nLuck: " + this.Luck + 
                    "\nSpeed: " + this.Speed + 
                    "\nDexterity: " + this.Dexterity + 
                    "\nDefense: " + this.Defense;
            }
            return msg;
        }
    }
}



