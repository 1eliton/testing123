using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SPWebApi.CalculaJuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private const string GITHUB_URL = "https://github.com/1eliton/testing123";

        /// <summary>
        /// Onde o projeto se encontra no repo?
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult ShowMeTheCode()
            => Ok(GITHUB_URL);
    }
}