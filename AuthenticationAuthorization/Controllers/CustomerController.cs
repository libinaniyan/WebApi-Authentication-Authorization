using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AuthenticationAuthorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerController(ApplicationDbContext CustomerContext)
        {
            _dbContext = CustomerContext;

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Customers.Add(model);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user =  await _dbContext.Customers.FirstOrDefaultAsync(u => u.UserId == model.Username && u.Password == model.Password);
            if (user != null)
            {
                //var name = await _dbContext.Customers.Where(e => e.UserId == model.Username).Select(e => e.Name).FirstOrDefaultAsync();
                var name = user.Name;
                return Ok(name);
            }
            return BadRequest();
        }

    }
}
