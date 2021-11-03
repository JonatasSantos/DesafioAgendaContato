using DesafioAgendaContato.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAgendaContato.Repository
{
    public interface IContatoRepository
    {
        Contato Selecionar(string id);
        Task<List<Contato>> Listar();
        void Persistir(Contato contato);
        void Atualizar(Contato contato);
        void Excluir(string id);

    }
}
