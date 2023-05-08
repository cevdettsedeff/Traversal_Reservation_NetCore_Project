using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Traversal_Reservation_NetCore_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date=2023-09-27&dest_type=city&units=metric&checkout_date=2023-09-28&adults_number=2&order_by=popularity&dest_id=-1456928&filter_by_currency=EUR&locale=tr&room_number=1&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true"),
                Headers =
        {
            { "X-RapidAPI-Key", "406ecb748emshfb8dd0439a4c81dp19bf8cjsnc87f7ce5c331" },
            { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<ApiBookingSearchViewModel>(bodyReplace);
                return View(values.result);
            }
            
        }

        [HttpGet]
        public IActionResult GetCityDestinationId()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestinationId(string cityName)
        {
            cityName = cityName + "&locale=tr";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}"),
                Headers =
        {
            { "X-RapidAPI-Key", "406ecb748emshfb8dd0439a4c81dp19bf8cjsnc87f7ce5c331" },
            { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }

        }
    }
}
