using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UParking.Helper;
using UParking.Models;


namespace UParking.Controllers
{
    public class VehicleMVCController : Controller
    {
        ParkingAPI _api = new ParkingAPI();
        public async Task<IActionResult> ViewVehicle()
        {
            List<Vehicle1> vehicledata = new List<Vehicle1>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Vehicles");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                vehicledata = JsonConvert.DeserializeObject<List<Vehicle1>>(res);
            }


            return View(vehicledata);
        }

        public async Task<ActionResult> AddvehicleAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Users/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);

                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Addvehicle(Vehicle1 vdata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(vdata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Vehicles", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewVehicle");
            }
            return View();

        }
        public async Task<IActionResult> EditVehicle(int id)
        {
            HttpClient cli = _api.Initial();
           Vehicle1 stud = new Vehicle1();
            HttpResponseMessage response = await cli.GetAsync($"api/Vehicles/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stud = JsonConvert.DeserializeObject<Vehicle1>(data);
            }
            return View(stud);

        }
        [HttpPost]
        public async Task<IActionResult> EditVehicle(int id, [Bind("Vechid,Vechname,Vechno,Vehcolor")] Vehicle1 model)
        {
            if (id != model.Vechid)
            {
                return NotFound();
            }
            HttpClient cli = _api.Initial();
            string stnew = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(stnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cli.PutAsync($"api/Vehicles/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewVehicle");
            }
            return View();
        }

        public async Task<ActionResult> DeleteVehicle(int id)
        {
            HttpClient cli = _api.Initial();

            HttpResponseMessage response = cli.DeleteAsync("api/Vehicles/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewVehicle");
            }
            return Content("Deleted");

        }
    }
}
