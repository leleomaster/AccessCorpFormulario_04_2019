
$(function () {

    $("#erro-quantidade-linha-obrigatorio").hide();
    $("#erro-minimo-tres-tipos-distintos-campos").hide();
    
    $("#DataVencimentoFim").prop("disabled", true);
    esconderOuMostrar(true, "btnAdicinarCampoParaCombobox");
    habilitarOuDesabilitar(false, "adiconarMaisCampos");
    addEvents();
});

$(document).on('click', '#removerLabel', function () {
    $(this).parent().remove();
});

$(document).on('click', '.excluir-linha-tabela', function () {
    $(this).parent().parent().remove();
});

function addEvents() {

    $("form").submit(function () {

        var linhaTabelMaiorIgualDez = validarQuatidadeLinhaTabela();
        var minimoTresTiposDistintosCampos = temMinimoTresTiposDistintosCampos();

        var formValid = $(this).valid() && validarDatasVencimento(true) && minimoTresTiposDistintosCampos && linhaTabelMaiorIgualDez;

        if (formValid) {
            salvar();
        }

        return false;
    });

    $("#idTipoCampo").on("change", function () {
        var tipoCampo = $(this).find(":selected").text();

        if (tipoCampo.toUpperCase() === "DROPBOX") {
            esconderOuMostrar(false, "btnAdicinarCampoParaCombobox");
        } else {
            esconderOuMostrar(true, "btnAdicinarCampoParaCombobox");
        }
        verificarTipoCampoPreenchidos();
        removerLabelCombo();
    });

    $("#idTipoValorCampo").on("change", function () {
        verificarTipoCampoPreenchidos();
    });

    $("#btnAdicinarCampoParaCombobox").on("click", function () {
        addValoresCombo();
    });

    $("#btnAdiconarMaisCampos").on("click", function () {
        adiconarMaisCampos();
        removerLabelCombo();
    });
}

function onSelectDatepicker(dateText, obj) {

    validarDatasVencimento();

    var id = $(obj).attr("id");

    if (id === "DataVencimentoInicio") {
        validarDatasVencimento(false);
    } else {
        validarDatasVencimento(true);
    }

    if ((dateText !== null && dateText !== undefined)) {
        $("#DataVencimentoFim").prop("disabled", false);
    } else {

        $("#DataVencimentoFim").prop("disabled", true);
    }
}

function ehDataMenorOuIgualData(dataMenor, dataMaior) {
    return (dataMenor <= dataMaior);
}

function validarDatasVencimento(validarDataFim) {
    var inicio = $("#DataVencimentoInicio").val();

    var dataInicio = new Date(formatarData(inicio));
    var dataFim = new Date(formatarData($("#DataVencimentoFim").val()));

    var atual = dataAtualFormatada();
    var dataAtual = new Date(formatarData(atual));

    var ehValidoDatas = true;

    var msgErroDataInicioMenorOuIgualAtual = "A data de início tem que ser menor ou igual a data Atual!";
    var msgErroDataFimMaiorOrIgualInicio = "A Data Fim tem que ser maior ou igual que a Data Início!";
    var msgErroDataFimMaiorOrIgualAtual = "A Data Fim tem que ser maior ou igual que a Data Atual!";

    if (inicio !== null && inicio !== undefined && inicio !== "") {
        showOrHideMenssageDatas(true, null, "error-data-vencimento-inicio");
        showOrHideMenssageDatas(true, null, "error-data-vencimento-fim");

        if (!ehDataMenorOuIgualData(dataInicio, dataAtual)) {

            showOrHideMenssageDatas(false, msgErroDataInicioMenorOuIgualAtual, "error-data-vencimento-inicio");
            ehValidoDatas = false;
        }

        if (!ehDataMenorOuIgualData(dataInicio, dataFim) && validarDataFim) {
            showOrHideMenssageDatas(false, msgErroDataFimMaiorOrIgualInicio, "error-data-vencimento-fim");
            ehValidoDatas = false;
        }

        if (!ehDataMenorOuIgualData(dataAtual, dataFim) && validarDataFim) {
            showOrHideMenssageDatas(false, msgErroDataFimMaiorOrIgualAtual, "error-data-vencimento-fim");
            ehValidoDatas = false;
        }
    }

    return ehValidoDatas;
}

function showOrHideMenssageDatas(ehValidoDatas, mensagemErro, idSpanErro) {
    $("#" + idSpanErro).empty();

    if (!ehValidoDatas) {
        $("#" + idSpanErro).text(mensagemErro);

        $("#" + idSpanErro).show();
    } else {
        $("#" + idSpanErro).hide();
    }
}

function temMinimoTresTiposDistintosCampos() {

    var tipoCampos = [];
    var ehValido = false;

    $("#table-campos tbody tr").each(function () {

        var valor = $(this).find("td:nth-child(1)").text();
        tipoCampos.push(valor);
    });

    var qtdeTipoCampos = jQuery.unique(tipoCampos);

    ehValido = qtdeTipoCampos.length >= 3;

    esconderOuMostrar(ehValido, "erro-minimo-tres-tipos-distintos-campos");

    return ehValido;
}

function validarQuatidadeLinhaTabela() {
    var ehValido = true;
    if ($("#table-campos tbody tr ").length < 10) {
        $("#erro-quantidade-linha-obrigatorio").show();
        ehValido = false;
    } else {
        $("#erro-quantidade-linha-obrigatorio").hide();
        ehValido = true;
    }
    return ehValido;
}

function salvar() {
    var nomeFormulario = $("#NomeFormulario").val();
    var dataVencimentoInicio = $("#DataVencimentoInicio").val();
    var dataVencimentoFim = $("#DataVencimentoFim").val();
    var descricaoFormulario = $("#DescricaoFormulario").val();

    var formularioCampos = [];

    $("#table-campos tbody tr").each(function () {

        var idTipoCampo = $(this).find(".tipoCampo").data("id");
        var idTipoValorCampo = $(this).find(".tipoValorCampo").data("id");
        var descricaoCampo = $(this).find(".descricao-campo").text();
        var valorCampos = [];

        var valorCampo = "";

        if (idTipoCampo === 2) {// Valores para o Campo Combobox
            valorCampos = addValoresCombobox($(this).find(".dados-combobox"));
        } else {
            valorCampos.push(new ValorCampos($(this).find(".campo-simples").text()));
        }

        var objFormularioCampo = new FormularioCampo(idTipoCampo, idTipoValorCampo, descricaoCampo, valorCampos);

        formularioCampos.push(objFormularioCampo);
    });

    var formulario = new Formulario(nomeFormulario, dataVencimentoInicio, dataVencimentoFim, descricaoFormulario, formularioCampos);

    console.log(formulario);

    cadastrarFormulario(formulario);
}

function Formulario(nomeFormulario, dataVencimentoInicio, dataVencimentoFim, descricaoFormulario, formularioCampos) {
    this.NomeFormulario = nomeFormulario;
    this.DataVencimentoInicio = dataVencimentoInicio;
    this.DataVencimentoFim = dataVencimentoFim;
    this.DescricaoFormulario = descricaoFormulario;
    this.FormularioCampos = formularioCampos;
}

function FormularioCampo(idTipoCampo, idTipoValorCampo, descricaoCampo, valorCampos) {
    this.IdTipoCampo = idTipoCampo;
    this.IdTipovalorCampo = idTipoValorCampo;
    this.DescricaoCampo = descricaoCampo;
    this.ValorCampos = valorCampos;
}

function ValorCampos(valorCampo) {
    this.IdValorCampo = 0;
    this.ValorCampo = valorCampo;
}

function addValoresCombobox(valoresCampo) {

    var valoresCombobox = [];

    $(valoresCampo).find("label").each(function () {

        valoresCombobox.push(new ValorCampos($(this).text()));
    });

    return valoresCombobox;
}

function adiconarMaisCampos() {
    var tipoCampo = $("#idTipoCampo").find(":selected").text();
    var idTipoCampo = $("#idTipoCampo").find(":selected").val();

    var tipoValorCampo = $("#idTipoValorCampo").find(":selected").text();
    var idTipoValorCampo = $("#idTipoValorCampo").find(":selected").val();

    var html = "<tr>";
    html += "<td class='tipoCampo' data-id='" + idTipoCampo + "'>" + tipoCampo + "</td>";
    html += "<td class='tipoValorCampo' data-id='" + idTipoValorCampo + "'>" + tipoValorCampo + "</td>";

    if (tipoCampo === "Dropbox") {
        var valorCampo = removerSpan($("#addValoresCombo").html());
        html += "<td class='dados-combobox'>" + valorCampo + "</td>";
    } else {
        html += "<td class='campo-simples'>" + $("#ValorCampo").val() + "</td>";
    }

    html += "<td class='descricao-campo'>" + $("#descricaoCampo").val() + "</td>";

    html += "<td><button type='button' class='btn btn-primary excluir-linha-tabela' >Excluir</button></td>";
    html += "</tr>";

    $("#table-campos").append(html);
}

function removerLabelCombo() {
    $("#addValoresCombo").find("label").remove();
}

function removerSpan(html) {

    var isTrue = true;

    while (isTrue) {

        if (html.indexOf("</span>") >= 0) {

            html = html.replace('<span id="removerLabel">X</span>', "");
        } else {
            isTrue = false;
        }
    }

    return html;
}

function addValoresCombo() {
    var idTipoValorCampo = $("#idTipoValorCampo").find(":selected").text();
    var valorCampo = $("#ValorCampo").val();

    $("#addValoresCombo").append("<label class='label-valores-campo-combo label label-primary'>" + valorCampo + "<span id='removerLabel'>X</span></label>");

}

function esconderOuMostrar(ehEsconder, id) {
    if (ehEsconder) {
        $("#" + id).hide();
    } else {
        $("#" + id).show();
    }
}

function habilitarOuDesabilitar(ehHabilitar, id) {
    if (ehHabilitar) {
        $("#" + id).prop("disabled", false);
    } else {
        $("#" + id).prop("disabled", true);
    }
}

function verificarTipoCampoPreenchidos() {
    var todosCamposPreenchidos = true;

    var idTipoCampo = $("#idTipoCampo").find(":selected").text();
    var idTipoValorCampo = $("#idTipoValorCampo").find(":selected").text();
    var valorCampo = $("#ValorCampo").val();

    if (idTipoCampo === "-- Selecionar --") {
        todosCamposPreenchidos = false;
    }

    if (idTipoValorCampo === "-- Selecionar --") {
        todosCamposPreenchidos = false;
    }

    if (todosCamposPreenchidos) {
        habilitarOuDesabilitar(true, "adiconarMaisCampos");
    } else {
        habilitarOuDesabilitar(false, "adiconarMaisCampos");
    }
}

