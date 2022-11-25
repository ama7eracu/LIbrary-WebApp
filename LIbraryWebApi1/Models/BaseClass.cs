using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace LibraryWebApi1.Models
{
    public class BaseClass
    {
        [Key]
        [Required]
        [Range(1,long.MaxValue,ErrorMessage = "Invalid Id Value")]
        public  long Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; } = null!;

        [Required] 
        [Range(1,int.MaxValue,ErrorMessage="Invalid Count Value")]
        public int  Count { get; set; }
        
        [Required]
        [Range(1700,2022,ErrorMessage = "Invalid PublicationYear Value")]
        public int PublicationYear { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Publishing { get; set; } = null!;
        public virtual void Assigning(BaseClass baseClass)
        {
            this.Count = baseClass.Count;
            this.Name = baseClass.Name;
            this.Publishing = baseClass.Publishing;
            this.PublicationYear = baseClass.PublicationYear;
        }
        
    }
}