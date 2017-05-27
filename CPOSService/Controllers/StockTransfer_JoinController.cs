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
    public class StockTransfer_JoinController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/StockTransfer_Join
        public IQueryable<StockTransfer_Join> GetStockTransfer_Join()
        {
            return db.StockTransfer_Join;
        }

        // GET: api/StockTransfer_Join/5
        [ResponseType(typeof(StockTransfer_Join))]
        public async Task<IHttpActionResult> GetStockTransfer_Join(int id)
        {
            StockTransfer_Join stockTransfer_Join = await db.StockTransfer_Join.FindAsync(id);
            if (stockTransfer_Join == null)
            {
                return NotFound();
            }

            return Ok(stockTransfer_Join);
        }

        // PUT: api/StockTransfer_Join/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStockTransfer_Join(int id, StockTransfer_Join stockTransfer_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockTransfer_Join.STJ_ID)
            {
                return BadRequest();
            }

            db.Entry(stockTransfer_Join).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTransfer_JoinExists(id))
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

        // POST: api/StockTransfer_Join
        [ResponseType(typeof(StockTransfer_Join))]
        public async Task<IHttpActionResult> PostStockTransfer_Join(StockTransfer_Join stockTransfer_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockTransfer_Join.Add(stockTransfer_Join);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stockTransfer_Join.STJ_ID }, stockTransfer_Join);
        }

        // DELETE: api/StockTransfer_Join/5
        [ResponseType(typeof(StockTransfer_Join))]
        public async Task<IHttpActionResult> DeleteStockTransfer_Join(int id)
        {
            StockTransfer_Join stockTransfer_Join = await db.StockTransfer_Join.FindAsync(id);
            if (stockTransfer_Join == null)
            {
                return NotFound();
            }

            db.StockTransfer_Join.Remove(stockTransfer_Join);
            await db.SaveChangesAsync();

            return Ok(stockTransfer_Join);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockTransfer_JoinExists(int id)
        {
            return db.StockTransfer_Join.Count(e => e.STJ_ID == id) > 0;
        }
    }
}