using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaConceito.Models.ModelosNegocio;
using ProvaConceito.Models.Repositorios;
using ProvaConceito.Models.ViewModels;

namespace ProvaConceito.Controllers
{
    public class QuestionarioController : Controller
    {
        private IRepositorioPergunta _repositorioPerguntas;
        private IRepositorioResposta _repositorioRespostas;

        public QuestionarioController(IRepositorioPergunta repoPerguntas, IRepositorioResposta repoRespostas)
        {
            _repositorioPerguntas = repoPerguntas;
            _repositorioRespostas = repoRespostas;
        }

        public IActionResult Index()
        {
            QuestionarioViewModels viewModel = new QuestionarioViewModels
            {
                Perguntas = new List<PerguntaViewModel>()
            };

            IList<Pergunta> perguntas = _repositorioPerguntas.GetPerguntas().ToList();

            foreach (var pergunta in perguntas)
            {
                IList<RespostaViewModel> respostas = pergunta.Respostas.Select(resposta =>
                   new RespostaViewModel() { RespostaId = resposta.Id, Descricao = resposta.Texto }).ToList();

                viewModel.Perguntas.Add(new PerguntaViewModel()
                {
                    PerguntaId = pergunta.Id,
                    Descricao = pergunta.Descricao,
                    Respostas = respostas
                });
            }

            return View(viewModel);
        }

        public IActionResult ProcessaQuestionario(RespostasQuestionarioViewModel viewModel)
        {
            IList<Profissao> profissoesExistentes = new List<Profissao>();

            if (ModelState.IsValid)
            {
                foreach (var resposta in viewModel.Respostas)
                {
                    profissoesExistentes.Add(_repositorioRespostas.GetResposta(resposta.RespostaId).Profissao);
                }

                IEnumerable<Profissao> profissoesCitadas = profissoesExistentes.Distinct();
                int maxCitacao = 0;
                Profissao prof = null;

                foreach (var profissaoCitada in profissoesCitadas)
                {
                    int citacoes = profissoesExistentes.Count(profissaoExistente => profissaoCitada.Id == profissaoExistente.Id);

                    if (citacoes > maxCitacao)
                    {
                        maxCitacao = citacoes;
                        prof = profissaoCitada;
                    }
                }

                return View("Resultado", new ResultadoViewModel() { SucessoResultado = true, ProfissaoRecomendada = prof.Descricao });
            }
            return View("Resultado", new ResultadoViewModel() { SucessoResultado = false });
        }
    }
}
