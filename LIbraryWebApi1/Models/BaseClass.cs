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
        public  long Id { get; set; }
        public string Name { get; set; } = null!;
        public int  Count { get; set; }
        public int PublicationYear { get; set; }
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