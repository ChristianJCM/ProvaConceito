using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.ModelosNegocio
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual IEnumerable<Resposta> Respostas { get; set; }
    }
}
