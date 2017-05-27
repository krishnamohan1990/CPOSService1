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
    public class TempRestaurantPOS_OrderInfoKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/TempRestaurantPOS_OrderInfoKOT
        public IQueryable<TempRestaurantPOS_OrderInfoKOT> GetTempRestaurantPOS_OrderInfoKOT()
        {
            return db.TempRestaurantPOS_OrderInfoKOT;
        }

        // GET: api/TempRestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(TempRestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> GetTempRestaurantPOS_OrderInfoKOT(int id)
        {
            TempRestaurantPOS_OrderInfoKOT tempRestaurantPOS_OrderInfoKOT = await db.TempRestaurantPOS_OrderInfoKOT.FindAsync(id);
            if (tempRestaurantPOS_OrderInfoKOT == null)
            {
                return NotFound();
            }

            return Ok(tempRestaurantPOS_OrderInfoKOT);
        }

        // PUT: api/TempRestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTempRestaurantPOS_OrderInfoKOT(int id, TempRestaurantPOS_OrderInfoKOT tempRestaurantPOS_OrderInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tempRestaurantPOS_OrderInfoKOT.Id)
            {
                return BadRequest();
            }

            db.Entry(tempRestaurantPOS_OrderInfoKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempRestaurantPOS_OrderInfoKOTExists(id))
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

        // POST: api/TempRestaurantPOS_OrderInfoKOT
        [ResponseType(typeof(TempRestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> PostTempRestaurantPOS_OrderInfoKOT(TempRestaurantPOS_OrderInfoKOT tempRestaurantPOS_OrderInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TempRestaurantPOS_OrderInfoKOT.Add(tempRestaurantPOS_OrderInfoKOT);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TempRestaurantPOS_OrderInfoKOTExists(tempRestaurantPOS_OrderInfoKOT.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tempRestaurantPOS_OrderInfoKOT.Id }, tempRestaurantPOS_OrderInfoKOT);
        }

        // DELETE: api/TempRestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(TempRestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> DeleteTempRestaurantPOS_OrderInfoKOT(int id)
        {
            TempRestaurantPOS_OrderInfoKOT tempRestaurantPOS_OrderInfoKOT = await db.TempRestaurantPOS_OrderInfoKOT.FindAsync(id);
            if (tempRestaurantPOS_OrderInfoKOT == null)
            {
                return NotFound();
            }

            db.TempRestaurantPOS_OrderInfoKOT.Remove(tempRestaurantPOS_OrderInfoKOT);
            await db.SaveChangesAsync();

            return Ok(tempRestaurantPOS_OrderInfoKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TempRestaurantPOS_OrderInfoKOTExists(int id)
        {
            return db.TempRestaurantPOS_OrderInfoKOT.Count(e => e.Id == id) > 0;
        }
    }
}