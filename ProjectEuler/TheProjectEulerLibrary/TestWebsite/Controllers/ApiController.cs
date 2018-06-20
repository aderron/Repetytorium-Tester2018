
using System.Web.Http;

namespace TestWebsite.Controllers
{
    public class CalcController : ApiController
    {
        [Route("api/calc/add/{a}/{b}")]
        public int Addition(int a, int b)
        {
            return a + b;
        }
    }
}
