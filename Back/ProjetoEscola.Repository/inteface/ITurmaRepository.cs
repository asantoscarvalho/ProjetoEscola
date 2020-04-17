using System.Threading.Tasks;
using ProjetoEscola.Domain;

namespace ProjetoEscola.Repository.inteface
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma[]> GetTurmaAsync();

        Task<Turma> GetTurmaAsyncById(int TurmasId);

        Task<Turma[]> GetTurmaAsyncByName(string Nome);
    }
}