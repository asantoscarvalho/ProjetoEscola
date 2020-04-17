using System.Threading.Tasks;
using ProjetoEscola.Domain;

namespace ProjetoEscola.Repository.inteface
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<Escola[]> GetEscolaAsync();

        Task<Escola> GetEscolaAsyncById(int TurmasId);

        Task<Escola[]> GetEscolaAsyncByName(string Nome);
    }
}