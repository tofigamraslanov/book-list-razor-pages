using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public Book Book { get; set; }

        public async Task OnGetAsync(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            var bookFromDb = await _context.Books.FindAsync(Book.Id);
            bookFromDb.Name = Book.Name;
            bookFromDb.Author = Book.Author;
            bookFromDb.Isbn = Book.Isbn;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}