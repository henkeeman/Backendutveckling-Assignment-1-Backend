using assignment_api.Data;
using assignment_api.Models.Entities;
using assignment_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest req)
        {
            var userEntity = new UserEntity
            {
                Email = req.Email,
                Name = req.Name,
                LastName = req.LastName,
                PhoneNr = req.PhoneNr
            };
            _context.Add(userEntity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(userEntity);
        }

    }
}
