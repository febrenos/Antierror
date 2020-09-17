using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ITurnoRepository
    {


        /// <summary>
        /// Cadastra um novo turno
        /// </summary>
        /// <param name="novoTurno">Objeto com as informações de cadastro</param>
        void Cadastrar(Turno novoTurno);

        /// <summary>
        /// Lista todos os turno
        /// </summary>
        /// <returns>Uma lista de turno</returns>
        List<Turno> Listar();


        /// <summary>
        /// Busca um turno por ID
        /// </summary>
        /// <param name="id">ID do turno que será buscado</param>
        /// <returns>Um turno buscado</returns>
        Turno BuscarPorId(int id);


        /// <summary>
        /// Deleta um turno
        /// </summary>
        /// <param name="id">ID do turno que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um turno existente
        /// </summary>
        /// <param name="id">ID do turno que será atualizado</param>
        /// <param name="turnoatualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Turno turnoatualizado);
    }
}
