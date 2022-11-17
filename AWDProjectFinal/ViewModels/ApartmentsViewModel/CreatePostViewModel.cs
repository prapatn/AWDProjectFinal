using AWDProjectFinal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWDProjectFinal.ViewModels.ApartmentsViewModel
{
    public class CreatePostViewModel
    {
        public List<SelectListItem> selectOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public int AmountRoom { get; set; }
        public string Image { get; set; }
        public int Selectnameowner { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
