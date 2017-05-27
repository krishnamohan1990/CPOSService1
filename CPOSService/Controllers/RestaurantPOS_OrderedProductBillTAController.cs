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
    public class RestaurantPOS_OrderedProductBillTAController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderedProductBillTA
        public IQueryable<RestaurantPOS_OrderedProductBillTA> GetRestaurantPOS_OrderedProductBillTA()
        {
            return db.RestaurantPOS_OrderedProductBillTA;
        }

        // GET: api/RestaurantPOS_OrderedProductBillTA/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillTA))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderedProductBillTA(int id)
        {
            RestaurantPOS_OrderedProductBillTA restaurantPOS_OrderedProductBillTA = await db.RestaurantPOS_OrderedProductBillTA.FindAsync(id);
            if (restaurantPOS_OrderedProductBillTA == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderedProductBillTA);
        }

        // PUT: api/RestaurantPOS_OrderedProductBillTA/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderedProductBillTA(int id, RestaurantPOS_OrderedProductBillTA restaurantPOS_OrderedProductBillTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderedProductBillTA.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderedProductBillTA).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderedProductBillTAExists(id))
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

        // POST: api/RestaurantPOS_OrderedProductBillTA
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillTA))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderedProductBillTA(RestaurantPOS_OrderedProductBillTA restaurantPOS_OrderedProductBillTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderedProductBillTA.Add(restaurantPOS_OrderedProductBillTA);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderedProductBillTA.OP_ID }, restaurantPOS_OrderedProductBillTA);
        }

        // DELETE: api/RestaurantPOS_OrderedProductBillTA/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillTA))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderedProductBillTA(int id)
        {
            RestaurantPOS_OrderedProductBillTA restaurantPOS_OrderedProductBillTA = await db.RestaurantPOS_OrderedProductBillTA.FindAsync(id);
            if (restaurantPOS_OrderedProductBillTA == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderedProductBillTA.Remove(restaurantPOS_OrderedProductBillTA);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderedProductBillTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderedProductBillTAExists(int id)
        {
            return db.RestaurantPOS_OrderedProductBillTA.Count(e => e.OP_ID == id) > 0;
        }
    }
}