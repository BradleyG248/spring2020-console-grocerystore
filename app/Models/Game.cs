using System.Collections.Generic;
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
      Room testingRoom = new Room("Testing Room", "Inside you find sealed rooms behind thick metal doors. Metal scraps and wires litter a solid steel table in the middle of the room, and in one sealed room you find a robot.");
      EndRoom jailCell = new EndRoom("Jail Cell", "The robot inside looks at you malevolently.", false, "What did you think would happen, freeing a psychotic robot?");
      EndRoom escapeOutside = new EndRoom("Outside, again.", "The air feels good against your face.", true, "You've escaped the house!");
      Room laboratory = new Room("Laboratory", "Surrounding the room is a small counter, whereon dozens of test tubes and various machinery are neatly organized.");
      Room generatorRoom = new Room("Generator", "You've entered a large concrete room. In the corner a large device roughly as tall as you sits, with some exposed wiring. It seems to be dysfunctional. Tacked to the wall behind it lies a chart.");
      Room elevator = new Room("Elevator", "A small platform sits at the end of this room, surrounded by a simple metal fencing. Judging by the cables attached to it, it must be an elevator of sorts.");
      Room foyer = new Room("Foyer", "It's a foyer!");

      // NOTE Create all Items
      Item keys = new Item("Keys", "Attached to the ring is what must be keys. They each have hooked protrusions attached to the key shaft.", "With a click, the door unlocks.");
      Item bulb = new Item("Bulb", "It glows bright blue, flickering occasionally. It's warm to the touch.", "Holding the bulb up, you can make out the door handle.");
      Item powerCell = new Item("Power Cell", "It's a large container in the shape of an hourglass. The electricity symbol is printed on it.", "With a whir, the generator comes to life. The previously dark room fills with light from the lamps hanging above you.");

      Point shed = new Point("Shed", "The old sheds leans a little too far left, but otherwise seems in good shape. The door is deadbolted.");
      Point robot = new Point("Robot", "The robot stands on treads, with a muted red lens mounted to its head. It's locked in the room.");
      Point chart = new Point("Chart", "Next to what appears to be an exposed wire terminal you find a note saying: 'Order of colors: \n Green: first, \n Yellow: second, \n blue: third, \n orange: fourth, \n red: fifth'");

      //Events
      Event Power = new Event("Power", powerCell);

      //Puzzles
      Puzzle Wires = new Puzzle("There are three wires: a red one, a yellow one, and a blue one, as well as three terminals to plug them into.", "yellow blue red", "Elevator", "With a bright spark, the machinery comes to life.", "The wires explode in a bright burst of sparks and smoke, giving you a good jolt.", Power);
      Wires.Exits.Add("up", escapeOutside);

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
      //Main Hallway
      mainHallway.Exits.Add("north", northHallway);
      mainHallway.Exits.Add("south", southHallway);
      mainHallway.Exits.Add("west", closet);
      mainHallway.AddEvent(Power, "east", foyer);

      //North Hallway
      northHallway.Exits.Add("south", mainHallway);
      northHallway.Exits.Add("east", generatorRoom);
      northHallway.AddEvent(Power, "west", laboratory);
      //South Hallway
      southHallway.Exits.Add("north", mainHallway);
      southHallway.Exits.Add("west", testingRoom);
      southHallway.Exits.Add("east", elevator);

      //Testing Room
      testingRoom.Exits.Add("east", southHallway);
      testingRoom.AddLockedRoom(keys, "north", jailCell);

      testingRoom.Items.Add(powerCell);
      //Laboratory
      laboratory.Exits.Add("east", northHallway);

      laboratory.Items.Add(keys);
      //Generator Room
      generatorRoom.Exits.Add("west", northHallway);
      generatorRoom.PointsOfInterest.Add(chart);

      //Foyer
      foyer.Exits.Add("west", mainHallway);

      generatorRoom.PointsOfInterest.Add(chart);

      generatorRoom.Actions.Add(powerCell, Power);
      //Elevator
      elevator.Exits.Add("west", southHallway);
      elevator.Puzzles.Add(Wires);

      northYard.AddLockedRoom(bulb, "south", southYard);
      CurrentRoom = frontYard;
    }
  }
}