using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi1.Models
{
    public class BookDto
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Author { get; set; }
        [Required]
        [MinLength(4)]
        public string Genre { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int  Count { get; set; }
        [Required]
        [Range(1700,2022)]
        public int PublicationYear { get; set; }
        [Required]
        [MinLength(3)]
        public string Publishing { get; set; }
        
    }
}