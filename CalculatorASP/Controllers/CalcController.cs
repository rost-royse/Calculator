using System.Web.Http;

namespace CalculatorASP.Controllers
{
    public class CalcController : ApiController
    {
        // POST api/<controller>
        public decimal Post([FromBody]Expression exp)
        {
            // TODO: parse exp
            // TODO: calc results
            var result = 10.25M;
            return result;
        }
    }
    public class Expression
    {
        public string Input { get; set; }
    }
}