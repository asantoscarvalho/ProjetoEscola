using System.Collections.Generic;

namespace ProjetoEscola.Domain
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<Turma> Turmas {get; set;}
    }
}