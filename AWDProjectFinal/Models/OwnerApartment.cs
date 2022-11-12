using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWDProjectFinal.Models
{
    public class OwnerApartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public ICollection<ApartmentModel> Apartments { get; set; }
    }
}
