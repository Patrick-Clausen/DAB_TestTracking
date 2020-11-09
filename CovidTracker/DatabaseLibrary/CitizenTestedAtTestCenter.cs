using System;

namespace DatabaseLibrary
{
    public class CitizenTestedAtTestCenter
    {
        public Citizen TestedCitizen { get; set; }
        public int CitizenSSN { get; set; }
        public TestCenter TestedAt { get; set; }
        public string TestCenterName { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}