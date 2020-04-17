using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Domain;

namespace ProjetoEscola.Repository
{
    public class ProjetoEscolaContext : DbContext
    {
        public ProjetoEscolaContext(DbContextOptions<ProjetoEscolaContext> options) : base(options) {}

        public DbSet<Escola> Escolas {get; set;}
        public DbSet<Turma> Turmas {get; set;}
        public DbSet<Aluno> Alunos {get; set;}



    }
}