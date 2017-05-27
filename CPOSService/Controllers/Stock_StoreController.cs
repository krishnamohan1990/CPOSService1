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
    public class Stock_StoreController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Stock_Store
        public IQueryable<Stock_Store> GetStock_Store()
        {
            return db.Stock_Store;
        }

        // GET: api/Stock_Store/5
        [ResponseType(typeof(Stock_Store))]
        public async Task<IHttpActionResult> GetStock_Store(int id)
        {
            Stock_Store stock_Store = await db.Stock_Store.FindAsync(id);
            if (stock_Store == null)
            {
                return NotFound();
            }

            return Ok(stock_Store);
        }

        // PUT: api/Stock_Store/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStock_Store(int id, Stock_Store stock_Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stock_Store.St_ID)
            {
                return BadRequest();
            }

            db.Entry(stock_Store).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Stock_StoreExists(id))
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

        // POST: api/Stock_Store
        [ResponseType(typeof(Stock_Store))]
        public async Task<IHttpActionResult> PostStock_Store(Stock_Store stock_Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stock_Store.Add(stock_Store);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Stock_StoreExists(stock_Store.St_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stock_Store.St_ID }, stock_Store);
        }

        // DELETE: api/Stock_Store/5
        [ResponseType(typeof(Stock_Store))]
        public async Task<IHttpActionResult> DeleteStock_Store(int id)
        {
            Stock_Store stock_Store = await db.Stock_Store.FindAsync(id);
            if (stock_Store == null)
            {
                return NotFound();
            }

            db.Stock_Store.Remove(stock_Store);
            await db.SaveChangesAsync();

            return Ok(stock_Store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Stock_StoreExists(int id)
        {
            return db.Stock_Store.Count(e => e.St_ID == id) > 0;
        }
    }
}