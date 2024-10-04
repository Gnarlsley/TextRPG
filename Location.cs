namespace TextRPG
{
    class Location
    {
        public int[] coordinates { get; set; }
        public string description { get; set; }
        public string examineText { get; set; }
        public string[] approachText { get; set; }
     //   public Dictionary<string, ItemInfo> contents = new Dictionary<string, ItemInfo>();
        public Random rdm = new Random();

        public Location ()
        {
            coordinates = new int[] {rdm.Next(-16, 17), rdm.Next(-16, 17), 0};
            description = "This is a random place";
            examineText = "This place seems familiar";
            approachText = new string[] {"You are nearing a location", "You hear faint chanting", "You feel the warmth of a burning pyre"};
      //      contents.Add("Potion", new ItemInfo("A healing potion", 3));
      //      contents.Add("Sword", new ItemInfo("A sharp blade", 1));
        }
    }
}