using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data;
using TodoListApp.Model;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public TodoListController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _dataAccessProvider.GetAllAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetPendings()
        {
            var result = await _dataAccessProvider.GetPendingTasks();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetOverdues()
        {
            var result = await _dataAccessProvider.GetOverdueTasks();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Tasks data)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.SaveAsync(data);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit( Tasks data, int id)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.EditAsync(data,id);
                return Ok();
            }
            return BadRequest();
        }
    }   
}
