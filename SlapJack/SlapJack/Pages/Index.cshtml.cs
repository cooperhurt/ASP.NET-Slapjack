﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SlapJack.Pages
{
    public class IndexModel : PageModel
    {
        public IList<string> Scales { get; set; }

        public void OnGet()
        {

        }
    }
}
