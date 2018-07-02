using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private static List<Item> _instances = new List<Item> {};

    public Item (string description)
    {
      _description = description;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }

  // public class Program
  // {
  //   public static void Main()
  //   {
  //     Console.WriteLine("Would you like to add an item or view the to-do list? (Add/View) ");
  //     string UserInput = Console.ReadLine();
  //     if (UserInput == "Add" || UserInput == "add")
  //     {
  //       Console.WriteLine("Please enter a description of your to-do item: ");
  //       string newItemDescription = Console.ReadLine();
  //       Item newItem = new Item(newItemDescription);
  //       newItem.Save();
  //     }
  //     else if (UserInput == "View" || UserInput == "view")
  //     {
  //       foreach (Item item in Item.GetAll())
  //       {
  //         Console.WriteLine(item.GetDescription());
  //       }
  //     }
  //     else
  //     {
  //       Console.WriteLine("Please type view or add");
  //     }
  //     Console.WriteLine("--------");
  //     Main();
  //   }
  // }
}
