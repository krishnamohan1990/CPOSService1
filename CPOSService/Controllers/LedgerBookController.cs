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
    public class LedgerBookController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/LedgerBook
        public IQueryable<LedgerBook> GetLedgerBooks()
        {
            return db.LedgerBooks;
        }

        // GET: api/LedgerBook/5
        [ResponseType(typeof(LedgerBook))]
        public async Task<IHttpActionResult> GetLedgerBook(int id)
        {
            LedgerBook ledgerBook = await db.LedgerBooks.FindAsync(id);
            if (ledgerBook == null)
            {
                return NotFound();
            }

            return Ok(ledgerBook);
        }

        // PUT: api/LedgerBook/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLedgerBook(int id, LedgerBook ledgerBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ledgerBook.Id)
            {
                return BadRequest();
            }

            db.Entry(ledgerBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerBookExists(id))
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

        // POST: api/LedgerBook
        [ResponseType(typeof(LedgerBook))]
        public async Task<IHttpActionResult> PostLedgerBook(LedgerBook ledgerBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LedgerBooks.Add(ledgerBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ledgerBook.Id }, ledgerBook);
        }

        // DELETE: api/LedgerBook/5
        [ResponseType(typeof(LedgerBook))]
        public async Task<IHttpActionResult> DeleteLedgerBook(int id)
        {
            LedgerBook ledgerBook = await db.LedgerBooks.FindAsync(id);
            if (ledgerBook == null)
            {
                return NotFound();
            }

            db.LedgerBooks.Remove(ledgerBook);
            await db.SaveChangesAsync();

            return Ok(ledgerBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LedgerBookExists(int id)
        {
            return db.LedgerBooks.Count(e => e.Id == id) > 0;
        }
    }
}