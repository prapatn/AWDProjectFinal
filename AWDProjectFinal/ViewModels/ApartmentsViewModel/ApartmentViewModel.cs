using AWDProjectFinal.Models;

namespace AWDProjectFinal.ViewModels.ApartmentsViewModel
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public int AmountRoom { get; set; }
        public string Image { get; set; }
        public IFormFile? ImageFile { get; set; }
    }


}
