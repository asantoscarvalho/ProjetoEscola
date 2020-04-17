using System.Threading.Tasks;
using ProjetoEscola.Domain;

namespace ProjetoEscola.Repository.inteface
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno[]> GetAlunoAsync();

        Task<Aluno> GetAlunoAsyncById(int AlunoId);

        Task<Aluno[]> GetAlunoAsyncByName(string Nome);    
    }
}