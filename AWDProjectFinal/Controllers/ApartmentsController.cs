using AutoMapper;
using AWDProjectFinal.interfaces;
using AWDProjectFinal.Models;
using AWDProjectFinal.ViewModels.ApartmentsViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [HttpGet]
        public ActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var models = _unitOfWork.Apartment.GetByTitle(search);
                var vms = _mapper.Map<List<ApartmentViewModel>>(models);
                return View(vms);
            }
            var model = _unitOfWork.Apartment.GetAll();
            var vm = _mapper.Map<List<ApartmentViewModel>>(model);
            return View(vm);
        }

        // GET: ApartmentsController/Details/5
        public ActionResult Details(int id)
        {
            var model = _unitOfWork.Apartment.GetById(id);
            var vm = _mapper.Map<ApartmentViewModel>(model);

            return View(vm);
        }

        // GET: ApartmentsController/Create
        public ActionResult Create()
        {
            var tagsFromRepo = _unitOfWork.Owner.GetAll();
            var selectList = new List<SelectListItem>();
            foreach(var item in tagsFromRepo)
            {
                selectList.Add(new SelectListItem(item.Name, item.Id.ToString()));
            }
            var vm = new CreatePostViewModel()
            {
                selectOwner = selectList
            };
            
            return View(vm);
        }

        // POST: ApartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostViewModel vm)
        {
            try
            { 
                ApartmentModel apm = new ApartmentModel()
                {
                    Name = vm.Name,
                    Address = vm.Address,
                    AmountRoom = vm.AmountRoom,
                    ApartmentType = vm.ApartmentType,
                    ImageFile = vm.ImageFile,
                };
                var owner = _unitOfWork.Owner.GetById(vm.Selectnameowner);
                apm.Owner = owner;
                if (vm.ImageFile != null)
                {
                    string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", vm.Name);
                    System.IO.File.Delete(filePath);
                    apm.Image = UploadFile(apm);
                }

                _unitOfWork.Apartment.Insert(apm);
                _unitOfWork.Save();
                return RedirectToAction("Index");

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
                model.Image = UploadFile(model);
            }
            _unitOfWork.Apartment.Update(model);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Apartments");
        }

        private string UploadFile(ApartmentModel p)
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

     
        public  ActionResult Delete(int id)
        {
            Console.WriteLine("DELETE"+ id);
             ApartmentModel model = _unitOfWork.Apartment.GetById(id);
             _unitOfWork.Apartment.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Apartments");

        }
    }
}
