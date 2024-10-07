using DialogueType;
using EntityType;

namespace TextRPG
{
    class Location : IExaminable
    {
        public int[] Coordinates { get; set; }
        public string Description { get; set; }
        public string DisplayText { get; set; }
        public string[] ApproachText { get; set; }
        public List<Enemy> Enemies { get; set; }
        public NPC? NPC { get; set; }

     //   public Dictionary<string, ItemInfo> contents = new Dictionary<string, ItemInfo>();
        public Random rdm = new Random();

        public Location ()
        {
            Coordinates = new int[] {rdm.Next(-16, 17), rdm.Next(-16, 17), 0};
            Description = "This is a random place";
            DisplayText = "This place seems familiar";
            ApproachText = new string[] {"You are nearing a location", "You hear faint chanting", "You feel the warmth of a burning pyre"};
            NPC = null;
      //      contents.Add("Potion", new ItemInfo("A healing potion", 3));
      //      contents.Add("Sword", new ItemInfo("A sharp blade", 1));
        }
        public Location (int[] Coordinates, string Description, string DisplayText, string[] ApproachText, NPC npc)
        {
            this.Coordinates = Coordinates;
            this.Description = Description;
            this.DisplayText = DisplayText;
            this.ApproachText = ApproachText;
            this.NPC = npc;
        }
        public void Display()
        {
            Console.WriteLine(this.DisplayText);
        }
    }
}