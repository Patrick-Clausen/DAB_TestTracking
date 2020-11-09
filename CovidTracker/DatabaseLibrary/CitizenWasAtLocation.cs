using System;

namespace DatabaseLibrary
{
    public class CitizenWasAtLocation
    {
        
        public Citizen VisitingCitizen { get; set; }
        public int VisitingCitizenSSN { get; set; }
        public DateTime DateOfVisit { get; set; }
        public Location VisitedLocation { get; set; }
        public string VisitedLocationAddress { get; set; }
    }
}