using System.Collections.Generic;

namespace escape_corona.Interfaces
{
  interface IEvent
  {
    string Name { get; set; }
    IItem Trigger { get; set; }
    List<IRoom> Rooms { get; set; }
  }
}