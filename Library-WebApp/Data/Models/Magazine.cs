namespace LibraryWebApi1.Models
{
    public class Magazine:BaseEntity
    {
        public int Periodicity { get; set; }
        public int Number { get; set; }
        public override void Assigning(BaseEntity baseEntity)
        {
            base.Assigning(baseEntity);
            if (baseEntity is Magazine magazine)
            {
                this.Number = magazine.Number;
                this.Periodicity = magazine.Periodicity;
            }
        }
    }
}