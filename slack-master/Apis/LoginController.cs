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
    [Route("/api/users")]
    public class LoginController : Controller
    {
        private readonly IMapper mapper;
        private readonly ChatDbContext context;
        public LoginController(IMapper mapper, ChatDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IEnumerable<LoginService>> GetUsers(LoginService loginService)
        {
            var users = await context.Login.ToListAsync();
            return mapper.Map<IEnumerable<Login>, IEnumerable<LoginService>>(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromBody] LoginService loginService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var users = mapper.Map<LoginService, Login>(loginService);
            context.Login.Add(users);
            await context.SaveChangesAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers(int id, [FromBody] LoginService loginService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var users = await context.Login.FindAsync(id);
            if (users == null)
                return NotFound();
            mapper.Map<LoginService, Login>(loginService, users);
            await context.SaveChangesAsync();
            return Ok(users);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var users = await context.Login.FindAsync(id);
            if (users == null)
                return NotFound();
            var loginService = mapper.Map<Login, LoginService>(users);
            return Ok(loginService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await context.Login.FindAsync(id);
            if (users == null)
                return NotFound();
            context.Remove(users);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}