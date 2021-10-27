using DesafioAgendaContato.Models;
using DesafioAgendaContato.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAgendaContato.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Contato> Contatos { get; set; }
        private readonly IContatoRepository _rep;

        public IndexModel(ILogger<IndexModel> logger, IContatoRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public void OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Contatos = _rep.Listar();

        }
    }
}
