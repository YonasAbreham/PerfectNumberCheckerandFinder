using BusinessLogic.PerfectNumber;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [HttpGet("check")]
        public ActionResult<bool> Get(int number)
        {
            return Ok(_pnService.IsPerfectNumber(number));
        }

        [HttpGet("find")]
        public ActionResult<List<int>> FindPerfectNumbers(int start, int end)
        {
            return Ok(_pnService.FindPerfectNumbers(start, end));
        }
    }
}
