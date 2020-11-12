using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class TestCenter
    {
        public TestCenter()
        {
            Name = string.Empty;
            Hours = string.Empty;
            LocationAddress = string.Empty;
            ManagementName = string.Empty;
        }
        [Key]
        public string Name { get; set; }
        public string Hours { get; set; }

        public Location PlacedIn { get; set; }
        public string LocationAddress { get; set; }

        public TestCenterManagement HasManagement { get; set; }
        public string ManagementName { get; set; }

        public List<CitizenTestedAtTestCenter> Tests { get; set; }
    }
}