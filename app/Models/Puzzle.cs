using System;
using System.Collections.Generic;
using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Puzzle : IPuzzle
  {
    public Puzzle(string prompt, string answer, string name, string success, string failure, IEvent need = null)
    {
      Prompt = prompt;
      Answer = answer;
      Name = name;
      Success = success;
      Failure = failure;
      Exits = new Dictionary<string, IRoom>();
      Needed = need;
    }
    public Dictionary<string, IRoom> Exits { get; set; }
    public IEvent Needed { get; set; }
    public string Prompt { get; set; }
    public string Answer { get; set; }
    public string Name { get; set; }
    public string Success { get; set; }
    public string Failure { get; set; }

    public bool Solve()
    {
      Console.WriteLine(Prompt);
      string user = Console.ReadLine();
      if (user == Answer)
      {
        return true;
      }
      return false;
    }
  }
}