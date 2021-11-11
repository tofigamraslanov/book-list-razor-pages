using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }
    }
}