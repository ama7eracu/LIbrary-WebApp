namespace LibraryWebApi1.Models
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int  Count { get; set; }
        public int PublicationYear { get; set; }
        public string Publishing { get; set; }
    }
}