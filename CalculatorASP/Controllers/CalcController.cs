using System.Web.Http;
using System;
using System.Collections.Generic;


namespace CalculatorASP.Controllers
{
    public class CalcController : ApiController
    {
        // POST api/<controller>
        public decimal Post([FromBody]Expression exp)
        {
            string thisexp = exp.Input;
            string[] stringmass = thisexp.Split('+', '-', '÷', 'x');
            List < decimal > numbers= new List<decimal>();
            foreach (var elements in stringmass)
            {
                numbers.Add(Convert.ToDecimal(elements));
            }
            bool add = thisexp.Contains("+");
            bool sbc = thisexp.Contains("-");
            bool mul = thisexp.Contains("x");
            bool div = thisexp.Contains("÷");
            var result = numbers[0];
            if (add)
            {
                return numbers[0] + numbers[1];
            } else if (sbc)
            {
                return numbers[0] - numbers[1];
            } else if (mul)
            {
                return numbers[0] * numbers[1];
            } else if (div)
            {
                return numbers[0] / numbers[1];
            } else
            return result;
        }
    }
    public class Expression
    {
        public string Input { get; set; }
    }
}