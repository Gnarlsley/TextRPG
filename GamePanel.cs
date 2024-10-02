using System;
using Utilities;
using TextRPG;

enum Direction
{
    North,
    South,
    East,
    West
}

class GamePanel
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("TEXT RPG TALES");
        Console.WriteLine("Choose a name for your hero...");
        string name = Console.ReadLine();

        Random rdm = new Random();

        Entity player = new Entity(name, 10, 3, rdm.Next(1,6), 5, 3, 5);

        //Fog, mist
        Console.WriteLine("Welcome " + player.Name + " to the world of Caligo.");
        Thread.Sleep(500);
        Console.WriteLine("Choose a direction and start your adventure.");

        //x, y, z
        int[] position = {0,0,0};
        //Location[] mapLocations = MapUtility.PreloadMapTiles(2);

        //List for command history
        List<string> commandHistory = new List<string>();
        int historyIndex = -1;
        int historyMaximum = 5;

        string input = string.Empty;

        Console.WriteLine("Enter a direction (North, South, East, West) or 'quit' to exit:");


        //TESTING
        int divineCharges = 3;
        Location[] mapLocations = MapUtility.PreloadMapTiles(2);
        for(int i = 0; i < mapLocations.Length; i++)
        {
            Console.WriteLine("X: " + mapLocations[i].coordinates[0] + " Y: " + mapLocations[i].coordinates[1] + " Z: " + mapLocations[i].coordinates[2]);
        }

        var commandActions = new Dictionary<string[], Action>
        {
            { new[] { "North", "north", "N", "1" }, () => Move(position, Direction.North) },
            { new[] { "South", "south", "S", "2" }, () => Move(position, Direction.South) },
            { new[] { "East", "east", "E", "3" }, () => Move(position, Direction.East) },
            { new[] { "West", "west", "W", "4" }, () => Move(position, Direction.West) },
            { new[] { "clear" }, Console.Clear },
            { new[] { "ping", "locate" }, () => MapUtility.CheckNearbyLocations(position, mapLocations) },
            { new[] { "divine" }, () => {MapUtility.CheckNearbyLocationsWithDirection(position, mapLocations, divineCharges); divineCharges--;} },
            { new[] { "position" }, () => MapUtility.getCurrentCoordinates(position) },
            { new[] { "quit", "exit"}, () => Console.WriteLine("Exiting...") }
        };



        while(input != "quit" && input != "exit")
        {
            input = Utility.ReadInputWithHistory(commandHistory, ref historyIndex);

            if (commandHistory.Count >= historyMaximum)
            {
                commandHistory.RemoveAt(0);
            }
            commandHistory.Add(input);

            bool commandFound = false;
            foreach (var commandAction in commandActions)
            {
                // Check if input matches any of the command variants
                if (Array.Exists(commandAction.Key, command => command.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    commandAction.Value.Invoke();
                    commandFound = true;
                    break; // Break after finding the first matching command
                }
            }

            if (!commandFound)
            {
                Console.WriteLine("Invalid command. Please enter a valid direction or 'quit' to exit.");
            }

            for (int i = 0; i < mapLocations.Length; i++)
            {
                if(position[0] == mapLocations[i].coordinates[0] && position[1] == mapLocations[i].coordinates[1] && position[2] == mapLocations[i].coordinates[2])
                {
                    Console.WriteLine("You reached a location");
                }
            }

        }
    }

    static void Move(int[] position, Direction direction)
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
}
