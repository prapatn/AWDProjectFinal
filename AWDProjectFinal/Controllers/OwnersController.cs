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

        public OwnersController()
        {
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

        // GET: OwnersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create
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

        // GET: OwnersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
