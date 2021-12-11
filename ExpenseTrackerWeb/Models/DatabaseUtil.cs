using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerWeb.Models
{
    public class DatabaseUtil
    {


        ExpenseDbContext database = new ExpenseDbContext();
        public IEnumerable<ExpenseReport> GetAllExpenses()
        {
            try
            {
                return database.ExpenseReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Expense record       
        public void AddExpense(ExpenseReport expense)
        {
            try
            {
                database.ExpenseReport.Add(expense);
                database.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar expense  
        public int UpdateExpense(ExpenseReport expense)
        {
            try
            {
                database.Entry(expense).State = EntityState.Modified;
                database.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular expense  
        public ExpenseReport GetExpenseData(int id)
        {
            try
            {
                ExpenseReport expense = database.ExpenseReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular expense  
        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseReport emp = database.ExpenseReport.Find(id);
                database.ExpenseReport.Remove(emp);
                database.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
