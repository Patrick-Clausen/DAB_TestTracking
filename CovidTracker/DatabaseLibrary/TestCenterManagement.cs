using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class TestCenterManagement
    {
        public TestCenterManagement()
        {
            PhoneNumber = 0;
            Email = string.Empty;
            Name = string.Empty;
        }

        [Key]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<TestCenter> ManagesTestCenters { get; set; }
    }
}