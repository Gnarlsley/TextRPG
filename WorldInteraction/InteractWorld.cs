using Utilities;
using TextRPG;
using DialogueType;
using EntityType;
namespace WorldInteraction
{
    static class InteractWorld
    {
        public static void StartBattle(Player player)
        {
            Location? currentLocation = MapUtility.GetLocation();

            if (currentLocation != null && currentLocation.Enemies != null)
            {
                if (currentLocation.Enemies.Count > 0)
                {
                    TurnManager turnManager = new TurnManager(player, currentLocation.Enemies);
                    turnManager.StartTurn();
                }
                else
                {
                    Console.WriteLine("There are no enemies left");
                }
            }
            else
            {
                Console.WriteLine("There is no need to fight");
            }
        }
        public static void InteractLocation()
        {
            Location? currentLocation = MapUtility.GetLocation();

            if (currentLocation != null && currentLocation.NPC != null)
            {
                Console.WriteLine("You choose to speak to the person in front of you.");
                Console.WriteLine("What do you say? Choices:\n1 - Hello\n2 - *stay silent*\n3 - You look weak");

                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (IsValidInput(input))
                    {
                        HandleDialogue(input, currentLocation.NPC.Dialogues);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please choose 1, 2, or 3.");
                    }
                }
            }
            else
            {
                Console.WriteLine("There's no one there.");
            }
        }

        private static bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3";
        }

        private static void HandleDialogue(string input, List<Dialogue> dialogues)
        {
            var moodMap = new Dictionary<string, DialogueType.Mood>
            {
                { "1", DialogueType.Mood.Positive },
                { "2", DialogueType.Mood.Neutral },
                { "3", DialogueType.Mood.Negative }
            };

            var selectedMood = moodMap[input];

            // Find and display the appropriate response
            var response = dialogues.FirstOrDefault(d => d.Mood == selectedMood);
            
            if (response != null)
            {
                Console.WriteLine(response.Response);
            }
            else
            {
                Console.WriteLine("The NPC has nothing to say.");
            }
        }
    }
}