using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.Contexto
{
    // Classe usada para permitir o uso de serviços em tempo de design (Ex.: executar Migrations) com Contextos sem construtor default(sem parâmetros)
    public class ContextoFactoryParaMigrations : IDesignTimeDbContextFactory<JornadaTIContexto>
    {
        private const string _connectionString = "Server=CHRISTIAN-FERNA\\SQLEXPRESS;Database=JornadaTiBd;Trusted_Connection=True;";

        public JornadaTIContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JornadaTIContexto>();
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_connectionString);
            return new JornadaTIContexto(optionsBuilder.Options);
        }
    }
}
