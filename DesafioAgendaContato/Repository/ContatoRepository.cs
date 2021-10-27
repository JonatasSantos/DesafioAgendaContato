using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DesafioAgendaContato.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DesafioAgendaContato.Repository
{
    public interface IContatoRepository
    {
        Contato Selecionar(string id);
        IEnumerable<Contato> Listar();
        void Persistir(Contato contato);
        void Atualizar(Contato contato);
        void Excluir(string id);

    }

    public class ContatoRepository : IContatoRepository
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("mysqldb"); } }

        public ContatoRepository(IConfiguration config)
        {
            _configuracoes = config;
        }

        public Contato Selecionar(string id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Contato>("SELECT Id, Nome, Telefone, Email FROM Contato WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Contato> Listar()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Contato>("SELECT Id, Nome, Telefone, Email FROM Contato");
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
