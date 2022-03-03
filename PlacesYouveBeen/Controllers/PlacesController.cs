using Microsoft.AspNetCore.Mvc;
using PlacesYouveBeen.Models;
using System.Collections.Generic;
// using System;

namespace PlacesYouveBeen.Controllers
{
  public class PlacesController : Controller
  {
    [HttpGet("/places/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/places")]
    public ActionResult Create(string city, string lengthVisited, string image)
    {
      int days = int.Parse(lengthVisited);
      Place newPlace = new Place(city, days, image);
      return RedirectToAction("Index");
    }
    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<Place> myPlaces = Place.GetAll();
      return View(myPlaces);
    }
    [HttpGet("/places/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Place.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
