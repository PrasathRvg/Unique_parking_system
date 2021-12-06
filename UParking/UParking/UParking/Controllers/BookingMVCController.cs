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
    public class BookingMVCController : Controller
    {
        ParkingAPI _api = new ParkingAPI();
        public async Task<IActionResult> ViewBooking()
        {
            var book = new Booking1(); 
            List<Booking1> bookdata = new List<Booking1>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Bookings");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                bookdata = JsonConvert.DeserializeObject<List<Booking1>>(res);
            }


            return View(bookdata);
        }

        public async Task<ActionResult> NewBookingAsync(string id)
        {
            var users = new AspNetUser1();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Bookings/Id");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<AspNetUser1>(res);

                ViewData["UserId"] = users.Id;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NewBooking(Booking1 bdata)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(bdata);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Bookings", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NewPayment","PaymentMVC");
            }
            return View();
        }
    }
}
