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
    public class Product_OpeningStockController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Product_OpeningStock
        public IQueryable<Product_OpeningStock> GetProduct_OpeningStock()
        {
            return db.Product_OpeningStock;
        }

        // GET: api/Product_OpeningStock/5
        [ResponseType(typeof(Product_OpeningStock))]
        public async Task<IHttpActionResult> GetProduct_OpeningStock(int id)
        {
            Product_OpeningStock product_OpeningStock = await db.Product_OpeningStock.FindAsync(id);
            if (product_OpeningStock == null)
            {
                return NotFound();
            }

            return Ok(product_OpeningStock);
        }

        // PUT: api/Product_OpeningStock/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct_OpeningStock(int id, Product_OpeningStock product_OpeningStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_OpeningStock.PS_ID)
            {
                return BadRequest();
            }

            db.Entry(product_OpeningStock).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_OpeningStockExists(id))
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

        // POST: api/Product_OpeningStock
        [ResponseType(typeof(Product_OpeningStock))]
        public async Task<IHttpActionResult> PostProduct_OpeningStock(Product_OpeningStock product_OpeningStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product_OpeningStock.Add(product_OpeningStock);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product_OpeningStock.PS_ID }, product_OpeningStock);
        }

        // DELETE: api/Product_OpeningStock/5
        [ResponseType(typeof(Product_OpeningStock))]
        public async Task<IHttpActionResult> DeleteProduct_OpeningStock(int id)
        {
            Product_OpeningStock product_OpeningStock = await db.Product_OpeningStock.FindAsync(id);
            if (product_OpeningStock == null)
            {
                return NotFound();
            }

            db.Product_OpeningStock.Remove(product_OpeningStock);
            await db.SaveChangesAsync();

            return Ok(product_OpeningStock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product_OpeningStockExists(int id)
        {
            return db.Product_OpeningStock.Count(e => e.PS_ID == id) > 0;
        }
    }
}