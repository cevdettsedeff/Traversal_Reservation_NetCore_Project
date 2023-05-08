using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    public class ApiExchangeController : Controller
    {
        List<ApiBookingExchangeViewModel_Json> bookingExchangeViewModel = new List<ApiBookingExchangeViewModel_Json>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
                var values = JsonConvert.DeserializeObject<ApiBookingExchangeViewModel_Json>(body);
                return View(values.exchange_rates);
            }
            
        }
    }
}
