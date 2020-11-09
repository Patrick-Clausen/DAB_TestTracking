using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class Municipality
    {
        [Key]
        public string Name { get; set; }
        public int Population { get; set; }

        public List<Location> LocationsInMunicipality { get; set; }
        public List<Citizen> CitizensInMunicipality { get; set; }
    }
}