using InAndOut.Infrastructure;
using InAndOut.Interface;
using InAndOut.Models;

namespace InAndOut.Service
{
    public class ItemService:BaseService<Item>, IItemService
    {
        public ItemService(IRepository<Item> repository) : base(repository)
        {

        }
    }
}
