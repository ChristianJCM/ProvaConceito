using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.ModelosNegocio
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public int PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }

        public int ProfissaoId { get; set; }
        public virtual Profissao Profissao { get; set; }
    }
}
