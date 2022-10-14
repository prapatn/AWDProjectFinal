using System.ComponentModel.DataAnnotations;

namespace AWDProjectFinal.Models
{
    public class User
    {
        [Key]
        public String Email { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }

    }
}
