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
    public class TempRestaurantPOS_OrderedProductKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/TempRestaurantPOS_OrderedProductKOT
        public IQueryable<TempRestaurantPOS_OrderedProductKOT> GetTempRestaurantPOS_OrderedProductKOT()
        {
            return db.TempRestaurantPOS_OrderedProductKOT;
        }

        // GET: api/TempRestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(TempRestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> GetTempRestaurantPOS_OrderedProductKOT(int id)
        {
            TempRestaurantPOS_OrderedProductKOT tempRestaurantPOS_OrderedProductKOT = await db.TempRestaurantPOS_OrderedProductKOT.FindAsync(id);
            if (tempRestaurantPOS_OrderedProductKOT == null)
            {
                return NotFound();
            }

            return Ok(tempRestaurantPOS_OrderedProductKOT);
        }

        // PUT: api/TempRestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTempRestaurantPOS_OrderedProductKOT(int id, TempRestaurantPOS_OrderedProductKOT tempRestaurantPOS_OrderedProductKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tempRestaurantPOS_OrderedProductKOT.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(tempRestaurantPOS_OrderedProductKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempRestaurantPOS_OrderedProductKOTExists(id))
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

        // POST: api/TempRestaurantPOS_OrderedProductKOT
        [ResponseType(typeof(TempRestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> PostTempRestaurantPOS_OrderedProductKOT(TempRestaurantPOS_OrderedProductKOT tempRestaurantPOS_OrderedProductKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TempRestaurantPOS_OrderedProductKOT.Add(tempRestaurantPOS_OrderedProductKOT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tempRestaurantPOS_OrderedProductKOT.OP_ID }, tempRestaurantPOS_OrderedProductKOT);
        }

        // DELETE: api/TempRestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(TempRestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> DeleteTempRestaurantPOS_OrderedProductKOT(int id)
        {
            TempRestaurantPOS_OrderedProductKOT tempRestaurantPOS_OrderedProductKOT = await db.TempRestaurantPOS_OrderedProductKOT.FindAsync(id);
            if (tempRestaurantPOS_OrderedProductKOT == null)
            {
                return NotFound();
            }

            db.TempRestaurantPOS_OrderedProductKOT.Remove(tempRestaurantPOS_OrderedProductKOT);
            await db.SaveChangesAsync();

            return Ok(tempRestaurantPOS_OrderedProductKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TempRestaurantPOS_OrderedProductKOTExists(int id)
        {
            return db.TempRestaurantPOS_OrderedProductKOT.Count(e => e.OP_ID == id) > 0;
        }
    }
}