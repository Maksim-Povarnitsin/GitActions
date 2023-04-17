using System.ComponentModel.DataAnnotations;

namespace LabMiAu.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TestProperty { get; set; }
        public int Age { get; set; }
    }
}
