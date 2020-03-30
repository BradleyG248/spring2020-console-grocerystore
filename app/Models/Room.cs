using System.Collections.Generic;
using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string LockedMessage { get; set; }
    public string EventDesc { get; set; }
    public string EventRoom { get; set; }
    public List<IItem> Items { get; set; }
    public List<IPuzzle> Puzzles { get; set; }
    public List<IPoint> PointsOfInterest { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public Dictionary<IItem, IEvent> Actions { get; set; }
    public Dictionary<IItem, KeyValuePair<string, IRoom>> LockedExits { get; set; }
    public Dictionary<IEvent, KeyValuePair<string, IRoom>> Events { get; set; }

    public void AddLockedRoom(IItem key, string direction, IRoom room)
    {
      var lockedRoom = new KeyValuePair<string, IRoom>(direction, room);
      LockedExits.Add(key, lockedRoom);
    }
    public void AddEvent(IEvent trigger, string state, IRoom room)
    {
      trigger.Rooms.Add(this);
      var eventRooms = new KeyValuePair<string, IRoom>(state, room);
      Events.Add(trigger, eventRooms);
    }

    public string Use(IItem item)
    {
      if (LockedExits.ContainsKey(item))
      {
        Exits.Add(LockedExits[item].Key, LockedExits[item].Value);
        LockedExits.Remove(item);
        return item.UsedString;
      }
      else if (Actions.ContainsKey(item))
      {
        IEvent e = Actions[item];
        e.Active = true;
        e.Rooms.ForEach(r => r.Exits.Add(r.Events[e].Key, r.Events[e].Value));
        return item.UsedString;
      }
      return "No use for that here";
    }

    public Room(string name, string description, string hidden = null, string lockedMessage = null)
    {
      Name = name;
      Description = description;
      EventDesc = hidden;
      PointsOfInterest = new List<IPoint>();
      Items = new List<IItem>();
      Exits = new Dictionary<string, IRoom>();
      LockedExits = new Dictionary<IItem, KeyValuePair<string, IRoom>>();
      LockedMessage = lockedMessage;
      Events = new Dictionary<IEvent, KeyValuePair<string, IRoom>>();
      Actions = new Dictionary<IItem, IEvent>();
      Puzzles = new List<IPuzzle>();
    }
  }
}