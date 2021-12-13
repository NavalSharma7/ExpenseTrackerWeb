using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerWeb.Models
{
    public class ExpenseContext:DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options):base(options) {
        
        
        
        }

        public DbSet<ExpenseReport> ExpenseReports { get; set; }

    }
}
