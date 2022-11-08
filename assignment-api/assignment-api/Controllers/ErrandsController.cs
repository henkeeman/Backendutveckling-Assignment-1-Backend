using assignment_api.Data;
using assignment_api.Models;
using assignment_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            foreach (var errand in await _context.Errands.Include(x => x.Status).ToListAsync())
                errands.Add(new ErrandResponse
                {
                    Id = errand.Id,
                    Email = errand.Email,
                    Title = errand.Title,
                    Description = errand.Description,
                    Status = errand.StatusId
                });

            return new OkObjectResult(errands);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ErrandRequest req)
        {
            var errandEntity = new ErrandEntity
            {
                Email = req.Email,
                Title = req.Title,
                Description = req.Description,
                StatusId = req.StatusId
            };
            if(errandEntity.StatusId <= 0 || errandEntity.StatusId > 3)
            {
                errandEntity.StatusId = 1;

            }
            _context.Add(errandEntity);
            await _context.SaveChangesAsync();


            return new OkResult(); 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ErrandUpdateRequest req)
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
