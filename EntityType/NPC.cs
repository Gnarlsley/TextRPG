using DialogueType;
namespace EntityType
{
    public enum Mood
    {
        Positive,
        Neutral,
        Negative
    }
    class NPC : Entity, IExaminable
    {
        public List<Dialogue> Dialogues { get; set; }
        public string DisplayText { get; set; }

        public NPC(string name, int health, int damage, int luck, int speed, int dexterity, int defense) 
        {
            Name = name;
            Health = health;
            Damage = damage;
            Luck = luck;
            Speed = speed;
            Dexterity = dexterity;
            Defense = defense;
            Dialogues = new List<Dialogue>();
        }
        public void Display()
        {
            Console.WriteLine(this.DisplayText);
        }
    }
}