namespace TextRPG
{
    class ItemInfo
    {
        public string Description { get; set; }
        public int Quantity { get; set; }

        public ItemInfo(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }
    }
}