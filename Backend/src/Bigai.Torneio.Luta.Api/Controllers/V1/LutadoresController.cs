using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bigai.Torneio.Luta.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bigai.Torneio.Luta.Api.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/lutadores")]
    public class LutadoresController : ControllerBase
    {
        private IHttpClientFactory _clientFactory;
        private readonly string _apiUrl = "https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores";
        private readonly string _apiKey = "29452a07-5ff9-4ad3-b472-c7243f548a33";
        private readonly ILogger<LutadoresController> _logger;

        public LutadoresController(IHttpClientFactory clientFactory, ILogger<LutadoresController> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Lutador[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAsync()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

            try
            {
                Lutador[] lutadores = await client.GetFromJsonAsync<Lutador[]>(_apiUrl);

                return Ok(lutadores);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Lutador[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GerarCampeonato([FromBody] Lutador[] request)
        {
            if (request == null || request.Length != 20)
            {
                return BadRequest("Você deve selecionar 20 lutadores para o campeonato.");
            }

            return Ok(Campeonato.Disputar(request.ToList()));
        }
    }
}
