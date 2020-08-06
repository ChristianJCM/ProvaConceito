$(document).ready(function () {

    $("#formQuestionario").submit(function (event) {
        event.preventDefault();

        var url = $(this).attr("action");

        var respostas = $(":radio:checked[name*='Resposta_']")

        var respostasArray = [];

        respostas.each(function (index, elemento) {
            respostasArray.push({ PerguntaId: $(elemento).data("perguntaid"), RespostaId: $(elemento).val() });
        });

        var dados = { Respostas: respostasArray };
        $.ajax({
            type: "POST",
            url: url,
            data: dados,
            success: function (resposta) {
                $("#conteudoPrincipal").html(resposta);
            },
            error: function (resposta) {
                alert("Erro ao processar o questionário");
            }
        });
    });

})