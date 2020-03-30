using escape_corona.Interfaces;

namespace escape_corona.Models
{
  class Item : IItem
  {
    public Item(string name, string description, string use)
    {
      Name = name;
      Description = description;
      UsedString = use;

    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string UsedString { get; set; }
  }
}