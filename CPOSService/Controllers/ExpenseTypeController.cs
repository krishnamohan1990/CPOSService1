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
    public class ExpenseTypeController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/ExpenseType
        public IQueryable<ExpenseType> GetExpenseTypes()
        {
            return db.ExpenseTypes;
        }

        // GET: api/ExpenseType/5
        [ResponseType(typeof(ExpenseType))]
        public async Task<IHttpActionResult> GetExpenseType(string id)
        {
            ExpenseType expenseType = await db.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }

            return Ok(expenseType);
        }

        // PUT: api/ExpenseType/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExpenseType(string id, ExpenseType expenseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenseType.Type)
            {
                return BadRequest();
            }

            db.Entry(expenseType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseTypeExists(id))
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

        // POST: api/ExpenseType
        [ResponseType(typeof(ExpenseType))]
        public async Task<IHttpActionResult> PostExpenseType(ExpenseType expenseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseTypes.Add(expenseType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExpenseTypeExists(expenseType.Type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = expenseType.Type }, expenseType);
        }

        // DELETE: api/ExpenseType/5
        [ResponseType(typeof(ExpenseType))]
        public async Task<IHttpActionResult> DeleteExpenseType(string id)
        {
            ExpenseType expenseType = await db.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }

            db.ExpenseTypes.Remove(expenseType);
            await db.SaveChangesAsync();

            return Ok(expenseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseTypeExists(string id)
        {
            return db.ExpenseTypes.Count(e => e.Type == id) > 0;
        }
    }
}