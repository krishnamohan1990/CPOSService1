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
    public class RestaurantPOS_BillingInfoKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_BillingInfoKOT
        public IQueryable<RestaurantPOS_BillingInfoKOT> GetRestaurantPOS_BillingInfoKOT()
        {
            return db.RestaurantPOS_BillingInfoKOT;
        }

        // GET: api/RestaurantPOS_BillingInfoKOT/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoKOT))]
        public async Task<IHttpActionResult> GetRestaurantPOS_BillingInfoKOT(int id)
        {
            RestaurantPOS_BillingInfoKOT restaurantPOS_BillingInfoKOT = await db.RestaurantPOS_BillingInfoKOT.FindAsync(id);
            if (restaurantPOS_BillingInfoKOT == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_BillingInfoKOT);
        }

        // PUT: api/RestaurantPOS_BillingInfoKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_BillingInfoKOT(int id, RestaurantPOS_BillingInfoKOT restaurantPOS_BillingInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_BillingInfoKOT.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_BillingInfoKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_BillingInfoKOTExists(id))
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

        // POST: api/RestaurantPOS_BillingInfoKOT
        [ResponseType(typeof(RestaurantPOS_BillingInfoKOT))]
        public async Task<IHttpActionResult> PostRestaurantPOS_BillingInfoKOT(RestaurantPOS_BillingInfoKOT restaurantPOS_BillingInfoKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_BillingInfoKOT.Add(restaurantPOS_BillingInfoKOT);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantPOS_BillingInfoKOTExists(restaurantPOS_BillingInfoKOT.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_BillingInfoKOT.Id }, restaurantPOS_BillingInfoKOT);
        }

        // DELETE: api/RestaurantPOS_BillingInfoKOT/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoKOT))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_BillingInfoKOT(int id)
        {
            RestaurantPOS_BillingInfoKOT restaurantPOS_BillingInfoKOT = await db.RestaurantPOS_BillingInfoKOT.FindAsync(id);
            if (restaurantPOS_BillingInfoKOT == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_BillingInfoKOT.Remove(restaurantPOS_BillingInfoKOT);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_BillingInfoKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_BillingInfoKOTExists(int id)
        {
            return db.RestaurantPOS_BillingInfoKOT.Count(e => e.Id == id) > 0;
        }
    }
}