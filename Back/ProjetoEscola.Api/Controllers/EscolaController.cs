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
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaRepository _repo;
        private readonly IMapper _map;

        public EscolaController(IEscolaRepository repo, IMapper map)
        {
            this._repo = repo;
            this._map = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escola>>> Get()
        {
            try
            {
                var escolas = await _repo.GetEscolaAsync();

                var results = _map.Map<IEnumerable<EscolaDto>>(escolas);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{EscolaId}")]
        public async Task<ActionResult> Get(int EscolaId)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId);

                var results = _map.Map<EscolaDto>(escola);

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
                var escola = await _repo.GetEscolaAsyncByName(Nome);

                var results = _map.Map<IEnumerable<EscolaDto>>(escola);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EscolaDto model)
        {
            try
            {
                var modelo = _map.Map<Escola>(model);

                _repo.Add(modelo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/escola/{model.Id}",  _map.Map<EscolaDto>(modelo));
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }

        [HttpPut("{Escolaid}")]
        public async Task<ActionResult> Put(int EscolaId, EscolaDto model)
        {
            try
            {
                var Escola = await _repo.GetEscolaAsyncById(EscolaId);
                if (Escola == null) return NotFound();

                _map.Map(model, Escola);

                _repo.Update(Escola);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/escola/{model.Id}", _map.Map<EscolaDto>(Escola));
                }


            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        [HttpDelete("{EscolaId}")]
        public async Task<ActionResult> Delete(int EscolaId)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId);
                if (escola == null) return NotFound();

                _repo.Delete(escola);

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