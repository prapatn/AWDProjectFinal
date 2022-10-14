using System.ComponentModel.DataAnnotations;

namespace AWDProjectFinal.Models
{
    public class ApartmentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public int AmountRoom { get; set; }
        public string Image { get; set; }
        public OwnerApartment Owner { get; set; }

    }


    public enum ApartmentType
    {
        Male, Female, All
    }
}
