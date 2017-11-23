using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient httpClient = new HttpClient();
        private const string url = "http://localhost:64510/api/employee/";

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Models.Employee> res = JsonConvert.DeserializeObject<IEnumerable<Models.Employee>>
                (httpClient.GetStringAsync(url).Result);
            return View(res);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Employee e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = httpClient.PostAsJsonAsync<Models.Employee>(url, e).Result;
                }
                else
                {
                    ModelState.AddModelError("", "All field must not be blanked");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        public ActionResult Edit(int id)
        {
            var rs = JsonConvert.DeserializeObject<Models.Employee>(httpClient.GetStringAsync(url + id).Result);
            return View(rs);
        }

        [HttpPost]
        public ActionResult Edit(Models.Employee e)
        {
            var model = httpClient.PutAsJsonAsync<Models.Employee>(url, e).Result;
            return View();
        }

    }
}