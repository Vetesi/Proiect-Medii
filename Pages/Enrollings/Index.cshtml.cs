﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cursuri.Data;
using Cursuri.Models;

namespace Cursuri.Pages.Enrollings
{
    public class IndexModel : PageModel
    {
        private readonly Cursuri.Data.CursuriContext _context;

        public IndexModel(Cursuri.Data.CursuriContext context)
        {
            _context = context;
        }

        public IList<Enrolling> Enrolling { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Enrolling != null)
            {
                Enrolling = await _context.Enrolling
                .Include(e => e.Course)
                .Include(e => e.Member).ToListAsync();
            }
        }
    }
}
