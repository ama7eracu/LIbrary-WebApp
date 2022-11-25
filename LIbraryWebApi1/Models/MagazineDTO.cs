using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi1.Models
{
    public class MagazineDto
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long Id { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        [Range(0,int.MaxValue)]
        public int  Count { get; set; }
        
        [Required]
        [Range(1700,2022)]
        public int PublicationYear { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Publishing { get; set; }
        
        [Required] 
        [Range(1,31,ErrorMessage="Invalid Periodicity Value")]
        public int Periodicity { get; set; }
        
        [Range(1,int.MaxValue,ErrorMessage="Invalid Number Value")]
        [Required]
        public int Number { get; set; }
    }
}