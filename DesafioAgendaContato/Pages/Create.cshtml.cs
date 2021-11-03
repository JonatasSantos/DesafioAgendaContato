using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAgendaContato.Domain;
using DesafioAgendaContato.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DesafioAgendaContato.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Contato contato { get; set; }

        private readonly IContatoRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IContatoRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            try
            {
                //_rep.Persistir(contato);
                return Page();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
