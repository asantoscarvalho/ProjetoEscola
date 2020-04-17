using System.Collections.Generic;

namespace ProjetoEscola.Api.Dtos
{
    public class EscolaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<TurmaDto> Turmas {get; set;}
    }
}