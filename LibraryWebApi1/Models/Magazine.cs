using System.Linq;

namespace LibraryWebApi1.Models
{
    public class Magazine:BaseClass
    {
        public int Periodicity { get; set; }
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
    }
}