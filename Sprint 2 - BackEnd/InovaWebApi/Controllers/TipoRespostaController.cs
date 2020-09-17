using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRespostaController : ControllerBase
    {
        private ITipoRespostaRepository _tipoRespostaRepository;

        public TipoRespostaController()
        {
            _tipoRespostaRepository = new TipoRespostaRepository();
        }

        /// <summary>
        /// Lista todos os tipos respostas
        /// </summary>
        /// <returns>Uma lista de tipos de resposta e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipos de tipo resposta</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TipoResposta
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoRespostaRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo resposta através do ID
        /// </summary>
        /// <param name="id">ID do tipo resposta que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TipoResposta/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoRespostaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
            
        }

        /// <summary>
        /// Cadastra um tipo resposta
        /// </summary>
        /// <param name="novoTipoResposta">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TipoResposta
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoResposta novoTipoResposta)
        {
            try
            {
                _tipoRespostaRepository.Cadastrar(novoTipoResposta);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
           
        }

        /// <summary>
        /// Deleta um tipo resposta
        /// </summary>
        /// <param name="id">ID do tipo resposta que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TipoResposta/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoResposta tipoRespostaBuscada = _tipoRespostaRepository.BuscarPorId(id);
                _tipoRespostaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
