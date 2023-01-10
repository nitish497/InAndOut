using InAndOut.Data;
using InAndOut.Infrastructure;
using InAndOut.Interface;
using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Service
{
    public class ExpenseService:BaseService<Expenses>, IExpenseService
    {
        private readonly ApplicationDbContext _context;
        public ExpenseService(ApplicationDbContext dbContext,IRepository<Expenses> repository):base(repository)
        {
            _context= dbContext;    
        }
        public override List<Expenses> GetAll()
        {
            return _context.Expenses.Include("ExpenseCategory").ToList();
        }
    }
}
