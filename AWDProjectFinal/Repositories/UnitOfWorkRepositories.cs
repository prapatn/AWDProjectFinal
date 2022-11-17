using AWDProjectFinal.Data;
using AWDProjectFinal.interfaces;

namespace AWDProjectFinal.Repositories
{
    public class UnitOfWorkRepositories : IUnitOfWork
    {
        private readonly AWDProjectFinalContext _context;
        private IApartment _apartmentRepo;
        private IOwner _ownerRepo;
      

        public UnitOfWorkRepositories(AWDProjectFinalContext context) { 
            _context = context;
        }
        public IApartment Apartment
        {
            get {
                return _apartmentRepo = _apartmentRepo ?? new ApartmentRepositories(_context);
            }
        }

        public IOwner Owner
        {
            get
            {
                return _ownerRepo = _ownerRepo ?? new OwnerRepo(_context);
            }
        }

      

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
