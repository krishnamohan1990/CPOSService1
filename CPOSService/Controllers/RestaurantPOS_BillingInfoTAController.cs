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
    public class RestaurantPOS_BillingInfoTAController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_BillingInfoTA
        public IQueryable<RestaurantPOS_BillingInfoTA> GetRestaurantPOS_BillingInfoTA()
        {
            return db.RestaurantPOS_BillingInfoTA;
        }

        // GET: api/RestaurantPOS_BillingInfoTA/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoTA))]
        public async Task<IHttpActionResult> GetRestaurantPOS_BillingInfoTA(int id)
        {
            RestaurantPOS_BillingInfoTA restaurantPOS_BillingInfoTA = await db.RestaurantPOS_BillingInfoTA.FindAsync(id);
            if (restaurantPOS_BillingInfoTA == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_BillingInfoTA);
        }

        // PUT: api/RestaurantPOS_BillingInfoTA/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_BillingInfoTA(int id, RestaurantPOS_BillingInfoTA restaurantPOS_BillingInfoTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_BillingInfoTA.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_BillingInfoTA).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_BillingInfoTAExists(id))
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

        // POST: api/RestaurantPOS_BillingInfoTA
        [ResponseType(typeof(RestaurantPOS_BillingInfoTA))]
        public async Task<IHttpActionResult> PostRestaurantPOS_BillingInfoTA(RestaurantPOS_BillingInfoTA restaurantPOS_BillingInfoTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_BillingInfoTA.Add(restaurantPOS_BillingInfoTA);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantPOS_BillingInfoTAExists(restaurantPOS_BillingInfoTA.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_BillingInfoTA.Id }, restaurantPOS_BillingInfoTA);
        }

        // DELETE: api/RestaurantPOS_BillingInfoTA/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoTA))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_BillingInfoTA(int id)
        {
            RestaurantPOS_BillingInfoTA restaurantPOS_BillingInfoTA = await db.RestaurantPOS_BillingInfoTA.FindAsync(id);
            if (restaurantPOS_BillingInfoTA == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_BillingInfoTA.Remove(restaurantPOS_BillingInfoTA);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_BillingInfoTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_BillingInfoTAExists(int id)
        {
            return db.RestaurantPOS_BillingInfoTA.Count(e => e.Id == id) > 0;
        }
    }
}