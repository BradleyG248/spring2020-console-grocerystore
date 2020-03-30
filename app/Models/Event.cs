using System.Collections.Generic;
using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Event : IEvent
  {
    public Event(string name, IItem trigger)
    {
      Name = name;
      Trigger = trigger;
      Rooms = new List<IRoom>();
    }

    public string Name { get; set; }
    public IItem Trigger { get; set; }
    public List<IRoom> Rooms { get; set; }

  }
}