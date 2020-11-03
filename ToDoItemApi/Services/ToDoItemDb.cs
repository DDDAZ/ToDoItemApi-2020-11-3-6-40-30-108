using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItemApi.Models;

namespace ToDoItemApi.Services
{
    public class ToDoItemDb
    {
        private List<ToDoItem> _toDoItems;
        public ToDoItemDb()
        {
            _toDoItems = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    Id = 0,
                    Name = "Tom",
                    IsComplete = true
                }
            };
        }

        public async Task<List<ToDoItem>> Get()
        {
            return _toDoItems;
        }

        public async Task<ToDoItem> Get(long id)
        {
            return _toDoItems.FirstOrDefault(item => item.Id == id);
        }

        public async Task<ToDoItem> Create(ToDoItem inDoItem)
        {
            var idList = _toDoItems.Select(item => item.Id);
            if (!idList.Contains(inDoItem.Id))
            {
                _toDoItems.Add(inDoItem);
            }

            return inDoItem;
        }
    }
}
