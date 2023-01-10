using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.ViewComponent
{
    public class HellowViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            var model = await Task.FromResult(new ExpenseCategory { Name = name });
            return View("_hello", model);
        }
    }
}
