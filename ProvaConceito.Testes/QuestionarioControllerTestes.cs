using Microsoft.AspNetCore.Mvc;
using Moq;
using ProvaConceito.Controllers;
using ProvaConceito.Models.ModelosNegocio;
using ProvaConceito.Models.Repositorios;
using ProvaConceito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Xunit;

namespace ProvaConceito.Testes
{
    #region Classe Comparador QuestionarioViewModel
    public class ComparadorQuestionarioViewModel : EqualityComparer<QuestionarioViewModels>
    {
        public override bool Equals([AllowNull] QuestionarioViewModels x, [AllowNull] QuestionarioViewModels y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x != null && y != null) return x.Perguntas.SequenceEqual(y.Perguntas, new ComparadorPerguntaViewModel());
            return false;
        }

        public override int GetHashCode([DisallowNull] QuestionarioViewModels obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ComparadorPerguntaViewModel : EqualityComparer<PerguntaViewModel>
    {
        public override bool Equals([AllowNull] PerguntaViewModel x, [AllowNull] PerguntaViewModel y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x != null && y != null) return x.PerguntaId == y.PerguntaId;
            return false;
        }

        public override int GetHashCode([DisallowNull] PerguntaViewModel obj)
        {
            return obj.GetHashCode();
        }
    }
    #endregion

    #region Classe Comparador ResultadoViewModel
    public class ComparadorResultadoViewModel : EqualityComparer<ResultadoViewModel>
    {
        public override bool Equals([AllowNull] ResultadoViewModel x, [AllowNull] ResultadoViewModel y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if (x != null && y != null) return x.SucessoResultado == y.SucessoResultado && x.ProfissaoRecomendada == y.ProfissaoRecomendada;
            return false;
        }

        public override int GetHashCode([DisallowNull] ResultadoViewModel obj)
        {
            return obj.GetHashCode();
        }
    }
    #endregion


    #region Testes QuestionarioController

    public class QuestionarioControllerTestes
    {
        [Fact]
        public void Index_RepositoriosVazios_RetornaResultadoTipoViewResult()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            // Act
            QuestionarioController controller = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            var resposta = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(resposta);
        }

        [Fact]
        public void Index_RepositorioPerguntasPreenchido_RetornaResultadoTipoViewResult()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            mockRepositorioPerguntas.Setup(config => config.GetPerguntas()).Returns(
                new List<Pergunta> {
                    new Pergunta { Id = 1, Descricao = "Pergunta 1", Respostas = new List<Resposta>{new Resposta { Id = 1, PerguntaId = 1, Texto = "Resposta 1-1" }, new Resposta() { Id = 2, PerguntaId = 1, Texto = "Resposta 1-2" }} },
                    new Pergunta { Id = 2, Descricao = "Pergunta 2", Respostas = new List<Resposta>{new Resposta { Id = 3, PerguntaId = 2, Texto = "Resposta 2-1" }, new Resposta() { Id = 4, PerguntaId = 2, Texto = "Resposta 2-2" }} }
                    });

            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            // Act
            QuestionarioController controller = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            var resposta = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(resposta);
        }

        [Fact]
        public void Index_RepositorioPerguntasPreenchido_RetornaViewResultComViewModel()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            mockRepositorioPerguntas.Setup(config => config.GetPerguntas()).Returns(
                new List<Pergunta> {
                    new Pergunta { Id = 1, Descricao = "Pergunta 1", Respostas = new List<Resposta>{new Resposta { Id = 1, PerguntaId = 1, Texto = "Resposta 1-1" }, new Resposta() { Id = 2, PerguntaId = 1, Texto = "Resposta 1-2" }} },
                    new Pergunta { Id = 2, Descricao = "Pergunta 2", Respostas = new List<Resposta>{new Resposta { Id = 3, PerguntaId = 2, Texto = "Resposta 2-1" }, new Resposta() { Id = 4, PerguntaId = 2, Texto = "Resposta 2-2" }} }
                    });

            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            QuestionarioViewModels viewModelEsperado = new QuestionarioViewModels()
            {
                Perguntas = new List<PerguntaViewModel> {
                    new PerguntaViewModel{ PerguntaId = 1, Descricao = "Pergunta 1"  },
                    new PerguntaViewModel{ PerguntaId = 2, Descricao = "Pergunta 2" },
                }
            };

            // Act
            QuestionarioController controller = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            ViewResult viewResult = (ViewResult)controller.Index();
            QuestionarioViewModels viewModelAtual = (QuestionarioViewModels)viewResult.Model;

            // Assert
            Assert.Equal(viewModelEsperado, viewModelAtual, new ComparadorQuestionarioViewModel());
        }

        [Fact]
        public void Index_RepositoriosVazios_RetornaViewResultComViewModel()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            QuestionarioViewModels viewModelEsperado = new QuestionarioViewModels()
            {
                Perguntas = new List<PerguntaViewModel>() { }
            };

            // Act
            QuestionarioController controller = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            ViewResult viewResult = (ViewResult)controller.Index();
            QuestionarioViewModels viewModelAtual = (QuestionarioViewModels)viewResult.Model;

            // Assert
            Assert.Equal(viewModelEsperado, viewModelAtual, new ComparadorQuestionarioViewModel());
        }

        [Fact]
        public void ProcessaQuestionario_ViewModelInvalido_RetornaViewResultComViewModelResultadoFalso()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            QuestionarioController questionarioController = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            questionarioController.ModelState.AddModelError("viewModel", "O ViewModel deve ser especificado");

            ResultadoViewModel viewModelRespostaEsperado = new ResultadoViewModel() { SucessoResultado = false };

            RespostasQuestionarioViewModel viewModel = null;

            // Act
            IActionResult resposta = questionarioController.ProcessaQuestionario(viewModel);

            ViewResult viewResult = (ViewResult)resposta;
            ResultadoViewModel viewModelRespostaAtual = (ResultadoViewModel)viewResult.Model;

            // Assert
            Assert.Equal(viewModelRespostaEsperado, viewModelRespostaAtual, new ComparadorResultadoViewModel());
        }

        [Fact]
        public void ProcessaQuestionario_ViewModelValido_RetornaViewResultComViewModelResultadoSucesso()
        {
            // Arrange
            var mockRepositorioPerguntas = new Mock<IRepositorioPergunta>();
            var mockRepositorioRespostas = new Mock<IRepositorioResposta>();

            Profissao profissaoA = new Profissao { Id = 1, Descricao = "Profissão A" };
            Profissao profissaoB = new Profissao { Id = 2, Descricao = "Profissão B" };

            List<Resposta> listaRespostas = new List<Resposta>();
            listaRespostas.Add(new Resposta() { Id = 1, PerguntaId = 1, Texto = "Resposta 1-1", Profissao = profissaoA });
            listaRespostas.Add(new Resposta() { Id = 2, PerguntaId = 1, Texto = "Resposta 1-2", Profissao = profissaoB });
            listaRespostas.Add(new Resposta() { Id = 3, PerguntaId = 2, Texto = "Resposta 2-1", Profissao = profissaoA });
            listaRespostas.Add(new Resposta() { Id = 4, PerguntaId = 2, Texto = "Resposta 2-2", Profissao = profissaoB });

            mockRepositorioRespostas.Setup(repositorio => repositorio.GetResposta(It.IsAny<int>())).Returns((int id) => listaRespostas.FirstOrDefault(resposta => resposta.Id == id));

            QuestionarioController questionarioController = new QuestionarioController(mockRepositorioPerguntas.Object, mockRepositorioRespostas.Object);
            ResultadoViewModel viewModelRespostaEsperado = new ResultadoViewModel() { SucessoResultado = true, ProfissaoRecomendada = profissaoA.Descricao };

            RespostasQuestionarioViewModel viewModel = new RespostasQuestionarioViewModel()
            {
                Respostas = new List<RespostaPostViewModel>{
                            new RespostaPostViewModel { PerguntaId = 1, RespostaId = 1},
                            new RespostaPostViewModel { PerguntaId = 2, RespostaId = 3}}
            };

            // Act
            IActionResult resposta = questionarioController.ProcessaQuestionario(viewModel);

            ViewResult viewResult = (ViewResult)resposta;
            ResultadoViewModel viewModelRespostaAtual = (ResultadoViewModel)viewResult.Model;

            // Assert
            Assert.Equal(viewModelRespostaEsperado, viewModelRespostaAtual, new ComparadorResultadoViewModel());
        }
    }
    #endregion
}