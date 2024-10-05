namespace EntityType
{
    class Player : Entity
    {
        public int[] ConsumableCharges { get; set; }

        public Player(string name, int health, int damage, int luck, int speed, int dexterity, int defense) 
        {
            Name = name;
            Health = health;
            Damage = damage;
            Luck = luck;
            Speed = speed;
            Dexterity = dexterity;
            Defense = defense;
            ConsumableCharges = [3];
        }
        public string DisplayCharges()
        {
            string msg = "";
            if(this.Health != -1)
            {
                msg += "Charges available:\nDivine: " + this.ConsumableCharges[0];
            }
            return msg;
        }
    }
}