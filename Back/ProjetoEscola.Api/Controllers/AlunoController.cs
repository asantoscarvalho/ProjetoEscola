using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Api.Dtos;
using ProjetoEscola.Domain;
using ProjetoEscola.Repository.inteface;

namespace ProjetoEscola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repo;
        private readonly IMapper _map;

        public AlunoController(IAlunoRepository repo, IMapper map)
        {
            this._repo = repo;
            this._map = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Get()
        {
            try
            {
                var Alunos = await _repo.GetAlunoAsync();

                var results = _map.Map<IEnumerable<AlunoDto>>(Alunos);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<ActionResult> Get(int AlunoId)
        {
            try
            {
                var Aluno = await _repo.GetAlunoAsyncById(AlunoId);

                var results = _map.Map<AlunoDto>(Aluno);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }



        }

        [HttpGet("Nome/{Nome}")]
        public async Task<ActionResult> Get(string Nome)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncByName(Nome);

                var results = _map.Map<IEnumerable<AlunoDto>>(aluno);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AlunoDto model)
        {
            try
            {
                var modelo = _map.Map<Aluno>(model);


                _repo.Add(modelo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/aluno/{model.Id}",  _map.Map<AlunoDto>(modelo));
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }

        [HttpPut("{Alunoid}")]
        public async Task<ActionResult> Put(int AlunoId, AlunoDto model)
        {
            try
            {
                var Aluno = await _repo.GetAlunoAsyncById(AlunoId);
                if (Aluno == null) return NotFound();

                _map.Map(model, Aluno);

                _repo.Update(Aluno);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/aluno/{model.Id}", _map.Map<AlunoDto>(Aluno));
                }


            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        [HttpDelete("{AlunoId}")]
        public async Task<ActionResult> Delete(int AlunoId)
        {
            try
            {
                var Aluno = await _repo.GetAlunoAsyncById(AlunoId);
                if (Aluno == null) return NotFound();

                _repo.Delete(Aluno);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }


    }
}