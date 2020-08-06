using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConceito.Models.ViewModels
{
    public class QuestionarioViewModels
    {
        public IList<PerguntaViewModel> Perguntas { get; set; }
    }

    public class PerguntaViewModel
    {
        public int PerguntaId { get; set; }
        public string Descricao { get; set; }
        public IList<RespostaViewModel> Respostas { get; set; }

        public int RespostaSelecionadaId { get; set; }
    }

    public class RespostaViewModel
    {
        public int RespostaId { get; set; }
        public string Descricao { get; set; }
    }

    public class RespostasQuestionarioViewModel
    {
        public List<RespostaPostViewModel> Respostas { get; set; }
    }

    public class RespostaPostViewModel
    {
        public int PerguntaId { get; set; }
        public int RespostaId { get; set; }
    }

    public class ResultadoViewModel
    {
        public bool SucessoResultado { get; set; }
        public string ProfissaoRecomendada { get; set; }
    }
}
