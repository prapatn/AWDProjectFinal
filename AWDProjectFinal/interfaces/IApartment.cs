using AWDProjectFinal.Models;

namespace AWDProjectFinal.interfaces
{
    public interface IApartment
    {
        List<ApartmentModel> GetAll();

        ApartmentModel GetById(int Id);

        void Update(ApartmentModel apartment);
    }
}
