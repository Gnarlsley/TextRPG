using System;
using TextRPG;

namespace Utilities
{
    class MapUtility
    {
        public static Location[] PreloadMapTiles(int rows)
        {
            Random rmd = new Random();
            Location[] locations = new Location[rows];

            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = new Location();
            }

            return locations;
        }

        public static void getCurrentCoordinates()
        {
            Console.WriteLine($"Current Position: (x: {GamePanel.position[0]}, y: {GamePanel.position[1]}, z: {GamePanel.position[2]})");

            if (isAtLocation())
            {
                Console.WriteLine("You are at a location");
            }
        }

        public static bool isAtLocation()
        {
            for (int i = 0; i < GamePanel.mapLocations.Length; i++)
            {
                if (GamePanel.position[0] == GamePanel.mapLocations[i].coordinates[0] && 
                    GamePanel.position[1] == GamePanel.mapLocations[i].coordinates[1])
                {
                    return true;
                }
            }
            return false;
        }

        public static Location getLocation()
        {
            Location currentLocation = null;

            for (int i = 0; i < GamePanel.mapLocations.Length; i++)
            {
                if (GamePanel.position[0] == GamePanel.mapLocations[i].coordinates[0] && 
                    GamePanel.position[1] == GamePanel.mapLocations[i].coordinates[1])
                {
                    currentLocation = GamePanel.mapLocations[i];
                }
            }
            return currentLocation;
        }

        public static void examineLocation()
        {
            Location location = getLocation();

            if (location != null)
            {
                Console.WriteLine(location.description);
            }
            else
            {
                Console.WriteLine("You see a barren wasteland with nothing of interest");
            }
        }

        public static void CheckNearbyLocations()
        {
            _ = Task.Run(() => Utility.falseInput());
            Console.WriteLine("Pinging nearby locations...");
            Utility.loading();

            int searchRange = 5;
            Location nearestLocation = null;
            int smallestDistance = -1;

            for (int i = 0; i < GamePanel.mapLocations.Length; i++)
            {
                if (GamePanel.position[2] == GamePanel.mapLocations[i].coordinates[2])
                {
                    Location currentLocation = GamePanel.mapLocations[i];
                    int deltaX = currentLocation.coordinates[0] - GamePanel.position[0];
                    int deltaY = currentLocation.coordinates[1] - GamePanel.position[1];
                    int maxDistance = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));

                    if (maxDistance <= smallestDistance || smallestDistance == -1)
                    {
                        nearestLocation = currentLocation;
                        smallestDistance = maxDistance;
                    }
                }
            }

            if (nearestLocation != null && smallestDistance < searchRange)
            {
                if (GamePanel.position[0] == nearestLocation.coordinates[0] && 
                    GamePanel.position[1] == nearestLocation.coordinates[1])
                {
                    Console.WriteLine("You are at a point of interest");
                }
                else if (smallestDistance == 1)
                {
                    Console.WriteLine(nearestLocation.approachText[2]);
                }
                else if (smallestDistance <= 2)
                {
                    Console.WriteLine(nearestLocation.approachText[1]);
                }
                else if (smallestDistance <= 3)
                {
                    Console.WriteLine(nearestLocation.approachText[0]);
                }
                else
                {
                    Console.WriteLine("Nothing located");
                }
            }
            else
            {
                Console.WriteLine("Nothing located");
            }

            GamePanel.isTaskRunning = false;
        }

        public static void CheckNearbyLocationsWithDirection(ref int charges)
        {
            _ = Task.Run(() => Utility.falseInput());
            Console.WriteLine("Spirits, predict my path");
            Utility.loading();

            int searchRange = 7;
            Location nearestLocation = null;
            int smallestDistance = 0;
            int deltaX = 0;
            int deltaY = 0;

            if (charges > 0)
            {
                for (int i = 0; i < GamePanel.mapLocations.Length; i++)
                {
                    if (GamePanel.position[2] == GamePanel.mapLocations[i].coordinates[2])
                    {
                        Location currentLocation = GamePanel.mapLocations[i];
                        int phDeltaX = currentLocation.coordinates[0] - GamePanel.position[0];
                        int phDeltaY = currentLocation.coordinates[1] - GamePanel.position[1];
                        int maxDistance = Math.Max(Math.Abs(phDeltaX), Math.Abs(phDeltaY));

                        if (maxDistance < smallestDistance || smallestDistance == 0)
                        {
                            nearestLocation = currentLocation;
                            smallestDistance = maxDistance;
                            deltaX = phDeltaX;
                            deltaY = phDeltaY;
                        }
                    }
                }

                if (nearestLocation != null && smallestDistance <= searchRange)
                {
                    if (Math.Abs(deltaX) > Math.Abs(deltaY))
                    {
                        if (deltaX > 0)
                        {
                            Console.WriteLine(deltaX + " paces east");
                        }
                        else
                        {
                            Console.WriteLine(Math.Abs(deltaX) + " paces west");
                        }
                    }
                    else if (Math.Abs(deltaY) > 0)
                    {
                        if (deltaY > 0)
                        {
                            Console.WriteLine(deltaY + " paces north");
                        }
                        else
                        {
                            Console.WriteLine(Math.Abs(deltaY) + " paces south");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You feel a strong sense of belonging");
                    }
                }
                else
                {
                    Console.WriteLine("You sense the spirits, but they are far");
                }

                charges--;
            }
            else
            {
                Console.WriteLine("You hear no response");
            }
        }
    }
}
