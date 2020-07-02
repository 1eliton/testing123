using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPWebApi.Aplicacao
{
    public class CalculaJurosAplicacao : ICalculaJurosAplicacao
    {
        private string _urApiTaxaJuros { get; set; }

        public CalculaJurosAplicacao(IConfiguration config)
        {
            var apiTaxaJurosConfig = config.GetSection("taxaJurosApi");
            _urApiTaxaJuros = string.Concat(apiTaxaJurosConfig["baseUrl"], apiTaxaJurosConfig["recursoTaxaJuros"]);
        }

        public async Task<(bool sucesso, double valorFinal)> Calcular(double valorInicial, double meses)
        {
            if (!(valorInicial > 0) || !(meses > 0))
                throw new ArgumentException("Os parâmetros informados são inválidos. Por favor, informe os dados corretamente.");

            var taxaJurosResponse = await buscarTaxaJuros(valorInicial, meses);

            if (taxaJurosResponse.IsSuccessStatusCode)
            {
                var juros = Convert.ToDouble(await taxaJurosResponse.Content.ReadAsStringAsync());
                var valorFinal = Math.Pow((1 + juros), meses) * valorInicial;
                return (true, Math.Round(valorFinal, 2));
            }
            else
                throw new HttpRequestException("Taxa de juros não encontrada!");           
        }

        private async Task<HttpResponseMessage> buscarTaxaJuros(double valorInicial, double meses)
            => await new HttpClient().GetAsync($"{_urApiTaxaJuros}?{nameof(valorInicial)}={valorInicial}&{nameof(meses)}={meses}");
    }
}
