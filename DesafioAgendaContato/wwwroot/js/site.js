// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$("#cadastrar").on("click", validarCampos);

//var uri = 'api/contato/listar';
//let todos = [];

function Get(yourUrl) {
    var Httpreq = new XMLHttpRequest(); // a new request
    Httpreq.open("GET", yourUrl, false);
    Httpreq.send(null);
    return Httpreq.responseText;
}
var acao = Get("https://localhost:44303/api/contato/listar");
var todosContatos = JSON.parse(acao);

window.onload = function () {

    if (document.URL == "https://localhost:44381/") {
        todosContatos.forEach((item) => {
            document.getElementById("id").innerHTML = item.id;
            document.getElementById("nome").innerHTML = item.nome;
            document.getElementById("telefone").innerHTML = item.telefone;
            document.getElementById("email").innerHTML = item.email;
            document.getElementById("editar").value = item.id;
        })

        var btnEditar = document.getElementById("editar");
        btnEditar.setAttribute("href", "Edit?id=" + btnEditar.value);
    } else if (document.URL.includes("Edit")) {
        var contatoID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
        acao = Get("https://localhost:44303/api/contato/selecionar/" + contatoID);
        let data = JSON.parse(acao);
        console.log(data);
        document.getElementById("nome").value = data.nome;
        document.getElementById("telefone").value = data.telefone;
        document.getElementById("email").value = data.email;
        console.log(contatoID);
        let contato = {
            id: contatoID,
            nome: document.getElementById("nome").value,
            telefone: document.getElementById("telefone").value,
            email: document.getElementById("email").value
        };
        console.log(contato);
    }
    
}


