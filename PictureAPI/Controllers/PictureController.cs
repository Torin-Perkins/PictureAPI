using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PictureAPI.Models;

namespace PictureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PictureController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Picture>> GetPictures()
        {
            return await _context.Pictures.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
            return await _context.Pictures.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture([FromBody] Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return Ok(picture);
        }

        [HttpPut]
        public async Task<ActionResult> PutPicture(int id, [FromBody] Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }

            _context.Entry(picture).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pictureToDelte = await _context.Pictures.FindAsync(id);
            if (pictureToDelte != null)
            {
                return NotFound();
            }

            _context.Pictures.Remove(pictureToDelte);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
