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
    /// <summary>
    /// Controller responsável pelos endpoints referentes a empresa
    /// </summary>
    
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// Cadastra uma empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa
        //[Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Empresa novaEmpresa)
        {
           
            try
            {
                _empresaRepository.Cadastrar(novaEmpresa);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>Uma lista de empresas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de empresas</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_empresaRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest( error);
            }            
        }

        /// <summary>
        /// Busca uma empresa através do ID
        /// </summary>
        /// <param name="id">ID do empresa que será buscado</param>
        /// <returns>Um empresa buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o empresa buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_empresaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        /// <summary>
        /// Altera o status de uma empresa
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="empresaAtualizada">Objeto com o parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpPut("{id}")]
        public IActionResult Put(int id,  Empresa empresaAtualizada)
        {
            try
            {
                _empresaRepository.Atualizar(id, empresaAtualizada);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
            
        }

        /// <summary>
        /// Deleta uma Empresa
        /// </summary>
        /// <param name="id">ID do empresa que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.BuscarPorId(id);
                _empresaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todas as empresas em ordem alfabetica
        /// </summary>
        /// <returns>Uma lista de tipos de empresa e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipos de empresa</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa
        [HttpGet("OrdemAlfabetica")]
        public IActionResult GetByAlphabetical()
        {
            try
            {
                return Ok(_empresaRepository.ListarPorOrdemAlfabetica());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
