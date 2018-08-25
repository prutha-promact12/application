using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SlackClone.Data;
using SlackClone.Controllers.Resources;
using SlackClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace SlackClone.Controllers
{
    [Route("/api/message")]
    public class MessageController : Controller
    {
        private readonly IMapper mapper;
        private readonly ChatDbContext context;
        public MessageController(IMapper mapper, ChatDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IEnumerable<MessageService>> GetMessage(MessageService messageService)
        {
            var message = await context.Message.ToListAsync();
            return mapper.Map<IEnumerable<Message>, IEnumerable<MessageService>>(message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] MessageService messageService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var message = mapper.Map<MessageService, Message>(messageService);
            context.Message.Add(message);
            await context.SaveChangesAsync();
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] MessageService messageService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var message = await context.Message.FindAsync(id);
            if (message == null)
                return NotFound();
            mapper.Map<MessageService, Message>(messageService, message);
            await context.SaveChangesAsync();
            return Ok(message);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var message = await context.Message.FindAsync(id);
            if (message == null)
                return NotFound();
            var messageService = mapper.Map<Message, MessageService>(message);
            return Ok(messageService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await context.Message.FindAsync(id);
            if (message == null)
                return NotFound();
            context.Remove(message);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}