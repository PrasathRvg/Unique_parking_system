using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UParking.Helper;
using UParking.Models;

namespace UParking.Controllers
{
    public class PassMVCController : Controller
    {
        ParkingAPI _api = new ParkingAPI();
        public async Task<IActionResult> ViewPass()
        {
            List<Pass1> passdata = new List<Pass1>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Passes");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                passdata = JsonConvert.DeserializeObject<List<Pass1>>(res);
            }
            return View(passdata);
        }

        public async Task<ActionResult> AddPassAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Passes/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);
                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddPass(Pass1 pdata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(pdata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Passes", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NewPayment","PaymentMVC");
            }
            return View();
        }
    }
}
