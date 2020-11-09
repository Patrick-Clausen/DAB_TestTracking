using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class Nation
    {
        [Key]
        public string Name { get; set; }

        public int Population { get; set; }
    }
}