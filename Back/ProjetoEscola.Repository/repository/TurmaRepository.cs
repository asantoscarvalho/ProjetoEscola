using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain;
using ProjetoEscola.Repository.inteface;

namespace ProjetoEscola.Repository.repository
{
    public class TurmaRepository : Repository<Turma> , ITurmaRepository
    {
        private readonly ProjetoEscolaContext _context;

        public TurmaRepository(ProjetoEscolaContext context) : base (context)
        {
            this._context = context;
        }

        public async Task<Turma[]> GetTurmaAsync()
        {
            IQueryable<Turma> query = _context.Turmas.Include(al => al.Alunos);
            return await query.ToArrayAsync();
        }

        public async Task<Turma> GetTurmaAsyncById(int TurmasId)
        {
            IQueryable<Turma> query = _context.Turmas.Include(al => al.Alunos);

            query = query.OrderBy(c => c.Nome).Where(c => c.Id == TurmasId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Turma[]> GetTurmaAsyncByName(string Nome)
        {
             IQueryable<Turma> query = _context.Turmas.Include(al => al.Alunos);

            query = query.OrderBy(c => c.Nome).Where(c => c.Nome.Contains(Nome));

            return await query.ToArrayAsync();
        }

    }
}