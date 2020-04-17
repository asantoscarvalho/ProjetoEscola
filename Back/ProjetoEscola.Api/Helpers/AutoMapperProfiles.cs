using System.Linq;
using AutoMapper;
using ProjetoEscola.Api.Dtos;
using ProjetoEscola.Domain;

namespace ProjetoEscola.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<Escola, EscolaDto>().ReverseMap();

            
            CreateMap<Turma, TurmaDto>().ReverseMap();

            CreateMap<Aluno, AlunoDto>().ReverseMap();

        }
    }
}