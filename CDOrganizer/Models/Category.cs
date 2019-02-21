using System.Collections.Generic;

namespace CDOrganizer.Models
{
  public class Category
  {
    private string _genre;
    private int _id;
    private List<Item> _items;
    private static List<Category> _instances = new List<Category>{};

    public Category(string genre)
    {
      _genre = genre;
      _instances.Add(this);
      _id = _instances.Count;
      _items = new List<Item>{};
    }
    public string GetGenre()
    {
      return _genre;
    }
    public int GetId()
    {
      return _id;
    }
    public void AddItem(Item item)
    {
      _items.Add(item);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Category>GetAll()
    {
      return _instances;
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public List<Item> GetItem()
    {
      return _items;
    }
  }
}
