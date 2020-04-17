using System.Collections.Generic;

namespace ProjetoEscola.Domain
{
    public class Turma
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sala { get; set; }

        public string Professor {get; set;}

        public int EscolaId { get; set; }
        public Escola Escola { get; set;}
        public List<Aluno> Alunos { get; set; }


    }
}