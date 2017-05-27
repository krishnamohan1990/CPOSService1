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
    public class Temp_StockController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Temp_Stock
        public IQueryable<Temp_Stock> GetTemp_Stock()
        {
            return db.Temp_Stock;
        }

        // GET: api/Temp_Stock/5
        [ResponseType(typeof(Temp_Stock))]
        public async Task<IHttpActionResult> GetTemp_Stock(int id)
        {
            Temp_Stock temp_Stock = await db.Temp_Stock.FindAsync(id);
            if (temp_Stock == null)
            {
                return NotFound();
            }

            return Ok(temp_Stock);
        }

        // PUT: api/Temp_Stock/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemp_Stock(int id, Temp_Stock temp_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temp_Stock.Id)
            {
                return BadRequest();
            }

            db.Entry(temp_Stock).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Temp_StockExists(id))
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

        // POST: api/Temp_Stock
        [ResponseType(typeof(Temp_Stock))]
        public async Task<IHttpActionResult> PostTemp_Stock(Temp_Stock temp_Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Temp_Stock.Add(temp_Stock);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = temp_Stock.Id }, temp_Stock);
        }

        // DELETE: api/Temp_Stock/5
        [ResponseType(typeof(Temp_Stock))]
        public async Task<IHttpActionResult> DeleteTemp_Stock(int id)
        {
            Temp_Stock temp_Stock = await db.Temp_Stock.FindAsync(id);
            if (temp_Stock == null)
            {
                return NotFound();
            }

            db.Temp_Stock.Remove(temp_Stock);
            await db.SaveChangesAsync();

            return Ok(temp_Stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Temp_StockExists(int id)
        {
            return db.Temp_Stock.Count(e => e.Id == id) > 0;
        }
    }
}