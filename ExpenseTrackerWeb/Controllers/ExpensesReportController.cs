using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerWeb.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace ExpenseTrackerWeb.Controllers
{
    public class ExpensesReportController : Controller
    {
        private readonly ExpenseContext _context;

        public ExpensesReportController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: ExpensesReport
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseReports.ToListAsync());
        }


        public async Task<IActionResult> Charts() {

            return View();
        }

        // GET: ExpensesReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.ExpenseReports
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (expenseReport == null)
            {
                return NotFound();
            }

            return View(expenseReport);
        }

        // GET: ExpensesReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpensesReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Amount,ExpenseDate,Category")] ExpenseReport expenseReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseReport);
        }

        // method to get values for charts


       [HttpPost]
        public JsonResult ReportCount()
        {
            try
            {

                string[] ReportCount = new string[100];

                SqlConnection con = new SqlConnection("Server=(localdb)\\projectsv13;Database=ExpensesReportDB;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security = true;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(itemID) as food , (select count(itemID) from ExpenseReports where Category = 'drinks') as drinks from ExpenseReports where Category = 'food';", con);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    ReportCount[0] = "0";
                    ReportCount[1] = "0";
                    

                }
                else
                {

                    ReportCount[0] = table.Rows[0]["drinks"].ToString();
                    ReportCount[1] = table.Rows[0]["food"].ToString();

                  
                }
                return Json(new { ReportCount }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }



            catch (Exception ex)
            {

                throw ex;
             
            }
        }

        // GET: ExpensesReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.ExpenseReports.FindAsync(id);
            if (expenseReport == null)
            {
                return NotFound();
            }
            return View(expenseReport);
        }

        // POST: ExpensesReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Amount,ExpenseDate,Category")] ExpenseReport expenseReport)
        {
            if (id != expenseReport.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseReportExists(expenseReport.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expenseReport);
        }

        // GET: ExpensesReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.ExpenseReports
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (expenseReport == null)
            {
                return NotFound();
            }

            return View(expenseReport);
        }

        // POST: ExpensesReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseReport = await _context.ExpenseReports.FindAsync(id);
            _context.ExpenseReports.Remove(expenseReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseReportExists(int id)
        {
            return _context.ExpenseReports.Any(e => e.ItemId == id);
        }
    }

   
}
