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
    public class RestaurantPOS_BillingInfoEBController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_BillingInfoEB
        public IQueryable<RestaurantPOS_BillingInfoEB> GetRestaurantPOS_BillingInfoEB()
        {
            return db.RestaurantPOS_BillingInfoEB;
        }

        // GET: api/RestaurantPOS_BillingInfoEB/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoEB))]
        public async Task<IHttpActionResult> GetRestaurantPOS_BillingInfoEB(int id)
        {
            RestaurantPOS_BillingInfoEB restaurantPOS_BillingInfoEB = await db.RestaurantPOS_BillingInfoEB.FindAsync(id);
            if (restaurantPOS_BillingInfoEB == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_BillingInfoEB);
        }

        // PUT: api/RestaurantPOS_BillingInfoEB/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_BillingInfoEB(int id, RestaurantPOS_BillingInfoEB restaurantPOS_BillingInfoEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_BillingInfoEB.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_BillingInfoEB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_BillingInfoEBExists(id))
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

        // POST: api/RestaurantPOS_BillingInfoEB
        [ResponseType(typeof(RestaurantPOS_BillingInfoEB))]
        public async Task<IHttpActionResult> PostRestaurantPOS_BillingInfoEB(RestaurantPOS_BillingInfoEB restaurantPOS_BillingInfoEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_BillingInfoEB.Add(restaurantPOS_BillingInfoEB);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantPOS_BillingInfoEBExists(restaurantPOS_BillingInfoEB.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_BillingInfoEB.Id }, restaurantPOS_BillingInfoEB);
        }

        // DELETE: api/RestaurantPOS_BillingInfoEB/5
        [ResponseType(typeof(RestaurantPOS_BillingInfoEB))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_BillingInfoEB(int id)
        {
            RestaurantPOS_BillingInfoEB restaurantPOS_BillingInfoEB = await db.RestaurantPOS_BillingInfoEB.FindAsync(id);
            if (restaurantPOS_BillingInfoEB == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_BillingInfoEB.Remove(restaurantPOS_BillingInfoEB);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_BillingInfoEB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_BillingInfoEBExists(int id)
        {
            return db.RestaurantPOS_BillingInfoEB.Count(e => e.Id == id) > 0;
        }
    }
}