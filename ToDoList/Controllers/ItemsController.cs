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

    [HttpGet("/items/{id}")]
    public ActionResult Details(int id)
    {
      Item item = Item.Find(id);
      return View(item);
    }
    [HttpGet("/items")]
    public ActionResult ItemsList()
    {
      return View("Index", Item.DateOrder());
    }
    [HttpPost("/items")]
    public ActionResult DateOrder()
    {
      Item newItem = new Item(Request.Form["new-item"], Request.Form["date"]);
      newItem.Save();
      return View("Index", Item.DateOrder());
    }
    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Item thisItem = Item.Find(id);
      return View(thisItem);
    }

    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id)
    {
      Item thisItem = Item.Find(id);
      thisItem.Edit(Request.Form["newname"]);
      return RedirectToAction("ItemsList");
    }
    // [HttpPost("/items/delete")]
    //     public ActionResult DeleteAll()
    //     {
    //         Item.ClearAll();
    //         return View();
    //     }
  }
}
