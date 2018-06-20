
using System;
using System.Web.Http;

namespace TestWebsite.Controllers
{
    public class CalcController : ApiController
    {
        [HttpGet]
        [Route("api/calc/addition/{a}/{b}")]
        public decimal Addition(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpGet]
        [Route("api/calc/substraction/{a}/{b}")]
        public decimal Substraction(decimal a, decimal b)
        {
            if ( a < 20 )
            {
                return a - b;
            }
            return a + b;
        }

        [HttpGet]
        [Route("api/calc/multiplication/{a}/{b}")]
        public decimal Multiplication(decimal a, decimal b)
        {
            return a * b;
        }

        [HttpGet]
        [Route("api/calc/division/{a}/{b}")]
        public decimal Division(decimal a, decimal b)
        {
            if (b <= 0)
            {
                return 0;
            }

            return a / b;
        }

        [HttpGet]
        [Route("api/calc/buahahahahah/{a}/{b}")]
        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
