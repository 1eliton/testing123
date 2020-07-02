using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SPWebApi.RetornaJuros.Controllers
{
    /// <summary>
    /// Controller responsavel por retornar a taxa de juros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// "fixa no fonte"
        /// </summary>
        private const double TAXA_JUROS = 0.01;

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> RetornaTaxaJuros()
        {
            try
            {
                return Ok(TAXA_JUROS);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ocorrido ao obter taxa de juros: {e.Message}");
            }
        }
    }
}