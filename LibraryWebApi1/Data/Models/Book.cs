namespace LibraryWebApi1.Models
{
    public class Book:BaseEntity
    {
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public override void Assigning(BaseEntity baseEntity)
        {
            base.Assigning(baseEntity);
            if (baseEntity is Book book)
            {
                this.Author =book.Author;
                this.Genre = book.Genre;
            }
        }
    }
}