using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var task = _context.Tasks.Find(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public IActionResult GetByUserId(int userId)
        {
            var tasks = _context.Tasks.Where(t => t.UserId == userId).ToList();
            return Ok(tasks);
        }
    }
}
