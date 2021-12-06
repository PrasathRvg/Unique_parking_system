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
    public class PaymentMVCController : Controller
    {
        ParkingAPI _api = new ParkingAPI();
        public async Task<IActionResult> ViewPayment()
        {
            List<Payment1> paydata = new List<Payment1>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Payments");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                paydata = JsonConvert.DeserializeObject<List<Payment1>>(res);
            }
            return View(paydata);
        }

        public async Task<ActionResult> NewPaymentAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Payments/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);

                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NewPayment(Payment1 pydata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(pydata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Payments", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewBooking","BookingMVC");
            }
            return View();

        }
        // UPI PAYMENT
        public async Task<ActionResult> UpiPaymentAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Payments/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);

                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpiPayment(Payment1 upidata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(upidata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Payments", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewBooking", "BookingMVC");
            }
            return View();

        }
        // NETBANKING PAYMENT
        public async Task<ActionResult> NetbankingPaymentAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Payments/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);

                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NetbankingPayment(Payment1 ntdata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(ntdata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Payments", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewBooking", "BookingMVC");
            }
            return View();

        }
    }
}
