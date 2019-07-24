using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conan.Common.DTO;
using Conan.Common.Services;
using Conan.Common.Services.Interfaces;
using Conan.Data;
using Conan.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Conan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ICrudService<MessageDTO> _service;

        public MessagesController(ApplicationDbContext context, MessagesService service)
        {
            _service = new MessagesService(context);
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<IEnumerable<MessageDTO>> GetMessages()
        {
            return await _service.Get();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDTO>> GetMessage(int id)
        {
            var message = await _service.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, MessageDTO message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            if (!await _service.Update(message))
                return BadRequest();

            return NoContent();
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(MessageDTO message)
        {
            await _service.Insert(message);
            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> DeleteMessage(int id)
        {
            if (!await _service.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
