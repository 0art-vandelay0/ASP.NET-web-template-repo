using Microsoft.AspNetCore.Mvc;
using Template.Models;
using System.Collections.Generic;

namespace Template.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            Item.ClearAll();
            return View();
        }

        [HttpPost("/items")]
        public ActionResult Create(string description)
        {
            Item myItem = new Item(description);
            return RedirectToAction("Index");
        }

        [HttpGet("/items/{id}")]
        public ActionResult Show(int id)
        {
            Item foundItem = Item.Find(id);
            return View(foundItem);
        }

    }
}