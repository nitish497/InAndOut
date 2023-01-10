using InAndOut.Data;
using InAndOut.Interface;
using InAndOut.Models;
using InAndOut.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService= itemService;
        }
        public IActionResult Index()
        {
            List<Item> itemlist = _itemService.GetAll().ToList();
            return View(itemlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            _itemService.Create(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = _itemService.GetById(id);
            _itemService.Delete(data); 
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            var data = _itemService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Item items)
         {
            if (ModelState.IsValid)
            {
                var data = _itemService.GetById(items.Id);
                data.Borrrower= items.Borrrower;
                data.Lender=items.Lender;
                data.ItemName=items.ItemName;
                _itemService.Update(data);
                return RedirectToAction("Index");
            }
            return View(items);
        }
    }

   
}
