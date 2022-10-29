using AutoMapper;
using AWDProjectFinal.Models;
using AWDProjectFinal.ViewModels.ApartmentsViewModel;

namespace AWDProjectFinal.Helpers
{
    public class Helper:Profile
    {
        public Helper() 
        {
            CreateMap<ApartmentModel, ApartmentViewModel>();
            CreateMap<ApartmentModel, ApartmentViewModel>().ReverseMap();
        }
    } 
}
