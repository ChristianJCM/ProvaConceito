using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProvaConceito.Models.Contexto;
using ProvaConceito.Models.ModelosNegocio;
using ProvaConceito.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace ProvaConceito.Testes
{
    #region Classe JornadaTIContextoEmMemoria
    public class JornadaTIContextoEmMemoria
    {
        private JornadaTIContexto _contexto;

        public JornadaTIContextoEmMemoria()
        {
            _contexto = new JornadaTIContexto(new DbContextOptionsBuilder<JornadaTIContexto>().UseSqlite(GetConnectionBancoSqlLite()).Options);
            _contexto.Database.EnsureCreated();
        }

        private static DbConnection GetConnectionBancoSqlLite()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        public JornadaTIContexto GetContexto()
        {
            return _contexto;
        }
    }
    #endregion

    
    #region Classes Comparação Objetos Pergunta
    public class ComparadorRegistrosPerguntas : IEqualityComparer<IEnumerable<Pergunta>>
    {
        public bool Equals([AllowNull] IEnumerable<Pergunta> x, [AllowNull] IEnumerable<Pergunta> y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x != null && y != null) return x.SequenceEqual(y, new ComparadorPergunta());
            return false;
        }

        public int GetHashCode([DisallowNull] IEnumerable<Pergunta> obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ComparadorPergunta : IEqualityComparer<Pergunta>
    {
        public bool Equals([AllowNull] Pergunta x, [AllowNull] Pergunta y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x != null && y != null) return x.Id == y.Id;
            return false;
        }

        public int GetHashCode([DisallowNull] Pergunta obj)
        {
            return obj.GetHashCode();
        }
    }
    #endregion


    #region Testes RepositorioPergunta
    public class RepositorioPerguntasTestes
    {
        [Fact]
        public void GetPerguntas_ContextoEstadoInicial_RetornaRegistrosEstadoInicial()
        {
            // Arrange
            var mockContexto = new JornadaTIContextoEmMemoria();
            IEnumerable<Pergunta> perguntasEsperadas = mockContexto.GetContexto().Perguntas;

            // Act
            RepositorioPerguntas repositorio = new RepositorioPerguntas(mockContexto.GetContexto());
            IEnumerable<Pergunta> perguntasAtuais = repositorio.GetPerguntas();

            // Assert
            Assert.Equal<IEnumerable<Pergunta>>(perguntasEsperadas, perguntasAtuais, new ComparadorRegistrosPerguntas());
        }

        [Fact]
        public void GetPerguntas_Add2PerguntasContextoEstadoInicial_RetornaRegistrosEstadoInicialMaisRegistrosAdicionados()
        {
            // Arrange
            var mockContexto = new JornadaTIContextoEmMemoria();

            IList<Pergunta> perguntasTeste = new List<Pergunta>();
            perguntasTeste.Add(new Pergunta() { Id = 5, Descricao = "Você gosta de testar aplicações?" });
            perguntasTeste.Add(new Pergunta() { Id = 6, Descricao = "Você gosta de desenhar telas para as aplicações?" });
            mockContexto.GetContexto().Perguntas.AddRange(perguntasTeste);
            mockContexto.GetContexto().SaveChanges();

            IEnumerable<Pergunta> perguntasEsperadas = mockContexto.GetContexto().Perguntas;

            // Act
            RepositorioPerguntas repositorio = new RepositorioPerguntas(mockContexto.GetContexto());
            IEnumerable<Pergunta> perguntasAtuais = repositorio.GetPerguntas();

            // Assert
            Assert.Equal<IEnumerable<Pergunta>>(perguntasEsperadas, perguntasAtuais, new ComparadorRegistrosPerguntas());
        }
    }
    #endregion
}
