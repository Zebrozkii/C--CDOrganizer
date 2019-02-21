using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CDOrganizer.Models;
namespace CDOrganizer.Controllers
{
    public class CategoryController : Controller
    {

      [HttpGet("/categories")]
      public ActionResult Index()
      {
        List<Category> allCategories = Category.GetAll();
        return View(allCategories);
      }

      [HttpGet("/categories/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("/categories")]
      public ActionResult Create(string genre)
      {
        Category newCategory = new Category(genre);
        List<Category> allCategories = Category.GetAll();
        return View("Index", allCategories);
      }

      [HttpGet("/categories/{id}")]
      public ActionResult Show(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(id);
        List<Item> categoryItems = selectedCategory.GetItem();
        model.Add("category", selectedCategory);
        model.Add("items", categoryItems);
        return View(model);
      }

      [HttpPost("/categories/{categoryId}/items")]
      public ActionResult Create(int categoryId, string artistName,string songName)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category foundCategory = Category.Find(categoryId);
        Item newItem = new Item(artistName, songName);
        foundCategory.AddItem(newItem);
        List<Item> categoryItems = foundCategory.GetItem();
        model.Add("items", categoryItems);
        model.Add("category", foundCategory);
        return View("Show", model);
      }

    }
}
