using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class TestCenterManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public TestCenter ManagesTestCenter { get; set; }
        public string ManagedTestCenterName { get; set; }
    }
}