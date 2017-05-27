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
    public class Purchase_JoinController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Purchase_Join
        public IQueryable<Purchase_Join> GetPurchase_Join()
        {
            return db.Purchase_Join;
        }

        // GET: api/Purchase_Join/5
        [ResponseType(typeof(Purchase_Join))]
        public async Task<IHttpActionResult> GetPurchase_Join(int id)
        {
            Purchase_Join purchase_Join = await db.Purchase_Join.FindAsync(id);
            if (purchase_Join == null)
            {
                return NotFound();
            }

            return Ok(purchase_Join);
        }

        // PUT: api/Purchase_Join/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchase_Join(int id, Purchase_Join purchase_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchase_Join.SP_ID)
            {
                return BadRequest();
            }

            db.Entry(purchase_Join).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Purchase_JoinExists(id))
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

        // POST: api/Purchase_Join
        [ResponseType(typeof(Purchase_Join))]
        public async Task<IHttpActionResult> PostPurchase_Join(Purchase_Join purchase_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Purchase_Join.Add(purchase_Join);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchase_Join.SP_ID }, purchase_Join);
        }

        // DELETE: api/Purchase_Join/5
        [ResponseType(typeof(Purchase_Join))]
        public async Task<IHttpActionResult> DeletePurchase_Join(int id)
        {
            Purchase_Join purchase_Join = await db.Purchase_Join.FindAsync(id);
            if (purchase_Join == null)
            {
                return NotFound();
            }

            db.Purchase_Join.Remove(purchase_Join);
            await db.SaveChangesAsync();

            return Ok(purchase_Join);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Purchase_JoinExists(int id)
        {
            return db.Purchase_Join.Count(e => e.SP_ID == id) > 0;
        }
    }
}