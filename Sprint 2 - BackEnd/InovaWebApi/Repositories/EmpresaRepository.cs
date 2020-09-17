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
    public class EmpresaRepository : IEmpresaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InovaVagasContext ctx = new InovaVagasContext();

        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID do empresa que será atualizado</param>
        /// <param name="empresaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresa.Find(id);

            if (empresaBuscada != null)
            {

                if (empresaAtualizada.RazaoSocial != null)
                {
                    empresaBuscada.RazaoSocial = empresaAtualizada.RazaoSocial;
                }

                if (empresaAtualizada.NomeFantasia != null)
                {
                    empresaBuscada.NomeFantasia = empresaAtualizada.NomeFantasia;
                }

                if (empresaAtualizada.RamoAtuacao != null)
                {
                    empresaBuscada.RamoAtuacao = empresaAtualizada.RamoAtuacao;
                }

                if (empresaAtualizada.TamanhoEmpresa != null)
                {
                    empresaBuscada.TamanhoEmpresa = empresaAtualizada.TamanhoEmpresa;
                }

                if (empresaAtualizada.Cnpj != null)
                {
                    empresaBuscada.Cnpj = empresaAtualizada.Cnpj;
                }

                if (empresaAtualizada.Cnae != null)
                {
                    empresaBuscada.Cnae = empresaAtualizada.Cnae;
                }

                if (empresaAtualizada.CadastroAprovado != empresaBuscada.CadastroAprovado)
                {
                    empresaBuscada.CadastroAprovado = empresaAtualizada.CadastroAprovado;
                }

                if (empresaAtualizada.PessoaResponsavel != null)
                {
                    empresaBuscada.PessoaResponsavel = empresaAtualizada.PessoaResponsavel;
                }

                if (empresaAtualizada.VagasTotais != null)
                {
                    empresaBuscada.VagasTotais = empresaAtualizada.VagasTotais;
                }

                if (empresaAtualizada.VagasDisponiveis != null)
                {
                    empresaBuscada.VagasDisponiveis = empresaAtualizada.VagasDisponiveis;
                }

                if (empresaAtualizada.VagasEncerradas != null)
                {
                    empresaBuscada.VagasEncerradas = empresaAtualizada.VagasEncerradas;
                }

                if (empresaAtualizada.NumeroContratacoes != null)
                {
                    empresaBuscada.NumeroContratacoes = empresaAtualizada.NumeroContratacoes;
                }

                if (empresaAtualizada.IdUsuario != null)
                {
                    empresaBuscada.IdUsuario = empresaAtualizada.IdUsuario;
                }

                if (empresaAtualizada.IdUsuarioNavigation != null)
                {
                    empresaBuscada.IdUsuarioNavigation = empresaAtualizada.IdUsuarioNavigation;
                }

                if (empresaAtualizada.Vaga != null)
                {
                    empresaBuscada.Vaga = empresaAtualizada.Vaga;
                }

                ctx.Empresa.Update(empresaBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca uma empresa por ID
        /// </summary>
        /// <param name="id">ID do empresa que será buscado</param>
        /// <returns>Um empresa buscado</returns>
        public Empresa BuscarPorId(int id)
        {
            Empresa empresaBuscada = ctx.Empresa

                .FirstOrDefault(e => e.IdEmpresa == id);

            if (empresaBuscada != null)
            {
                return empresaBuscada;
            }
            return null;
        }

        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações de cadastro</param>
        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresa.Add(novaEmpresa);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id">ID da empresa que será deletado</param>
        public void Deletar(int id)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(a => a.IdEmpresa == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == empresaBuscada.IdUsuario);
            if (empresaBuscada.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);
                ctx.Empresa.Remove(empresaBuscada);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos as empresas
        /// </summary>
        /// <returns>Uma lista de empresa</returns>
        public List<Empresa> Listar()
        {
            return ctx.Empresa
                .Include(e => e.IdUsuarioNavigation)

                .ToList();
        }

        /// <summary>
        /// Lista todos as emrpresas em ordem alfabetica
        /// </summary>
        /// <returns>Uma lista de empresa</returns>
        public List<Empresa> ListarPorOrdemAlfabetica()
        {
            return ctx.Empresa
               .Include(e => e.IdUsuarioNavigation)
               .OrderBy(e => e.NomeFantasia)

               .ToList();
        }
    }
}
