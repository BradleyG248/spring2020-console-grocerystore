using System.Collections.Generic;

namespace escape_corona.Interfaces
{
  interface IPuzzle
  {
    string Prompt { get; set; }
    string Answer { get; set; }
    string Name { get; set; }
    string Success { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
    IEvent Needed { get; set; }
    string Failure { get; set; }
    bool Solve();
  }
}