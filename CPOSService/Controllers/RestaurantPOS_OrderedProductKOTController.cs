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
    public class RestaurantPOS_OrderedProductKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderedProductKOT
        public IQueryable<RestaurantPOS_OrderedProductKOT> GetRestaurantPOS_OrderedProductKOT()
        {
            return db.RestaurantPOS_OrderedProductKOT;
        }

        // GET: api/RestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderedProductKOT(int id)
        {
            RestaurantPOS_OrderedProductKOT restaurantPOS_OrderedProductKOT = await db.RestaurantPOS_OrderedProductKOT.FindAsync(id);
            if (restaurantPOS_OrderedProductKOT == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderedProductKOT);
        }

        // PUT: api/RestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderedProductKOT(int id, RestaurantPOS_OrderedProductKOT restaurantPOS_OrderedProductKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderedProductKOT.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderedProductKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderedProductKOTExists(id))
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

        // POST: api/RestaurantPOS_OrderedProductKOT
        [ResponseType(typeof(RestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderedProductKOT(RestaurantPOS_OrderedProductKOT restaurantPOS_OrderedProductKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderedProductKOT.Add(restaurantPOS_OrderedProductKOT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderedProductKOT.OP_ID }, restaurantPOS_OrderedProductKOT);
        }

        // DELETE: api/RestaurantPOS_OrderedProductKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductKOT))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderedProductKOT(int id)
        {
            RestaurantPOS_OrderedProductKOT restaurantPOS_OrderedProductKOT = await db.RestaurantPOS_OrderedProductKOT.FindAsync(id);
            if (restaurantPOS_OrderedProductKOT == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderedProductKOT.Remove(restaurantPOS_OrderedProductKOT);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderedProductKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderedProductKOTExists(int id)
        {
            return db.RestaurantPOS_OrderedProductKOT.Count(e => e.OP_ID == id) > 0;
        }
    }
}