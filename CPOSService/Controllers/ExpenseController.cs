using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CPOSLibrary;

namespace CPOSService.Controllers
{
    public class ExpenseController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Expense
        public IQueryable<Expense> GetExpenses()
        {
            return db.Expenses;
        }

        // GET: api/Expense/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> GetExpense(string id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expense/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExpense(string id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.ExpenseName)
            {
                return BadRequest();
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expense
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expenses.Add(expense);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExpenseExists(expense.ExpenseName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = expense.ExpenseName }, expense);
        }

        // DELETE: api/Expense/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> DeleteExpense(string id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expenses.Remove(expense);
            await db.SaveChangesAsync();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(string id)
        {
            return db.Expenses.Count(e => e.ExpenseName == id) > 0;
        }
    }
}