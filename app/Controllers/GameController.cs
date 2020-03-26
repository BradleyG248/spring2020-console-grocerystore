using System;
using System.Threading;
using escape_corona.Interfaces;
using escape_corona.Services;

namespace escape_corona.Controllers
{
  class GameController : IGameController
  {
    private IGameService _gs { get; set; }
    private bool _running { get; set; } = true;
    public void Run()
    {
      Console.WriteLine("Hello there what is your name?");
      // NOTE Gets string from readline and passes is as the player name
      _gs = new GameService(Console.ReadLine());
      string greeting = $"You've been researching some of the past scientists of your local town, and found some interesting ties between them. It seems this house was a meeting place of sorts. Find what information you can on what happened here.";
      // foreach (char letter in greeting)
      // {
      //   Console.Write(letter);
      //   Thread.Sleep(10);
      // }
      Console.WriteLine(greeting);
      Print();
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }
    public void GetUserInput()
    {
      // go north
      // take brass key
      // command option
      // look
      // command
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " "; //go north ;take toilet paper ;look 
      string command = input.Substring(0, input.IndexOf(" ")); //go; take; look
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();//north; toilet paper;''

      Console.Clear();
      switch (command)
      {
        case "quit":
          _running = false;
          break;
        case "reset":
          _gs.Reset();
          break;
        case "look":
          _gs.Look();
          break;
        case "examine":
          _gs.Examine(option);
          break;
        case "inventory":
          _gs.Inventory();
          break;
        case "go":
          _running = _gs.Go(option);
          break;
        case "take":
          _gs.Take(option);
          break;
        case "use":
          _gs.Use(option);
          break;
        case "help":
          _gs.Help();
          break;
        default:
          _gs.Messages.Add("Not a recognized command");
          _gs.Look();
          break;
      }
    }

    public void Print()
    {
      foreach (string message in _gs.Messages)
      {
        Console.WriteLine(message);
      }
      _gs.Messages.Clear();
    }

  }
}