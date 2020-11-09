using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class Location
    {
        [Key]
        public string Address { get; set; }

        public Municipality IsIn { get; set; }
        public string MunicipalityName { get; set; }

        public List<CitizenWasAtLocation> Visits { get; set; }
    }
}