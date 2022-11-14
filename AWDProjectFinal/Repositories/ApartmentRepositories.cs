using AWDProjectFinal.Data;
using AWDProjectFinal.interfaces;
using AWDProjectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinal.Repositories
{
    public class ApartmentRepositories : IApartment
    {
        private readonly AWDProjectFinalContext _context;

        public ApartmentRepositories(AWDProjectFinalContext context)
        {
            _context = context;
        }

        public void Delete(ApartmentModel apartment)
        {
             _context.ApartmentModels.Remove(apartment);
        }

        public List<ApartmentModel> GetAll()
        {
            return _context.ApartmentModels.ToList();
        }

        public ApartmentModel GetById(int Id)
        {
            return _context.ApartmentModels.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(ApartmentModel apartment)
        {
            _context.ApartmentModels.Update(apartment);
        }
    }
}
