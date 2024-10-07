using DialogueType;

namespace EntityType
{
    class Enemy : Entity, IExaminable
    {
       public string DisplayText { get; set; }

        public Enemy(string name, int health, int damage, int defense, int dexterity, int speed, int luck)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Defense = defense;
            Dexterity = dexterity;
            Speed = speed;
            Luck = luck;
            DisplayText = "A ferocious monster";
        }
        public void Display()
        {
            Console.WriteLine(DisplayText);
        }
    }
}