using System.ComponentModel.DataAnnotations;
namespace LibraryWebApi1.Models
{
    public class BaseEntity
    {
        [Key]
        public  long Id { get; set; }
        public string Name { get; set; } = null!;
        public int  Count { get; set; }
        public int PublicationYear { get; set; }
        public string Publishing { get; set; } = null!;
        public virtual void Assigning(BaseEntity baseEntity)
        {
            this.Count = baseEntity.Count;
            this.Name = baseEntity.Name;
            this.Publishing = baseEntity.Publishing;
            this.PublicationYear = baseEntity.PublicationYear;
        }
        
    }
}