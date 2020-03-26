using System.Collections.Generic;

namespace escape_corona.Interfaces
{
  interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<IItem> Items { get; set; }
    List<IPoint> PointsOfInterest { get; set; }

    // NOTE "south": {name: "Jungle forest" ....}
    //      "north": {}

    Dictionary<string, IRoom> Exits { get; set; }
    Dictionary<IItem, KeyValuePair<string, IRoom>> LockedExits { get; set; }

    string Use(IItem item);
  }
}