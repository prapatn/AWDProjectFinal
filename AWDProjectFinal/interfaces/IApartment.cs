using AWDProjectFinal.Models;

namespace AWDProjectFinal.interfaces
{
    public interface IApartment
    {
        List<ApartmentModel>? GetAll();

        ApartmentModel? GetById(int Id);
        List<ApartmentModel> GetByTitle(string title);
        void Insert(ApartmentModel apartment);
        void Update(ApartmentModel apartment);
        void Delete(ApartmentModel apartment);
    }
}
