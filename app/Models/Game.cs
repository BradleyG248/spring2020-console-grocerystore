using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Game : IGame
  {
    public IPlayer CurrentPlayer { get; set; }
    public IRoom CurrentRoom { get; set; }

    ///<summary>Initalizes data and establishes relationships</summary>
    public Game()
    {
      // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
      // We retain access to the objects due to the linked list


      // NOTE Create all rooms
      Room frontYard = new Room("Front Yard", "You stand in front of a dilapidated old building. A rickety porch lies to your east.");
      Room northYard = new Room("North Yard", "Boarded windows and open prairie is all you see.");
      Room southYard = new Room("South Yard", "Boarded windows and open prairie is all you see.");
      Room backYard = new Room("Back Yard", "An old shed stands alone towards the southeast corner of the yard.");
      Room porch = new Room("Porch", "As you walk up the stairs, they creak dangerously. You can count more than one loose nail in this landing.");
      Room closet = new Room("A Closet?", "Crack! The floor gives way, leaving you tumbling into a dark room. The rays of sunlight only just let you make out that you're in a closet.");
      Room mainHallway = new Room("Hallway", "The dark hallway eerily reflects the glow of your orb. To your north and south lay darkness; the hallway must continue.", "The bright lamps illuminate the hallway clearly, and by your feet you find a hidden door, just big enough to crawl through.", "Though you can just make out the door, the room's too dark and the door mechanism too foreign for you to open it.");
      Room northHallway = new Room("Northern Hallway", "A metal door with a small window lies to the west of you, and a wireframe door to your right.");
      Room southHallway = new Room("Southern Hallway", "To the west lies an open doorway, and to the east a metal door with a small window.");
      Room testingRoom = new Room("Testing Room", "");

      // NOTE Create all Items
      Item tp = new Item("Toilet Paper", "A Single Roll of precious paper, it must have fallen from a pack");
      Item bulb = new Item("Bulb", "It glows bright blue, flickering occasionally. It's warm to the touch.");

      Point shed = new Point("Shed", "The old sheds leans a little too far left, but otherwise seems in good shape. The door is deadbolted.");

      // NOTE Make Room Relationships
      //Front Yard
      frontYard.Exits.Add("north", northYard);
      frontYard.Exits.Add("east", porch);
      frontYard.Exits.Add("south", southYard);
      //South Yard
      southYard.Exits.Add("west", frontYard);
      southYard.Exits.Add("east", backYard);
      //North Yard
      northYard.Exits.Add("east", backYard);
      northYard.Exits.Add("west", frontYard);
      //Back Yard
      backYard.Exits.Add("north", northYard);
      backYard.Exits.Add("south", southYard);

      backYard.PointsOfInterest.Add(shed);
      //Porch
      porch.Exits.Add("east", closet);
      porch.Exits.Add("west", frontYard);
      //Closet
      closet.AddLockedRoom(bulb, "east", mainHallway);

      closet.Items.Add(bulb);

      northYard.AddLockedRoom(bulb, "south", southYard);
      CurrentRoom = frontYard;
    }
  }
}