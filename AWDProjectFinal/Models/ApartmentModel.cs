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

    public static class StrategicStatesExtension
    {
        public static ApartmentType[] Male
        {
            get
            {
                return new[] { ApartmentType.Male, ApartmentType.Female, ApartmentType.All };
            }
        }

        public static ApartmentType[] Female
        {
            get
            {
                return new[] { ApartmentType.Male, ApartmentType.Female, ApartmentType.All };
            }
        }

        public static ApartmentType[] All
        {
            get
            {
                return new[] { ApartmentType.Male, ApartmentType.Female, ApartmentType.All };
            }
        }

        public static ApartmentType[] GetAssociatedValidApartmentType(this ApartmentType currentApartmentType)
        {
            switch (currentApartmentType)
            {
                case ApartmentType.Male:
                    return Male;
                case ApartmentType.Female:
                    return Female;
                case ApartmentType.All:
                    return All;
                default:
                    throw new ArgumentOutOfRangeException("Invalid current state received.");
            }
        }

        public static List<SelectListItem> ToDropDownList(this ApartmentType[] sourceStates)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in sourceStates)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = item.ToString("d"), // Value of enum (short)
                        Text = item.ToString() // Name of enum
                    });
            }

            return items;
        }
    }
}
