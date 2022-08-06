using CalculatorChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CalculatorChallenge.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Calculate([FromBody] CalculationModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7161");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.PostAsJsonAsync("/Calculator/Calculate", model);
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var data = await response.Content.ReadFromJsonAsync<DataResultModel<decimal>>();
                client.Dispose();
                if (data.Success)
                {
                    return Json(new { status = true, data = data.Data });
                }
                return Json(new { status = false, message="Unknown error!" });
            }
            else
            {
                client.Dispose();
                return Json(new { status = false, message = await response.Content.ReadAsStringAsync() });
            }
        }
    }
}