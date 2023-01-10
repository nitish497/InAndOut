using InAndOut.Data;
using InAndOut.Interface;
using InAndOut.Models;
using InAndOut.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategory _expenseCategory;
        public ExpenseController(IExpenseService expenseService, IExpenseCategory expenseCategory)
        {
            _expenseService= expenseService;
            _expenseCategory = expenseCategory;
        }

        public IActionResult Index()
        {
            List<Expenses> list = _expenseService.GetAll();
            return View(list);
        }
        public IActionResult CreateExpenses()
        {
            IEnumerable<SelectListItem> CategoryDropdown = _expenseCategory.GetAll().Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            ViewBag.type = CategoryDropdown;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateExpenses(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _expenseService.Create(expenses);
                return RedirectToAction("Index");
            }
            return View(expenses);
        }


        public IActionResult Delete(int id)
        {
            var data = _expenseService.GetById(id);
            _expenseService.Delete(data);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            IEnumerable<SelectListItem> CategoryDropdown = _expenseCategory.GetAll().Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            ViewBag.type = CategoryDropdown;

            if (id == 0)
            {
                return NotFound();
            }
            var data = _expenseService.GetAll().FirstOrDefault(x => x.Id == id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                var data = _expenseService.GetById(expenses.Id);
                data.ExpensesName = expenses.ExpensesName;
                data.Amount = expenses.Amount;
                data.ExpenseCategoryId = expenses.ExpenseCategoryId;
                _expenseService.Update(data);
                return RedirectToAction("Index");
            }
            return View(expenses);
        }
    }
}
