using AWDProjectFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AWDProjectFinal.Controllers
{
    public class OwnersController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        string host = "https://localhost:7253/api/Owner";
        private readonly IWebHostEnvironment _hostEnvironment;


        public OwnersController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        // GET: OwnersController
        public async Task<IActionResult> Index()
        {
            var owner = await GetOwner();
            return View(owner);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var owner = await GetOwner();
            if (!String.IsNullOrEmpty(search))
            {
                owner = owner.Where(sh => sh.Name!.Contains(search)).ToList();
            }

            return View(owner);
        }

        [HttpGet]
        public async Task<List<OwnerApartment>> GetOwner() {

            List<OwnerApartment> owners = new List<OwnerApartment>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(host))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    owners = JsonConvert.DeserializeObject<List<OwnerApartment>>(strJson);
                }
            }

            return owners;
        }

        public async Task<ActionResult> Details(int id)
        {
            OwnerApartment ownerDt = new OwnerApartment();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7253/api/Owner/id?id="+id))
                {
                    string strJson = await response.Content.ReadAsStringAsync();
                    ownerDt = JsonConvert.DeserializeObject<OwnerApartment>(strJson);
                }
               
            }
             return View(ownerDt);
        }

        // GET: OwnersController/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: OwnersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OwnerApartment ownerCreates)
        {
            try
            {
                OwnerApartment ownerC = new OwnerApartment();

                    using (var httpClient = new HttpClient(_clientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(ownerCreates),Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:7253/api/Owner", content))
                    {
                        string strJson = await response.Content.ReadAsStringAsync();
                        ownerC = JsonConvert.DeserializeObject<OwnerApartment>(strJson);
                        Console.WriteLine(ownerC);
                        if (ModelState.IsValid)
                        {
                            return RedirectToAction(nameof(Index));
                           
                        }
                    }
                   
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            OwnerApartment owner = new OwnerApartment();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(host+"/id?id=" + id))
                { 
                    string strJson = await response.Content.ReadAsStringAsync();
                    owner = JsonConvert.DeserializeObject<OwnerApartment>(strJson);
                }
            }
            return View(owner);
        }

        // POST: OwnersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OwnerApartment owner)
        {
            OwnerApartment _owner = new OwnerApartment();

            if (owner.ImageFile!=null) {
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", owner.Name);
                System.IO.File.Delete(filePath);
                owner.Image = UploadFile(owner);
            }
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = 
                    new StringContent(JsonConvert.SerializeObject(owner),Encoding.UTF8,"application/json");

                using (var response = await httpClient.PutAsync(host + "/" + id,content))
                {
                    
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private string UploadFile(OwnerApartment p)
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

        // GET: OwnersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string del = "";
            string host = "https://localhost:7253/api/Owner/";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync(host + id))
                {
                    del = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: OwnersController/Delete/5
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
