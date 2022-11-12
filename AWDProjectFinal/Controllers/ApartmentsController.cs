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
        private readonly IWebHostEnvironment _hostEnvironment;

        public ApartmentsController(IUnitOfWork unitOfWork,IMapper mapper, IWebHostEnvironment hostEnvironment) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
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
            var model = _mapper.Map<ApartmentModel>(vm);
            if (vm.ImageFile != null)
            {
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", vm.Name);
                System.IO.File.Delete(filePath);
                model.Image = UploadFile(vm);
            }
            _unitOfWork.Apartment.Update(model);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Apartments");
        }

        private string UploadFile(ApartmentViewModel p)
        {
            string fileName = ""; 
            if (p.ImageFile != null)
            {
                //upload to folder image in wwwroot
                string uploadDrive = Path.Combine(_hostEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "-" + p.ImageFile.FileName;
                string filePath = Path.Combine(uploadDrive, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    p.ImageFile.CopyTo(fileStream);
                }
            }
            return fileName;
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
