using System.Collections.Generic;
namespace CDOrganizer.Models
{
  public class Item
  {
    private string _artist;
    private string _title;
    private static List<Item> _instances = new List<Item>{};
    private int _id;

    public Item(string artist, string title)
    {
      _artist = artist;
      _title = title;
      _id = _instances.Count;
      _instances.Add(this);
    }
    public string GetTitle()
    {
      return _title;
    }

    public string GetArtist()
    {
      return _artist;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }








  }

}
