using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryWebApi1.Models
{
    public class Magazine:BaseClass
    {
       
        [Required] 
        [Range(1,31,ErrorMessage="Invalid Periodicity Value")]
        public int Periodicity { get; set; }
        [Range(1,int.MaxValue,ErrorMessage="Invalid Number Value")]
        [Required]
        public int Number { get; set; }
        public override void Assigning(BaseClass baseClass)
        {
            base.Assigning(baseClass);
            if (baseClass is Magazine magazine)
            {
                this.Number = magazine.Number;
                this.Periodicity = magazine.Periodicity;
            }
        }
        public static IQueryable<Magazine> SearchByName(string name, IQueryable<Magazine> magazines)
            => magazines.Where(x => x.Name.ToLower().Contains(name.ToLower()));
    }
}