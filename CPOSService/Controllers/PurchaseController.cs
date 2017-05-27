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
    public class PurchaseController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Purchase
        public IQueryable<Purchase> GetPurchases()
        {
            return db.Purchases;
        }

        // GET: api/Purchase/5
        [ResponseType(typeof(Purchase))]
        public async Task<IHttpActionResult> GetPurchase(int id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        // PUT: api/Purchase/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchase.ST_ID)
            {
                return BadRequest();
            }

            db.Entry(purchase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchase
        [ResponseType(typeof(Purchase))]
        public async Task<IHttpActionResult> PostPurchase(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Purchases.Add(purchase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseExists(purchase.ST_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = purchase.ST_ID }, purchase);
        }

        // DELETE: api/Purchase/5
        [ResponseType(typeof(Purchase))]
        public async Task<IHttpActionResult> DeletePurchase(int id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            db.Purchases.Remove(purchase);
            await db.SaveChangesAsync();

            return Ok(purchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseExists(int id)
        {
            return db.Purchases.Count(e => e.ST_ID == id) > 0;
        }
    }
}