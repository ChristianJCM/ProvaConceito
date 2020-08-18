using ProvaConceito.Models.ModelosNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConceito.Testes
{
    public static class DadosTestePergunta
    {
        public static IList<Pergunta> GetListaPerguntasExemploContendoRespostasExemplo()
        {
            return new List<Pergunta>{
                        new Pergunta { Id = 1, Descricao = "Pergunta 1", Respostas = new List<Resposta>{new Resposta { Id = 1, PerguntaId = 1, Texto = "Resposta 1-1" }, new Resposta() { Id = 2, PerguntaId = 1, Texto = "Resposta 1-2" }} },
                        new Pergunta { Id = 2, Descricao = "Pergunta 2", Respostas = new List<Resposta>{new Resposta { Id = 3, PerguntaId = 2, Texto = "Resposta 2-1" }, new Resposta() { Id = 4, PerguntaId = 2, Texto = "Resposta 2-2" }} }
                    };
        }
    }
}
