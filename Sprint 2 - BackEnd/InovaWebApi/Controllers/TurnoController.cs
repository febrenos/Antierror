using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class TurnoController : ControllerBase
    {
        private ITurnoRepository _turnoRepository;

        public TurnoController()
        {
            _turnoRepository = new TurnoRepository();
        }

        /// <summary>
        /// Cadastra um turno
        /// </summary>
        /// <param name="novoTurno">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Turno
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Turno novoTurno)
        {
            try
            {
                _turnoRepository.Cadastrar(novoTurno);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Lista todos os turnos
        /// </summary>
        /// <returns>Uma lista de tipos de turno e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipos de turno</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Turno
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                //Status Code 200
                return Ok(_turnoRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Busca um turno através do ID
        /// </summary>
        /// <param name="id">ID do turno que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Turno/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_turnoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Altera o status de um turno
        /// </summary>
        /// <param name="id">ID do turno que terá a situação alterada</param>
        /// <param name="turnoatualizado">Objeto com o parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Turno/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Turno turnoatualizado)
        {
            try
            {
                _turnoRepository.Atualizar(id, turnoatualizado);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Deleta um turno
        /// </summary>
        /// <param name="id">ID do turno que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Turno/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Turno turnoBuscado= _turnoRepository.BuscarPorId(id);
                _turnoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }
    }
}
