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

        public static void getCurrentCoordinates(int[] position)
        {
            Console.WriteLine($"Current Position: (x: {position[0]}, y: {position[1]}, z: {position[2]})");
        }

        public static void CheckNearbyLocations(int[] position, Location[] mapLocations)
        {
            Console.WriteLine("Pinging nearby locations...");

            for (int i = 0; i < mapLocations.Length; i++)
            {
                int deltaX = Math.Abs(position[0] - mapLocations[i].coordinates[0]);
                int deltaY = Math.Abs(position[1] - mapLocations[i].coordinates[1]);
                int maxDistance = Math.Max(deltaX, deltaY);
                if (position[2] == mapLocations[i].coordinates[2])
                {
                    if (position[0] == mapLocations[i].coordinates[0] && position[1] == mapLocations[i].coordinates[1])
                    {
                        Console.WriteLine("You are at a location");
                    }
                    else if (maxDistance == 1)
                    {
                        Console.WriteLine("You feel the warmth of a roaring fire near you, the chanting gets louder");
                    }
                    else if (maxDistance <= 2)
                    {
                        Console.WriteLine("You hear faint chanting in the distance");
                    }
                    else if (maxDistance <= 3)
                    {
                        Console.WriteLine("You are near a point of interest");
                    }
                }
            }
        }

        public static void CheckNearbyLocationsWithDirection(int[] position, Location[] mapLocations, int charges)
        {
            Console.WriteLine("Spirits, predict my path");

            int searchRange = 5;
            Location nearestLocation = new Location();
            int smallestDistance = 0;
            int deltaX = 0;
            int deltaY = 0;


            if (charges > 0)
            {
                for (int i = 0; i < mapLocations.Length; i++)
                {
                    if(position[2] == mapLocations[i].coordinates[2])
                    {
                        Location currentLocation = mapLocations[i];
                        int phDeltaX = currentLocation.coordinates[0] - position[0];
                        int phDeltaY = currentLocation.coordinates[1] - position[1];
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
                                Console.WriteLine( deltaX + " paces east");
                            }
                            else
                            {
                                Console.WriteLine( Math.Abs(deltaX) + " paces west");
                            }
                        }
                        else if (Math.Abs(deltaY) > 0)
                        {
                            if (deltaY > 0)
                            {
                                Console.WriteLine( deltaY + " paces north");
                            }
                            else
                            {
                                Console.WriteLine( Math.Abs(deltaY) + " paces south");
                            }
                        }
                }
                else
                {
                    Console.WriteLine("You sense the spirits, but they are far");
                }
            }
            else
            {
                Thread.Sleep(500);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("You hear no response");
            }
        }
    }
}
