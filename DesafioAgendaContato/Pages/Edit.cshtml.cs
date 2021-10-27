using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAgendaContato.Models;
using DesafioAgendaContato.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DesafioAgendaContato.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        [BindProperty]
        public Contato contato { get; set; }

        private readonly IContatoRepository _rep;

        public string Mensagem { get; set; }

        public EditModel(ILogger<EditModel> logger, IContatoRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet(string id)
        {
            contato = _rep.Selecionar(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _rep.Atualizar(contato);

                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = ex.Message;
            }
            return Page();
        }
    }
}
