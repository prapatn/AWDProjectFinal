using System.ComponentModel.DataAnnotations;

namespace AWDProjectFinal.Models
{
    public class OwnerApartment
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public ICollection<ApartmentModel> Apartments { get; set; }
    }
}
