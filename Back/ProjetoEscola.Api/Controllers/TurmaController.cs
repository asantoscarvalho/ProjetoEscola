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
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;
        private readonly IMapper _map;
        public TurmaController(ITurmaRepository repo, IMapper map)
        {
            this._repo = repo;
            this._map = map;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> Get()
        {
            try
            {
                var turmas = await _repo.GetTurmaAsync();

                var results = _map.Map<IEnumerable<TurmaDto>>(turmas);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{TurmaId}")]
        public async Task<ActionResult> Get(int TurmaId)
        {
            try
            {
                var turma = await _repo.GetTurmaAsyncById(TurmaId);

                var results = _map.Map<TurmaDto>(turma);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }



        }

        [HttpGet("Nome/{Nome}")]
        public async Task<ActionResult> Get(string Nome)
        {
            try
            {
                var Turma = await _repo.GetTurmaAsyncByName(Nome);

                var results = _map.Map<IEnumerable<TurmaDto>>(Turma);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(TurmaDto model)
        {
            try
            {
                var modelo = _map.Map<Turma>(model);

                _repo.Add(modelo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/Turma/{model.Id}",  _map.Map<TurmaDto>(modelo));
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }

        [HttpPut("{Turmaid}")]
        public async Task<ActionResult> Put(int TurmaId, TurmaDto model)
        {
            try
            {
                var Turma = await _repo.GetTurmaAsyncById(TurmaId);
                if (Turma == null) return NotFound();

                _map.Map(model, Turma);

                _repo.Update(Turma);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/Turma/{model.Id}", _map.Map<TurmaDto>(Turma));
                }


            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        [HttpDelete("{TurmaId}")]
        public async Task<ActionResult> Delete(int TurmaId)
        {
            try
            {
                var turma = await _repo.GetTurmaAsyncById(TurmaId);
                if (turma == null) return NotFound();

                _repo.Delete(turma);

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