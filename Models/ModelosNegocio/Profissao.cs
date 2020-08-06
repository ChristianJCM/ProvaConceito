using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.ModelosNegocio
{
    public class Profissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual IEnumerable<Resposta> RespostasAssociadas { get; set; }
    }
}
