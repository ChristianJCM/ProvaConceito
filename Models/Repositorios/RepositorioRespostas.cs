using ProvaConceito.Models.Contexto;
using ProvaConceito.Models.ModelosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.Repositorios
{
    public interface IRepositorioResposta
    {
        Resposta GetResposta(int id);
    }

    public class RepositorioRespostas : IRepositorioResposta
    {
        private JornadaTIContexto _contexto { get; set; }

        public RepositorioRespostas(JornadaTIContexto contexto)
        {
            _contexto = contexto;
        }

        public Resposta GetResposta(int id)
        {
            return _contexto.Respostas.Find(id);
        }
    }
}
