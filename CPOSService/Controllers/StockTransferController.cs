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
    public class StockTransferController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/StockTransfer
        public IQueryable<StockTransfer> GetStockTransfers()
        {
            return db.StockTransfers;
        }

        // GET: api/StockTransfer/5
        [ResponseType(typeof(StockTransfer))]
        public async Task<IHttpActionResult> GetStockTransfer(int id)
        {
            StockTransfer stockTransfer = await db.StockTransfers.FindAsync(id);
            if (stockTransfer == null)
            {
                return NotFound();
            }

            return Ok(stockTransfer);
        }

        // PUT: api/StockTransfer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStockTransfer(int id, StockTransfer stockTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockTransfer.ST_ID)
            {
                return BadRequest();
            }

            db.Entry(stockTransfer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTransferExists(id))
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

        // POST: api/StockTransfer
        [ResponseType(typeof(StockTransfer))]
        public async Task<IHttpActionResult> PostStockTransfer(StockTransfer stockTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockTransfers.Add(stockTransfer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockTransferExists(stockTransfer.ST_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stockTransfer.ST_ID }, stockTransfer);
        }

        // DELETE: api/StockTransfer/5
        [ResponseType(typeof(StockTransfer))]
        public async Task<IHttpActionResult> DeleteStockTransfer(int id)
        {
            StockTransfer stockTransfer = await db.StockTransfers.FindAsync(id);
            if (stockTransfer == null)
            {
                return NotFound();
            }

            db.StockTransfers.Remove(stockTransfer);
            await db.SaveChangesAsync();

            return Ok(stockTransfer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockTransferExists(int id)
        {
            return db.StockTransfers.Count(e => e.ST_ID == id) > 0;
        }
    }
}