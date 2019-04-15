var dominio = "http://localhost:54740/api/"

function cadastrarFormulario(dados) {
    var url = dominio + "v1/Formulario/cadastrar";

    OnPost(dados, url);
}

function OnPost(dados, url) {

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(dados),
        contentType: "application/json; charset=utf-8",
        success: function onSuccess() {
            alert("Foi executado com sucesso!!!  :)");
        },
        error: function onError(e, status, response) {
            alert("Erro no server. Tente novamente mais tarde.");
        }
    });
}


