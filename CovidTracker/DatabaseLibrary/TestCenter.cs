using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLibrary
{
    public class TestCenter
    {
        [Key]
        public string Name { get; set; }
        public string Hours { get; set; }

        public Municipality PlacedIn { get; set; }


        public TestCenterManagement HasManagement { get; set; }

        public List<CitizenTestedAtTestCenter> Tests { get; set; }
    }
}