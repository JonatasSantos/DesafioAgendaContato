using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DesafioAgendaContato.Domain;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DesafioAgendaContato.Repository
{

    public class ContatoRepository : IContatoRepository
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("mysqldb"); } }
        public HttpClient client = new HttpClient();
        public ContatoRepository(IConfiguration config)
        {
            _configuracoes = config;
            client.BaseAddress = new Uri("https://localhost:44303/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public Contato Selecionar(string id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Contato>("SELECT Id, Nome, Telefone, Email FROM Contato WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public async Task<List<Contato>> Listar()
        {
            HttpResponseMessage response = await client.GetAsync("api/contato/listar");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                List<Contato> listinha = JsonConvert.DeserializeObject<List<Contato>>(dados);
                return listinha;
            }
            else
            {
                return new List<Contato>();
            }
            
        }

        public void Persistir(Contato contato)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("INSERT INTO Contato VALUES (@Id, @Nome, @Telefone, @Email)", new
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Email = contato.Email
                });
            }
        }

        public void Atualizar(Contato contato)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("UPDATE Contato SET Nome = @Nome, Telefone = @Telefone, Email = @Email WHERE Id = @Id", new
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Email = contato.Email
                });
            }
        }

        public void Excluir(string id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("DELETE FROM Contato WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }
    }
}
