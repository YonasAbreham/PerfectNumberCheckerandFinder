using BusinessLogic.PerfectNumber;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectNumber.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("UIEndpoint")]
    public class PerfectNumberController : ControllerBase
    {
        readonly IPerfectNumberService _pnService;

        public PerfectNumberController(IPerfectNumberService pnService)
        {
            _pnService = pnService;
        }

        [HttpGet("checkWithFactors")]
        public ActionResult<bool> Get(long number)
        {
            return Ok(_pnService.IsPerfectNumber(number));
        }

        [HttpGet("checkWithPrimeNumber")]// This works with all perfect numbers 2^(p−1)(2^p − 1 ) with odd prime p and, in fact, with all numbers of the form 2^(m−1)(2^m − 1) for odd integer (not necessarily prime) m.
        public ActionResult<bool> GetByPerfectFormula(long number)
        {
            return Ok(_pnService.IsPerfectNumberByPrimes(number));
        }

        [HttpGet("find")]
        public ActionResult<List<int>> FindPerfectNumbers(int start, int end)
        {
            return Ok(_pnService.FindPerfectNumbers(start, end));
        }
    }
}
