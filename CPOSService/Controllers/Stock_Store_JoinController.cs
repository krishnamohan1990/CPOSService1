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
    public class Stock_Store_JoinController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Stock_Store_Join
        public IQueryable<Stock_Store_Join> GetStock_Store_Join()
        {
            return db.Stock_Store_Join;
        }

        // GET: api/Stock_Store_Join/5
        [ResponseType(typeof(Stock_Store_Join))]
        public async Task<IHttpActionResult> GetStock_Store_Join(int id)
        {
            Stock_Store_Join stock_Store_Join = await db.Stock_Store_Join.FindAsync(id);
            if (stock_Store_Join == null)
            {
                return NotFound();
            }

            return Ok(stock_Store_Join);
        }

        // PUT: api/Stock_Store_Join/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStock_Store_Join(int id, Stock_Store_Join stock_Store_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stock_Store_Join.SSJ_ID)
            {
                return BadRequest();
            }

            db.Entry(stock_Store_Join).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stock_Store_JoinExists(id))
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

        // POST: api/Stock_Store_Join
        [ResponseType(typeof(Stock_Store_Join))]
        public async Task<IHttpActionResult> PostStock_Store_Join(Stock_Store_Join stock_Store_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stock_Store_Join.Add(stock_Store_Join);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stock_Store_Join.SSJ_ID }, stock_Store_Join);
        }

        // DELETE: api/Stock_Store_Join/5
        [ResponseType(typeof(Stock_Store_Join))]
        public async Task<IHttpActionResult> DeleteStock_Store_Join(int id)
        {
            Stock_Store_Join stock_Store_Join = await db.Stock_Store_Join.FindAsync(id);
            if (stock_Store_Join == null)
            {
                return NotFound();
            }

            db.Stock_Store_Join.Remove(stock_Store_Join);
            await db.SaveChangesAsync();

            return Ok(stock_Store_Join);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Stock_Store_JoinExists(int id)
        {
            return db.Stock_Store_Join.Count(e => e.SSJ_ID == id) > 0;
        }
    }
}