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
    public class SupplierLedgerBookController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/SupplierLedgerBook
        public IQueryable<SupplierLedgerBook> GetSupplierLedgerBooks()
        {
            return db.SupplierLedgerBooks;
        }

        // GET: api/SupplierLedgerBook/5
        [ResponseType(typeof(SupplierLedgerBook))]
        public async Task<IHttpActionResult> GetSupplierLedgerBook(int id)
        {
            SupplierLedgerBook supplierLedgerBook = await db.SupplierLedgerBooks.FindAsync(id);
            if (supplierLedgerBook == null)
            {
                return NotFound();
            }

            return Ok(supplierLedgerBook);
        }

        // PUT: api/SupplierLedgerBook/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplierLedgerBook(int id, SupplierLedgerBook supplierLedgerBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplierLedgerBook.Id)
            {
                return BadRequest();
            }

            db.Entry(supplierLedgerBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierLedgerBookExists(id))
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

        // POST: api/SupplierLedgerBook
        [ResponseType(typeof(SupplierLedgerBook))]
        public async Task<IHttpActionResult> PostSupplierLedgerBook(SupplierLedgerBook supplierLedgerBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SupplierLedgerBooks.Add(supplierLedgerBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = supplierLedgerBook.Id }, supplierLedgerBook);
        }

        // DELETE: api/SupplierLedgerBook/5
        [ResponseType(typeof(SupplierLedgerBook))]
        public async Task<IHttpActionResult> DeleteSupplierLedgerBook(int id)
        {
            SupplierLedgerBook supplierLedgerBook = await db.SupplierLedgerBooks.FindAsync(id);
            if (supplierLedgerBook == null)
            {
                return NotFound();
            }

            db.SupplierLedgerBooks.Remove(supplierLedgerBook);
            await db.SaveChangesAsync();

            return Ok(supplierLedgerBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierLedgerBookExists(int id)
        {
            return db.SupplierLedgerBooks.Count(e => e.Id == id) > 0;
        }
    }
}