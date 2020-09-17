using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelos eventos
    /// </summary>
    public class TipoRespostaRepository : ITipoRespostaRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InovaVagasContext ctx = new InovaVagasContext();

        /// <summary>
        /// Atualiza um tipo resposta existente
        /// </summary>
        /// <param name="id">ID do tipo resposta que será atualizado</param>
        /// <param name="tipoRespostaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, TipoResposta tipoRespostaAtualizada)
        {
            TipoResposta TipoRespostaBuscada = ctx.TipoResposta.Find(id);

            if (TipoRespostaBuscada != null)
            {

                if (tipoRespostaAtualizada.NomeTipoResposta != null)
                {
                    TipoRespostaBuscada.NomeTipoResposta = TipoRespostaBuscada.NomeTipoResposta;
                }

                if (tipoRespostaAtualizada.Resposta != null)
                {
                    TipoRespostaBuscada.Resposta = TipoRespostaBuscada.Resposta;
                }
            }

        }

        /// <summary>
        /// Busca um tipo resposta por ID
        /// </summary>
        /// <param name="id">ID do tipo resposta que será buscado</param>
        /// <returns>Um tipo resposta buscado</returns>
        public TipoResposta BuscarPorId(int id)
        {
            TipoResposta tipoRespostaBuscada = ctx.TipoResposta

                .FirstOrDefault(e => e.IdTipoResposta == id);

            if (tipoRespostaBuscada != null)
            {
                return tipoRespostaBuscada;
            }
            return null;
        }

        /// <summary>
        /// Cadastra um novo tipo resposta
        /// </summary>
        /// <param name="novoTipoResposta">Objeto com as informações de cadastro</param>
        public void Cadastrar(TipoResposta novoTipoResposta)
        {
            ctx.TipoResposta.Add(novoTipoResposta);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo resposta
        /// </summary>
        /// <param name="id">ID do tipo resposta que será deletado</param>
        public void Deletar(int id)
        {
            TipoResposta tipoRespostaBuscada = ctx.TipoResposta.Find(id);
            ctx.TipoResposta.Remove(tipoRespostaBuscada);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os tipos resposta
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        public List<TipoResposta> Listar()
        {
            return ctx.TipoResposta
                .ToList();
        }
    }
}
