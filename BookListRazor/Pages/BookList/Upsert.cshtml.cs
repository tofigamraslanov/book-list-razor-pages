using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Create
            Book = new Book();
            if (id == null)
                return Page();

            // Update
            Book = await _context.Books.FindAsync(id);
            if (Book == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            if (Book.Id == 0)
                _context.Books.Add(Book);
            else
                _context.Books.Update(Book);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}