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

function Put(yourUrl, dados) {
    var Httpreq = new XMLHttpRequest(); // a new request
    Httpreq.open("POST", yourUrl, false);
    Httpreq.setRequestHeader("Content-Type", "application/json");
    Httpreq.send(dados);
    return Httpreq.responseText;
}

var acao = Get("https://localhost:44303/api/contato/listar");
var todosContatos = JSON.parse(acao);
var contatos = [];
window.onload = function () {

    if (document.URL == "https://localhost:44381/") {
        exibirContatos();
    } else if (document.URL.includes("Edit")) {
        var contatoID = document.URL.substring(document.URL.indexOf("=") + 1, document.URL.length);
        console.log("ok");
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

function exibirContatos() {
    var tBody = document.getElementById('contatos');
    tBody.innerHTML = '';

    var btn = document.createElement('button');

    todosContatos.forEach((item) => {
        var tr = tBody.insertRow();

        var tdID = tr.insertCell(0);
        tdID.innerHTML = item.id;

        var tdNome = tr.insertCell(1);
        tdNome.innerText = item.nome;

        var tdTelefone = tr.insertCell(2);
        tdTelefone.innerText = item.telefone;

        var tdEmail = tr.insertCell(3);
        tdEmail.innerText = item.email;
        var id = item.id.toString();
        var btnEditar = btn.cloneNode(false);
        btnEditar.innerText = 'Editar';
        btnEditar.setAttribute('onclick', 'editar("' + item.id + '");');
        var btnDeletar = btn.cloneNode(false);
        btnDeletar.innerText = 'Deletar';
        btnDeletar.setAttribute('onclick', `deleteItem(${item.id});`);

        var tdEditar = tr.insertCell(4);
        tdEditar.appendChild(btnEditar);

        var tdDeletar = tr.insertCell(5);
        tdDeletar.appendChild(btnDeletar);
    })

    
}

function editar(id) {
    
    var item = contatos.find(item => item.id === id);

    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-nome').value = item.nome;
    document.getElementById('edit-telefone').value = item.telefone;
    document.getElementById('edit-email').value = item.email;
    document.getElementById('editForm').style.display = 'block';

}

function atualizarContato() {
    var id = document.getElementById('edit-id').value;
    var contato = {
        Id: id,
        Nome: document.getElementById('edit-nome').value,
        Telefone: document.getElementById('edit-telefone').value,
        Email: document.getElementById('edit-email').value
    };

    var result = Put("https://localhost:44303/api/contato/atualizar", JSON.stringify(contato));
    
    closeInput();
    exibirContatos();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


contatos = todosContatos;