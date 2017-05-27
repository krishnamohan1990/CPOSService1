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
    public class CurrencyController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Currency
        public IQueryable<Currency> GetCurrencies()
        {
            return db.Currencies;
        }

        // GET: api/Currency/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> GetCurrency(string id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currency/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurrency(string id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.CurrencyCode)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currency
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.CurrencyCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = currency.CurrencyCode }, currency);
        }

        // DELETE: api/Currency/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> DeleteCurrency(string id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            await db.SaveChangesAsync();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(string id)
        {
            return db.Currencies.Count(e => e.CurrencyCode == id) > 0;
        }
    }
}