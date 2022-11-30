using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi1.Models.DTO
{
    public class BookDto
    {
        [Required] [MinLength(3)] public string Name { get; set; } = null!;

        [Required] [MinLength(4)] public string Author { get; set; } = null!;

        [Required] [MinLength(3)] public string Genre { get; set; } = null!;

        [Required] [MinLength(3)] public string Publishing { get; set; } = null!;
        
        [Required]
        [Range(1700,2022,ErrorMessage = "Invalid PublicationYear Value")]
        public int PublicationYear { get; set; }
        
        [Required] 
        [Range(1,int.MaxValue,ErrorMessage="Invalid Count Value")]
        public int  Count { get; set; }
        
        
        
    }
}