using InAndOut.Infrastructure;
using InAndOut.Interface;
using InAndOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Service
{
    public class ExpenseCategoryService : BaseService<ExpenseCategory>,IExpenseCategory
    {
        public ExpenseCategoryService(IRepository<ExpenseCategory> repository):base(repository)
        {

        } 
    }
}
