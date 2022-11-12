using AWDProjectFinal.Models;

namespace AWDProjectFinal.interfaces
{
    public interface IOwner
    {
        List<OwnerApartment> GetAll();

        OwnerApartment GetById(int Id);

        void Update(OwnerApartment owner);
    }
}
