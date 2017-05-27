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
    public class RestaurantPOS_OrderInfoKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderInfoKOT
        public IQueryable<RestaurantPOS_OrderInfoKOT> GetRestaurantPOS_OrderInfoKOT()
        {
            return db.RestaurantPOS_OrderInfoKOT;
        }

        // GET: api/RestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderInfoKOT(int id)
        {
            RestaurantPOS_OrderInfoKOT restaurantPOS_OrderInfoKOT = await db.RestaurantPOS_OrderInfoKOT.FindAsync(id);
            if (restaurantPOS_OrderInfoKOT == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderInfoKOT);
        }

        // PUT: api/RestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderInfoKOT(int id, RestaurantPOS_OrderInfoKOT restaurantPOS_OrderInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderInfoKOT.ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderInfoKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderInfoKOTExists(id))
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

        // POST: api/RestaurantPOS_OrderInfoKOT
        [ResponseType(typeof(RestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderInfoKOT(RestaurantPOS_OrderInfoKOT restaurantPOS_OrderInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderInfoKOT.Add(restaurantPOS_OrderInfoKOT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderInfoKOT.ID }, restaurantPOS_OrderInfoKOT);
        }

        // DELETE: api/RestaurantPOS_OrderInfoKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderInfoKOT))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderInfoKOT(int id)
        {
            RestaurantPOS_OrderInfoKOT restaurantPOS_OrderInfoKOT = await db.RestaurantPOS_OrderInfoKOT.FindAsync(id);
            if (restaurantPOS_OrderInfoKOT == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderInfoKOT.Remove(restaurantPOS_OrderInfoKOT);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderInfoKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderInfoKOTExists(int id)
        {
            return db.RestaurantPOS_OrderInfoKOT.Count(e => e.ID == id) > 0;
        }
    }
}