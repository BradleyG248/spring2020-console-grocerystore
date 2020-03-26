using escape_corona.Interfaces;
namespace escape_corona.Models
{
  class Point : IPoint
  {
    public Point(string name, string description)
    {
      Name = name;
      Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
  }
}