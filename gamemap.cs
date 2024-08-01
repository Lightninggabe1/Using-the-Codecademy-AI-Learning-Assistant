using System;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
        }

        public void Describe()
        {
            Console.WriteLine($"You are in {Name}.");
            Console.WriteLine(Description);
            Console.WriteLine("Exits:");
            foreach (var exit in Exits.Keys)
            {
                Console.WriteLine($"- {exit}");
            }
        }

        public void AddExit(string direction, Room room)
        {
            Exits[direction] = room;
        }
    }
}




using System;

namespace TextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create rooms
            var entranceHall = new Room("Entrance Hall", "A grand entrance with marble floors and a crystal chandelier.");
            var library = new Room("Library", "A cozy room filled with shelves of books. There's a reading nook by the window.");
            var kitchen = new Room("Kitchen", "A large kitchen with modern appliances and a delicious smell.");
            var garden = new Room("Garden", "A beautiful garden with various flowers and a small fountain.");

            // Connect rooms
            entranceHall.AddExit("north", library);
            entranceHall.AddExit("east", kitchen);
            entranceHall.AddExit("south", garden);
            
            library.AddExit("south", entranceHall);
            kitchen.AddExit("west", entranceHall);
            garden.AddExit("north", entranceHall);

            // Start game
            var currentRoom = entranceHall;

            while (true)
            {
                currentRoom.Describe();
                Console.Write("Which direction do you want to go? ");
                var direction = Console.ReadLine().ToLower();

                if (currentRoom.Exits.ContainsKey(direction))
                {
                    currentRoom = currentRoom.Exits[direction];
                }
                else
               
