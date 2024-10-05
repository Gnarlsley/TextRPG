namespace DialogueType
{
    public enum Mood
    {
        Positive,
        Neutral,
        Negative
    }
    class Dialogue
    {
        public string Response { get; set; }
        public Mood Mood { get; set; }

        public Dialogue(string Text, Mood MoodType)
        {
            Response = Text;
            Mood = MoodType;
        }
    }
}