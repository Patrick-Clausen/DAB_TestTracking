using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class Citizen
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public int Age { get; set; }

        public Municipality LivesIn { get; set; }
        public string MunicipalityName { get; set; }

        [Key]
        public int SSN { get; set; }

        public List<CitizenTestedAtTestCenter> Tests { get; set; }
        public List<CitizenWasAtLocation> WasAtLocations { get; set; }
    }
}