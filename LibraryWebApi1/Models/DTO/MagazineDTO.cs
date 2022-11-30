using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi1.Models.DTO
{
    public class MagazineDto
    {
        [Required] [MinLength(3)] public string Name { get; set; } = null!;
        [Required] [MinLength(3)] public string Publishing { get; set; } = null!;
        
        [Required]
        [Range(1700,2022,ErrorMessage = "Invalid PublicationYear Value")]
        public int PublicationYear { get; set; }
        
        [Range(1,int.MaxValue,ErrorMessage="Invalid Number Value")]
        [Required]
        public int Number { get; set; }
       
        [Required] 
        [Range(1,31,ErrorMessage="Invalid Periodicity Value")]
        public int Periodicity { get; set; }
        
        [Required] 
        [Range(1,int.MaxValue,ErrorMessage="Invalid Count Value")]
        public int  Count { get; set; }
    }
}