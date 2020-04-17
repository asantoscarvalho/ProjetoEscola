namespace ProjetoEscola.Api.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public int TurmaId {get; set;} 
        public TurmaDto Turma {get; set;}
    }
}