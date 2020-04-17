using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain;
using ProjetoEscola.Repository.inteface;

namespace ProjetoEscola.Repository.repository
{
    public class AlunoRepository : Repository<Aluno> , IAlunoRepository
    {
        private readonly ProjetoEscolaContext _context;

        public AlunoRepository(ProjetoEscolaContext context) : base (context)
        {
            this._context = context;
        }

      

        public async Task<Aluno[]> GetAlunoAsync()
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.Include(x => x.Turma);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.Include(x => x.Turma);

            query = query.OrderBy(c => c.Nome).Where(c => c.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunoAsyncByName(string Nome)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.OrderBy(c => c.Nome).Where(c => c.Nome.Contains(Nome));

            return await query.ToArrayAsync();
        }
    }
}