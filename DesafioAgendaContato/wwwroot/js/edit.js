// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$("#cadastrar").on("click", validarCampos);
const api = "https://localhost:44303/api/contato/atualizar/";
var acao = "atualizar/";

function Put(yourUrl, dados) {
    var Httpreq = new XMLHttpRequest(); // a new request
    Httpreq.open("PUT", yourUrl, false);
    Httpreq.setRequestHeader("Content-Type", "application/json");
    Httpreq.send(dados);
    return Httpreq.responseText;
}


//let contatoJson = JSON.parse(contato);

function atualizarContato() {

    var contatoID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
    console.log(contatoID);
    let contato = {
        'Id': contatoID,
        'Nome': document.getElementById("nome").value,
        'Telefone': document.getElementById("telefone").value,
        'Email': document.getElementById("email").value
    };
    //alert(contato.nome);
    var result = Put(api + contatoID, contato);
    alert(result);
}
