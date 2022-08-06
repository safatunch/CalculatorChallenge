using CalculatorChallenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : Controller
    {
        [HttpPost]
        public IActionResult Calculate(CalculationModel model)
        {
            try
            {
                return Json(new DataResultModel<decimal>(true, model.Count()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
