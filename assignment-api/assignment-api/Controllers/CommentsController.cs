using assignment_api.Data;
using assignment_api.Models.Entities;
using assignment_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentRequest req)
        {
            var commentEntity = new CommentEntity
            {
                Comment = req.Comment,
                ErrandId = req.ErrandId
            };
            _context.Add(commentEntity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(commentEntity);
        }

    }
}
