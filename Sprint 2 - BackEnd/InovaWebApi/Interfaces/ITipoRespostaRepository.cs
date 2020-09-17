using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ITipoRespostaRepository
    {

        /// <summary>
        /// Cadastra um novo tipo resposta
        /// </summary>
        /// <param name="novoTipoResposta">Objeto com as informações de cadastro</param>
        void Cadastrar(TipoResposta novoTipoResposta);

        /// <summary>
        /// Lista todos os tipos resposta
        /// </summary>
        /// <returns>Uma lista de tipo resposta</returns>
        List<TipoResposta> Listar();

        /// <summary>
        /// Busca um tipo resposta por ID
        /// </summary>
        /// <param name="id">ID do tipo resposta que será buscado</param>
        /// <returns>Um tipo resposta buscado</returns>
        TipoResposta BuscarPorId(int id);

        /// <summary>
        /// Atualiza um tipo resposta existente
        /// </summary>
        /// <param name="id">ID do tipo resposta que será atualizado</param>
        /// <param name="tipoRespostaAtualizado0">Objeto com as novas informações</param>
        void Atualizar(int id, TipoResposta tipoRespostaAtualizado0);

        /// <summary>
        /// Deleta um tipo resposta
        /// </summary>
        /// <param name="id">ID do tipo resposta que será deletado</param>
        void Deletar(int id);
    }
}
