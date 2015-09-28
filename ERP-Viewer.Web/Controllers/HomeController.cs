using ERP_Viewer.Data.Models;
using ERP_Viewer.Web.Extensions;
using ERP_Viewer.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ERP_Viewer.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            var model = LoadCities();
            return View(model);
        }


    private CitiesViewModel LoadCities()
        {
            string geoCodeApi = "http://api.geonames.org/citiesJSON?formatted=true&north=44.1&south=-9.9&east=-22.4&west=55.2&maxRows=100&username=bluechrometouch";
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(geoCodeApi).Result;
            var cityJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<CitiesViewModel>(cityJson);

            return result;
        }
    }
}