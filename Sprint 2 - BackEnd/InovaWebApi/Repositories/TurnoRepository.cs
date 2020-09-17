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
    public class TurnoRepository : ITurnoRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InovaVagasContext ctx = new InovaVagasContext();

        /// <summary>
        /// Atualiza um turno existente
        /// </summary>
        /// <param name="id">ID do turno que será atualizado</param>
        /// <param name="turnoatuAlizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Turno turnoatuAlizado)
        {
            Turno turnoBuscado = ctx.Turno.Find(id);

            if (turnoBuscado != null)
            {
                if (turnoatuAlizado.NomeTurno != null)
                {
                    turnoBuscado.NomeTurno = turnoBuscado.NomeTurno;
                }
            }
            ctx.Turno.Update(turnoBuscado);
            ctx.SaveChanges();

        }

        /// <summary>
        /// Busca um turno por ID
        /// </summary>
        /// <param name="id">ID do turno que será buscado</param>
        /// <returns>Um turno buscado</returns>
        public Turno BuscarPorId(int id)
        {
            Turno turnoBuscado = ctx.Turno
            
            .FirstOrDefault(e => e.IdTurno == id);

            if (turnoBuscado != null)
            {
                return turnoBuscado;
            }
            return null;
        }

        /// <summary>
        /// Cadastra um novo turno
        /// </summary>
        /// <param name="novoTurno">Objeto com as informações de cadastro</param>
        public void Cadastrar(Turno novoTurno)
        {
            ctx.Turno.Add(novoTurno);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um turno
        /// </summary>
        /// <param name="id">ID do turno que será deletado</param>
        public void Deletar(int id)
        {
            ctx.Turno.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os turnos
        /// </summary>
        /// <returns>Uma lista de turnos</returns>
        public List<Turno> Listar()
        {
            return ctx.Turno.ToList();
        }

    }
}
