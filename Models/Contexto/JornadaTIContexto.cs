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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dados iniciais para teste
            IList<Pergunta> perguntas = new List<Pergunta>();
            perguntas.Add(new Pergunta() { Id = 1, Descricao = "Você gosta de testar aplicações?" });
            perguntas.Add(new Pergunta() { Id = 2, Descricao = "Você gosta de desenhar telas para as aplicações?" });
            perguntas.Add(new Pergunta() { Id = 3, Descricao = "Você gosta de aprender novas linguagens e frameworks?" });
            perguntas.Add(new Pergunta() { Id = 4, Descricao = "Qual das seguintes personalidades mais te inspira?" });

            IList<Profissao> profissoes = new List<Profissao>();
            profissoes.Add(new Profissao() { Id = 1, Descricao = "QA" });
            profissoes.Add(new Profissao() { Id = 2, Descricao = "UX" });
            profissoes.Add(new Profissao() { Id = 3, Descricao = "Desenvolvedor" });

            IList<Resposta> respostas = new List<Resposta>();
            respostas.Add(new Resposta() { Id = 1, PerguntaId = 1, ProfissaoId = 1, Texto = "Sou fanático por testes!" });
            respostas.Add(new Resposta() { Id = 2, PerguntaId = 1, ProfissaoId = 2, Texto = "Gosto de testar idéias com o usuário!" });
            respostas.Add(new Resposta() { Id = 3, PerguntaId = 1, ProfissaoId = 3, Texto = "Testar não é minha praia definitivamente!" });


            respostas.Add(new Resposta() { Id = 4, PerguntaId = 2, ProfissaoId = 1, Texto = "Não gosto de desenhos de telas!" });
            respostas.Add(new Resposta() { Id = 5, PerguntaId = 2, ProfissaoId = 2, Texto = "Acho incrível e me interesso em entender o usuário cada vez mais!" });
            respostas.Add(new Resposta() { Id = 6, PerguntaId = 2, ProfissaoId = 3, Texto = "Até acho legal ver a concepção das telas!" });

            respostas.Add(new Resposta() { Id = 7, PerguntaId = 3, ProfissaoId = 1, Texto = "Acho legal usar frameworks para teste de aplicações." });
            respostas.Add(new Resposta() { Id = 8, PerguntaId = 3, ProfissaoId = 2, Texto = "Detesto trabalhar com tecnologias." });
            respostas.Add(new Resposta() { Id = 9, PerguntaId = 3, ProfissaoId = 3, Texto = "Acho fantástico!" });

            respostas.Add(new Resposta() { Id = 12, PerguntaId = 4, ProfissaoId = 1, Texto = "Thomas Edison" });
            respostas.Add(new Resposta() { Id = 11, PerguntaId = 4, ProfissaoId = 2, Texto = "Steve Jobs" });
            respostas.Add(new Resposta() { Id = 10, PerguntaId = 4, ProfissaoId = 3, Texto = "Bill Gates" });

            modelBuilder.Entity<Pergunta>().HasData(perguntas);
            modelBuilder.Entity<Profissao>().HasData(profissoes);
            modelBuilder.Entity<Resposta>().HasData(respostas);
        }
    }
}
