using AutoMapper;
using AWDProjectFinal.interfaces;
using AWDProjectFinal.Models;
using AWDProjectFinal.ViewModels.ApartmentsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AWDProjectFinal.Controllers
{ 
    public class ApartmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ApartmentsController(IUnitOfWork unitOfWork,IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Apartment.GetAll();
            var vm = _mapper.Map<List<ApartmentViewModel>>(model);
            return View(vm);
        }

        // GET: ApartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.Apartment.GetById(id);
            var vm = _mapper.Map<ApartmentViewModel>(model); 

            return View(vm);
        }

        // POST: ApartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApartmentViewModel vm)
        {
            try
            {
                var model = _mapper.Map<ApartmentModel>(vm);
                _unitOfWork.Apartment.Update(model);
                _unitOfWork.Save();
                return RedirectToAction("Index","Apartments");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
