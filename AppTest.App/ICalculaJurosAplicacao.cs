using System.Threading.Tasks;

namespace SPWebApi.Aplicacao
{
    public interface ICalculaJurosAplicacao
    {
        Task<(bool sucesso, double valorFinal)> Calcular(double valorInicial, double meses);
    }
}