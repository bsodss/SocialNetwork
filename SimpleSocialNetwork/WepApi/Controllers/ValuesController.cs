using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<TodoItem> db;

        public ValuesController()
        {
            db = new List<TodoItem>()
            {
                new TodoItem()
                {
                    Id = 1,
                    Name = "End authorization",
                    IsComplited = false
                }
            };
        }


        [Authorize]
        [HttpGet]
        public ActionResult<List<TodoItem>> DataReturn()
        {
            db.Add(new TodoItem()
            {
                Id = 10,
                Name = "name",
                IsComplited = true
            });
            return Ok(db);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<TodoItem> DataReturn(int id)
        {
            var res = db.FirstOrDefault(i => i.Id == id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult<TodoItem>> Add([FromBody] TodoItem data)
        {

            await Task.Run(() => db.Add(data));
            return CreatedAtRoute("GetById", new { id = data.Id }, data);
        }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplited { get; set; }
    }
}
