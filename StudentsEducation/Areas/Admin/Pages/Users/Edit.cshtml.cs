﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsEducation.Infrastructure.Identity;
using StudentsEducation.Infrastructure.Identity.Data;

namespace StudentsEducation.Web.Areas.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly StudentsEducation.Infrastructure.Identity.AccountDbContext _context;

        public EditModel(StudentsEducation.Infrastructure.Identity.AccountDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoleExists(string id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
