using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SPWebApi.Aplicacao;

namespace SPWebApi.CalculaJuros.Controllers
{
    /// <summary>
    /// Controller responsavel por calcular o juros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {

        private ICalculaJurosAplicacao _calculaJurosAplicacao;

        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="config"></param>
        public CalculaJurosController(IConfiguration config)
        {
            ///_calculaJurosAplicacao = new CalculaJurosAplicacao(config);
        }

        /// <summary>
        /// Calcula o juros com base no valor inicial, tempo e taxa de juros.
        /// </summary>
        /// <returns>Valor com juros acrescidos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet()]
        public async Task<IActionResult> CalculaJuros([FromQuery]double valorInicial, [FromQuery]double meses)
        {
            try
            {
                var calculo = await _calculaJurosAplicacao.Calcular(valorInicial, meses);
                if (calculo.sucesso)
                    return Ok(calculo.valorFinal);

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}