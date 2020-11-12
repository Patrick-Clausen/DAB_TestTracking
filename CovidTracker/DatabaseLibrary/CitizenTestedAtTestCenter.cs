using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class CitizenTestedAtTestCenter
    {
        public CitizenTestedAtTestCenter()
        {
            CitizenSSN = string.Empty;
            TestCenterName = string.Empty;
            Result = string.Empty;
            Status = string.Empty;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Citizen TestedCitizen { get; set; }
        public string CitizenSSN { get; set; }
        public TestCenter TestedAt { get; set; }
        public string TestCenterName { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}