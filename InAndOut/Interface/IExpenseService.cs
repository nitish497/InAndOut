using InAndOut.Infrastructure;
using InAndOut.Models;

namespace InAndOut.Interface
{
    public interface IExpenseService:IRepository<Expenses>
    {
    }
}
