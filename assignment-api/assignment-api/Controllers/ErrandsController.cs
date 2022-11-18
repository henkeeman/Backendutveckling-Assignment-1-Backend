using assignment_api.Data;
using assignment_api.Models;
using assignment_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace assignment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrandsController : ControllerBase
    {
        private readonly DataContext _context;

        public ErrandsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errands = new List<ErrandResponse>();
            foreach (var errand in await _context.Errands.Include(x => x.Status).Include(x => x.User).ToListAsync())
                errands.Add(new ErrandResponse
                {
                    Id = errand.Id,
                    User = errand.User,
                    Title = errand.Title,
                    Created = errand.Created,
                    Description = errand.Description,
                    Status = errand.StatusId
                });

            return new OkObjectResult(errands);
        }

        [HttpGet("GetErrand/{id}")]
        public async Task<IActionResult> GetErrand(int id)
        {
            var _errand = await _context.Errands.Include(x => x.Status).Include(x => x.Comments).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (_errand != null)
            {
                var comments = new List<CommentResponse>();
                if (_errand.Comments != null)
                {
                    if(_errand.Comments != null)
                    {
                        foreach (var comment in _errand.Comments)
                        comments.Add(new CommentResponse
                        {
                            Created = comment.Created,
                            Comment = comment.Comment

                        });
                    }
                    
                }
                if (_context.Errands == null)
                {
                    return NotFound();
                }
                var errand = new ErrandResponse
                {
                    Id = _errand.Id,
                    User = _errand.User,
                    Title = _errand.Title,
                    Created = _errand.Created,
                    Description = _errand.Description,
                    Status = _errand.StatusId,
                    Comments = comments
                };
                return new OkObjectResult(errand);
            }
            else
            {
                return new NotFoundResult();
            }




        }

        [HttpPost]
        public async Task<IActionResult> Create(ErrandRequest req)
        {
            try
            {
                var tempUser = await _context.Users.Where(x => x.Email == req.Email).FirstOrDefaultAsync();
                var errandEntity = new ErrandEntity
                {
                    UserId = tempUser.Id,
                    Title = req.Title,
                    Description = req.Description,
                    StatusId = req.StatusId
                };
                if (errandEntity.StatusId <= 0 || errandEntity.StatusId > 3)
                {
                    errandEntity.StatusId = 1;

                }
                _context.Add(errandEntity);
                await _context.SaveChangesAsync();
                return new OkObjectResult(errandEntity);

                
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
                return new NotFoundResult();
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ErrandUpdateRequest req)
        {
            try
            {
                var errand = await _context.Errands.FindAsync(id);
                if(req.StatusId > 3 || req.StatusId <= 0)
                {
                    req.StatusId = 1;
                }
                errand.StatusId = req.StatusId;
                _context.Entry(errand).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var _errand = await _context.Errands.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == errand.Id);
                return new OkResult();


            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(ex.Message);
                return new NotFoundResult();
            }
           
        }
    }
}
