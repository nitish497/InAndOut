using InAndOut.Interface;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InAndOut.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly IExpenseCategory _expenseCategory;
        public ExpenseCategoryController(IExpenseCategory expenseCategory)
        {
            _expenseCategory = expenseCategory;
        }
        public IActionResult Index()
        {
            List<ExpenseCategory> list = _expenseCategory.GetAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                //_db.Set<ExpenseCategory>().Add(expenseCategory);
                ////_db.ExpenseCategories.Add(expenseCategory);
                //_db.SaveChanges();
                _expenseCategory.Create(expenseCategory);
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //var data = _db.ExpenseCategories.Where(e => e.Id == id).FirstOrDefault();
            //_db.Remove(data);
            //_db.SaveChanges();
            var data=_expenseCategory.GetById(id);
            _expenseCategory.Delete(data);
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = _expenseCategory.GetById(id);
            return View(data);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                //_db.ExpenseCategories.Update(expenseCategory);
                //_db.SaveChanges();
                _expenseCategory.Update(expenseCategory);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult Getfile() {
            string[] filePaths = Directory.GetFiles(@"path of your file","*.PDF");
            Byte[] bytes = System.IO.File.ReadAllBytes(filePaths[4]);
            String file = Convert.ToBase64String(bytes);
			string success;
			return Json(success = file);
        }

    }
}
