using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HelpLocally.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HelpLocallyContext _context;

        //public ICollection<Company> Companies
    }
}
