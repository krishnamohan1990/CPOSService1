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
    public class RestaurantPOS_BillingInfoHDController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_BillingInfoHD
        public IQueryable<RestaurantPOS_BillingInfoHD> GetRestaurantPOS_BillingInfoHD()
        {
            return db.RestaurantPOS_BillingInfoHD;
        }

        // GET: api/RestaurantPOS_BillingInfoHD/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoHD))]
        public async Task<IHttpActionResult> GetRestaurantPOS_BillingInfoHD(int id)
        {
            RestaurantPOS_BillingInfoHD restaurantPOS_BillingInfoHD = await db.RestaurantPOS_BillingInfoHD.FindAsync(id);
            if (restaurantPOS_BillingInfoHD == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_BillingInfoHD);
        }

        // PUT: api/RestaurantPOS_BillingInfoHD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_BillingInfoHD(int id, RestaurantPOS_BillingInfoHD restaurantPOS_BillingInfoHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_BillingInfoHD.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_BillingInfoHD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_BillingInfoHDExists(id))
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

        // POST: api/RestaurantPOS_BillingInfoHD
        [ResponseType(typeof(RestaurantPOS_BillingInfoHD))]
        public async Task<IHttpActionResult> PostRestaurantPOS_BillingInfoHD(RestaurantPOS_BillingInfoHD restaurantPOS_BillingInfoHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_BillingInfoHD.Add(restaurantPOS_BillingInfoHD);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantPOS_BillingInfoHDExists(restaurantPOS_BillingInfoHD.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_BillingInfoHD.Id }, restaurantPOS_BillingInfoHD);
        }

        // DELETE: api/RestaurantPOS_BillingInfoHD/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoHD))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_BillingInfoHD(int id)
        {
            RestaurantPOS_BillingInfoHD restaurantPOS_BillingInfoHD = await db.RestaurantPOS_BillingInfoHD.FindAsync(id);
            if (restaurantPOS_BillingInfoHD == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_BillingInfoHD.Remove(restaurantPOS_BillingInfoHD);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_BillingInfoHD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_BillingInfoHDExists(int id)
        {
            return db.RestaurantPOS_BillingInfoHD.Count(e => e.Id == id) > 0;
        }
    }
}