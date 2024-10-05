using Utilities;
using TextRPG;
using EntityType;
using DialogueType;
using WorldInteraction;
enum Direction
{
    North,
    South,
    East,
    West
}

class GamePanel
{
    //List of variables used by other files
    public static bool isTaskRunning = false;
    public static List<string> commandHistory = new List<string>();
    public static int historyIndex = -1;
    public static int historyMaximum = 5;
    public static int[] position = {0, 0, 0};
    public static Location[] mapLocations;
    public static string input;

    static void Main(string[] args)
    {
        Player player = InitializePlayer();

        //TESTING SPACE
        for (int i = 0; i < mapLocations.Length; i++)
        {
            Console.WriteLine("X: " + mapLocations[i].Coordinates[0] + " Y: " + mapLocations[i].Coordinates[1] + " Z: " + mapLocations[i].Coordinates[2]);
        }
        //END TESTING SPACE

        var commandActions = InitializeCommandActions(player);
        InitializeNPC();
        
        GameLoop(commandActions);
    }

    static void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                position[1]++;
                Console.WriteLine("You walk north");
                break;
            case Direction.South:
                position[1]--;
                Console.WriteLine("You walk south");
                break;
            case Direction.East:
                position[0]++;
                Console.WriteLine("You walk east");
                break;
            case Direction.West:
                position[0]--;
                Console.WriteLine("You walk west");
                break;
        }
    }

     private static Dictionary<string[], Action> InitializeCommandActions(Player player)
    {
        return new Dictionary<string[], Action>
        {
            { new[] { "North", "N", "1" }, () => Move(Direction.North) },
            { new[] { "South", "S", "2" }, () => Move(Direction.South) },
            { new[] { "East", "E", "3" }, () => Move(Direction.East) },
            { new[] { "West", "W", "4" }, () => Move(Direction.West) },
            { new[] { "clear" }, Console.Clear },
            { new[] { "ping", "locate" }, MapUtility.CheckNearbyLocations },
            //divine command uses reference variable so player charges attribute is changed everywhere
            { new[] { "divine" }, () => MapUtility.CheckNearbyLocationsWithDirection(ref player.ConsumableCharges[0]) },
            { new[] { "position" }, MapUtility.GetCurrentCoordinates },
            { new[] { "examine", "look around" }, MapUtility.examineLocation },
            { new[] { "charges" }, () => Console.WriteLine(player.DisplayCharges()) },
            { new[] { "stats" }, () => Console.WriteLine(player.DisplayStats()) },
            { new[] { "talk", "speak" }, () => InteractWorld.InteractLocation()}
        };
    }

    private static Player InitializePlayer()
    {
        Console.Clear();
        Console.WriteLine("TEXT RPG TALES");
        Console.WriteLine("Choose a name for your hero...");
        string? name = Console.ReadLine();

        Random rdm = new Random();

        Player player = new Player(name, 10, 3, rdm.Next(1, 6), 5, 3, 5);

        //Fog, mist
        Console.WriteLine("Welcome " + player.Name + " to the world of Caligo.");
        Thread.Sleep(500);
        Console.WriteLine("Choose a direction and start your adventure.");

        // Initialize mapLocations once at the start
        mapLocations = MapUtility.PreloadMapTiles(2);

        input = string.Empty;

        Console.WriteLine("Enter a direction (North, South, East, West) or 'quit' to exit:");

        return player;
    }

    private static void InitializeNPC()
    {
        NPC Gerald = new NPC("Gerald", 1, 1, 1, 1, 1, 1);
        Gerald.DisplayText = "A simple man";
        Gerald.Dialogues.Add(new Dialogue("How are you?", DialogueType.Mood.Neutral));
        Gerald.Dialogues.Add(new Dialogue("About time I see a friendly face around here.", DialogueType.Mood.Positive));
        Gerald.Dialogues.Add(new Dialogue("I've lasted this long without any help, I don't need you.", DialogueType.Mood.Negative));
        mapLocations[0].NPC = Gerald;
    }

    private static void GameLoop(Dictionary<string[], Action> commandActions)
    {
        while (input != "quit" && input != "exit")
        {
            //check player position before moving
            bool wasAtLocation = MapUtility.IsAtLocation();

            //these 3 lines handle the command history by removing previous commands
            input = Utility.ReadInputWithHistory(commandHistory, ref historyIndex);
            if (commandHistory.Count >= historyMaximum) commandHistory.RemoveAt(0);
            commandHistory.Add(input);

            //checks commandActions list to see if user's input matches any commands
            //if it does it runs the command
            bool commandFound = false;
            foreach (var commandAction in commandActions)
            {
                if (Array.Exists(commandAction.Key, command => command.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    commandAction.Value.Invoke();
                    commandFound = true;
                    break;
                }
            }

            //check player position after moving
            bool isAtLocation = MapUtility.IsAtLocation();

            if (!commandFound)
            {
                Console.WriteLine("Invalid command. Please enter a valid command or 'quit' to exit.");
            }

            if (!wasAtLocation && isAtLocation)
            {
                Console.WriteLine("You've reached a location");
            }
        }
    }
}
