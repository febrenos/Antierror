using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IEmpresaRepository
    {

        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações de cadastro</param>
        void Cadastrar(Empresa novaEmpresa);

        /// <summary>
        /// Lista todos as empresas
        /// </summary>
        /// <returns>Uma lista de empresa</returns>
        List<Empresa> Listar();

        /// <summary>
        /// Busca uma empresa por ID
        /// </summary>
        /// <param name="id">ID do empresa que será buscado</param>
        /// <returns>Uma empresa buscado</returns>
        Empresa BuscarPorId(int id);


        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID do empresa que será atualizado</param>
        /// <param name="empresaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Empresa empresaAtualizada);

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id">ID do empresa que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos as empresas em ordem alfabetica
        /// </summary>
        /// <returns>Uma lista de empresa</returns>
        List<Empresa> ListarPorOrdemAlfabetica();

    }
}
