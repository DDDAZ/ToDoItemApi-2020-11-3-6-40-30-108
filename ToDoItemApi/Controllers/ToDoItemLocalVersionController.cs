using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoItemApi.Models;
using ToDoItemApi.Services;

namespace ToDoItemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemLocalVersionController : ControllerBase
    {
        private readonly ToDoItemDb _toDoItemDbService;

        public ToDoItemLocalVersionController(ToDoItemDb toDoItemDbService)
        {
            _toDoItemDbService = toDoItemDbService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            return Ok(await _toDoItemDbService.Get());
        }

        [HttpGet("id")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemById(long id)
        {
            var itemFind = await _toDoItemDbService.Get(id);
            if (itemFind == null)
            {
                return NotFound("No item match Id");
            }

            return Ok(itemFind);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddToDoItem(ToDoItem inDoItem)
        {
            var itemFind = await _toDoItemDbService.Get(inDoItem.Id);
            if (itemFind != null)
            {
                return BadRequest("Item with same Id has existed");
            }

            await _toDoItemDbService.Create(inDoItem);
            return Ok("Add success");
        }
    }
}
