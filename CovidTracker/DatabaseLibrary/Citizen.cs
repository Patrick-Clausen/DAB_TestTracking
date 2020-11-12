using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class Citizen
    {
        public Citizen()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Sex = '\0';
            MunicipalityName = string.Empty;
            Age = -1;
            SSN = string.Empty;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public int Age { get; set; }

        public Municipality LivesIn { get; set; }
        public string MunicipalityName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string SSN { get; set; }

        public List<CitizenTestedAtTestCenter> Tests { get; set; }
        public List<CitizenWasAtLocation> WasAtLocations { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }
    }
}