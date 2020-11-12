using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class CitizenWasAtLocation
    {
        public CitizenWasAtLocation()
        {
            VisitingCitizenSSN = string.Empty;
            VisitedLocationAddress = string.Empty;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Citizen VisitingCitizen { get; set; }
        public string VisitingCitizenSSN { get; set; }
        public DateTime DateOfVisit { get; set; }
        public Location VisitedLocation { get; set; }
        public string VisitedLocationAddress { get; set; }
    }
}