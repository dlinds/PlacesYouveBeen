using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    private static List<Place> _locations = new List<Place> { };
    public int Id { get; set; }
    public int LengthVisited { get; set; }
    public string Image { get; set; }

    public Place(string cityName, int lengthVisited, string image)
    {
      CityName = cityName;
      LengthVisited = lengthVisited;
      Image = image;
      _locations.Add(this);
      Id = _locations.Count;

    }

    public static List<Place> GetAll()
    {
      return _locations;
    }
    public static void ClearAll()
    {
      _locations.Clear();
    }
    public static Place Find(int searchId)
    {
      return _locations[searchId - 1];
    }

    public static void Delete(int Id)
    {
      Place toDelete = Find(Id);
      _locations.Remove(toDelete);
      // for (int i = _locations.Count - 1; i > 0; i--)
      // {
      //   _locations[i].Id = i + 1;
      // }
      int count = 1;
      foreach (Place location in _locations)
      {
        location.Id = count;
        count++;
      }
    }
  }
}

// C:\Users\DanielLindsey\Desktop\C#\PlacesYouveBeen.Solution\PlacesYouveBeen\Controllers\PlacesController.cs(17,28): 
// error CS7036: There is no argument given that corresponds to the required formal parameter 'lengthVisited' of 'Place.Place(string, int, string)' [C:\Users\DanielLindsey\Desktop\C#\PlacesYouveBeen.Solution\PlacesYouveBeen\PlacesYouveBeen.csproj]

//  [0]Portland ID: 1

//  [2]Vancounver ID: 2
//  [3]Phoenix ID:3

// i = 4
