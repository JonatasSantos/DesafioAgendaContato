// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$("#cadastrar").on("click", validarCampos);
const api = "https://localhost:44303/api/contato/persistir";

function Post(yourUrl, dados) {
    var Httpreq = new XMLHttpRequest(); // a new request
    Httpreq.open("POST", yourUrl, false);
    Httpreq.setRequestHeader("Content-Type", "application/json");
    Httpreq.send(dados);
    return Httpreq.responseText;
}


//let contatoJson = JSON.parse(contato);

function salvarContato() {

    let contato = {
        'Nome': document.getElementById("nome").value,
        'Telefone': document.getElementById("telefone").value,
        'Email': document.getElementById("email").value
    };
    //alert(contato.nome);
    var result = Post(api, JSON.stringify(contato));
}
