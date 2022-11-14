using AWDProjectFinal.Data;
using AWDProjectFinal.interfaces;
using AWDProjectFinal.Models;

namespace AWDProjectFinal.Repositories
{
    public class OwnerRepo : IOwner
    {
        private readonly AWDProjectFinalContext _context;

        public OwnerRepo(AWDProjectFinalContext context)
        {
            _context = context;
        }

        public List<OwnerApartment> GetAll()
        {
            return _context.OwnerApartments.ToList();
        }

        public OwnerApartment GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(OwnerApartment owner)
        {
            throw new NotImplementedException();
        }
    }
}
