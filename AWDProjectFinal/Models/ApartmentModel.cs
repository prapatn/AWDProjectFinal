using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWDProjectFinal.Models
{
    public class ApartmentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApartmentType ApartmentType { get; set; }
        //public List<SelectListItem> AType { get; set; }
        public int AmountRoom { get; set; } 
        public string Image { get; set; }
        public OwnerApartment Owner { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }


    public enum ApartmentType
    {
        Male, Female, All
    }
}
