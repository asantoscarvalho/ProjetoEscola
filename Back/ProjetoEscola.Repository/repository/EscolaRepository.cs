using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain;
using ProjetoEscola.Repository.inteface;

namespace ProjetoEscola.Repository.repository
{
    public class EscolaRepository : Repository<Escola> , IEscolaRepository 
    {
        private readonly ProjetoEscolaContext _context;

        public EscolaRepository(ProjetoEscolaContext context) : base(context)
        {
            this._context = context;
        }



        public async Task<Escola[]> GetEscolaAsync()
        {
            IQueryable<Escola> query = _context.Escolas.Include(x => x.Turmas).ThenInclude(z => z.Alunos);


            return await query.ToArrayAsync();
        }

        public async Task<Escola> GetEscolaAsyncById(int EscolaId)
        {
            IQueryable<Escola> query = _context.Escolas.Include(x => x.Turmas).ThenInclude(z => z.Alunos);

            query = query.OrderBy(c => c.Nome).Where(c => c.Id == EscolaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Escola[]> GetEscolaAsyncByName(string Nome)
        {
            IQueryable<Escola> query = _context.Escolas.Include(x => x.Turmas).ThenInclude(z => z.Alunos);

            query = query.OrderBy(c => c.Nome).Where(c => c.Nome.Contains(Nome));

            return await query.ToArrayAsync();
        }


    }
}