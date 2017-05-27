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
    public class RestaurantPOS_OrderedProductBillEBController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderedProductBillEB
        public IQueryable<RestaurantPOS_OrderedProductBillEB> GetRestaurantPOS_OrderedProductBillEB()
        {
            return db.RestaurantPOS_OrderedProductBillEB;
        }

        // GET: api/RestaurantPOS_OrderedProductBillEB/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillEB))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderedProductBillEB(int id)
        {
            RestaurantPOS_OrderedProductBillEB restaurantPOS_OrderedProductBillEB = await db.RestaurantPOS_OrderedProductBillEB.FindAsync(id);
            if (restaurantPOS_OrderedProductBillEB == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderedProductBillEB);
        }

        // PUT: api/RestaurantPOS_OrderedProductBillEB/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderedProductBillEB(int id, RestaurantPOS_OrderedProductBillEB restaurantPOS_OrderedProductBillEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderedProductBillEB.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderedProductBillEB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderedProductBillEBExists(id))
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

        // POST: api/RestaurantPOS_OrderedProductBillEB
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillEB))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderedProductBillEB(RestaurantPOS_OrderedProductBillEB restaurantPOS_OrderedProductBillEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderedProductBillEB.Add(restaurantPOS_OrderedProductBillEB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderedProductBillEB.OP_ID }, restaurantPOS_OrderedProductBillEB);
        }

        // DELETE: api/RestaurantPOS_OrderedProductBillEB/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillEB))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderedProductBillEB(int id)
        {
            RestaurantPOS_OrderedProductBillEB restaurantPOS_OrderedProductBillEB = await db.RestaurantPOS_OrderedProductBillEB.FindAsync(id);
            if (restaurantPOS_OrderedProductBillEB == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderedProductBillEB.Remove(restaurantPOS_OrderedProductBillEB);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderedProductBillEB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderedProductBillEBExists(int id)
        {
            return db.RestaurantPOS_OrderedProductBillEB.Count(e => e.OP_ID == id) > 0;
        }
    }
}