using Microsoft.EntityFrameworkCore;
using ProvaConceito.Models.ModelosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.Contexto
{
    public class JornadaTIContexto : DbContext
    {
        public JornadaTIContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
    }
}
