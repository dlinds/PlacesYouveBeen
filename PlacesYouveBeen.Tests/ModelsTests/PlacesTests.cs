using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesYouveBeen.Models;
using System;
using System.Collections.Generic;

namespace PlacesYouveBeen.Tests
{
  [TestClass]
  public class PlacesTests : IDisposable
  {
    public void Dispose()
    {
      Place.ClearAll();
    }
    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place("London", 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }

    [TestMethod]
    public void PlaceConstructor_CreateInstanceOfLondonPlace_London()
    {
      Place newPlace = new Place("London", 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      Assert.AreEqual("London", newPlace.CityName);
    }
    [TestMethod]
    public void GetAll_CreateEmptylist_List()
    {
      List<Place> newList = new List<Place> { };
      List<Place> result = Place.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_CreateOnePlace_List()
    {
      Place newPlace = new Place("London", 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      List<Place> newList = new List<Place> { newPlace };
      List<Place> result = Place.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string city = "Ann Arbor";
      Place newPlace = new Place(city, 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      int result = newPlace.Id;
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectPlace_Place()
    {
      string cityName01 = "Oakland";
      string cityName02 = "Kinvara";
      Place newPlace1 = new Place(cityName01, 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      Place newPlace2 = new Place(cityName02, 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      Place result = Place.Find(2);
      Assert.AreEqual(result, newPlace2);
    }
    [TestMethod]
    public void Delete_DeletePlaceFromStaticList_List()
    {
      string cityName01 = "Oakland";
      string cityName02 = "Kinvara";
      Place newPlace1 = new Place(cityName01, 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      Place newPlace2 = new Place(cityName02, 3, "https://static.amazon.jobs/locations/16/thumbnails/london-thumb.jpg?1617639578");
      List<Place> newList = new List<Place> { newPlace1 };
      int toDeleteId = newPlace2.Id;
      Place.Delete(toDeleteId);
      List<Place> copyOfStatic = Place.GetAll();
      CollectionAssert.AreEqual(newList, copyOfStatic);
    }
  }
}