using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Json(new { data = await _context.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var bookFromDb = await _context.Books.FindAsync(id);

            if (bookFromDb == null)
                return Json(new { success = false, message = "Error while deleting" });

            _context.Books.Remove(bookFromDb);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}