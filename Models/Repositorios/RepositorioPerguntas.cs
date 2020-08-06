using ProvaConceito.Models.Contexto;
using ProvaConceito.Models.ModelosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.Repositorios
{
    public interface IRepositorioPergunta
    {
        IEnumerable<Pergunta> GetPerguntas();
    }

    public class RepositorioPerguntas : IRepositorioPergunta
    {
        private JornadaTIContexto _contexto { get; set; }

        public RepositorioPerguntas(JornadaTIContexto contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Pergunta> GetPerguntas()
        {
            return _contexto.Perguntas;
        }
    }
}
