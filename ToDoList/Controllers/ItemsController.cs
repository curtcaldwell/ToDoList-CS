using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    // [HttpPost("/items")]
    // public ActionResult Date()
    // {
    //   Item newItem = new Item(Request.Form["new-item"], Request.Form["date"]);
    //   newItem.Save();
    //   return View("Index", Item.GetAll());
    // }

    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/items")]
    public ActionResult DateOrder()
        {
          Item newItem = new Item(Request.Form["new-item"], Request.Form["date"]);
          newItem.Save();
          return View("Index", Item.DateOrder());
        }
  }
}
