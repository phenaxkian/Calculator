using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calculator;

namespace CalculatorWebApp.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class SimpleCalculatorController : ControllerBase
    {
        private ISimpleCalculator _calculator;

        public SimpleCalculatorController(ISimpleCalculator calculator)
        {
            _calculator = calculator;
        }


        [Route("Add")]
        [HttpGet]
        public ActionResult<int> Add(int start, int amount)
        {
            int result;

            try
            {
                result = _calculator.Add(start, amount);
            }
            catch (ArithmeticException ex)
            {
                return BadRequest("Result is out of integer bounds");
            }
            return Ok(result);

        }


        [Route("Subtract")]
        [HttpGet]
        public ActionResult<int> Subtract(int start, int amount)
        {
            int result;

            try
            {
                result = _calculator.Subtract(start, amount);
            }
            catch (ArithmeticException ex)
            {
                return BadRequest("Result is out of integer bounds");
            }
            return Ok(result);
        }
    }
}
