using System.Collections.Generic;

namespace ProjetoEscola.Api.Dtos
{
    public class TurmaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sala { get; set; }

        public string Professor { get; set; }
        
        public List<AlunoDto> Alunos { get; set; }

        public int EscolaId { get; set; }
    }
}