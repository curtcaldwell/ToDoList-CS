using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private int _id;
    // private static List<Item> _instances = new List<Item> {};

    public Item (string description, int Id = 0)
    {
      _id = Id;
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
      List<Item> allItems = new List<Item> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
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
