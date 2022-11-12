using AWDProjectFinal.Data;
using AWDProjectFinal.interfaces;

namespace AWDProjectFinal.Repositories
{
    public class UnitOfWorkRepositories : IUnitOfWork
    {
        private readonly AWDProjectFinalContext _context;
        private IApartment _apartmentRepo;

        public UnitOfWorkRepositories(AWDProjectFinalContext context) { 
            _context = context;
        }
        public IApartment Apartment
        {
            get {
                return _apartmentRepo = _apartmentRepo ?? new ApartmentRepositories(_context);
            }
        }

        public IOwner Owner => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
