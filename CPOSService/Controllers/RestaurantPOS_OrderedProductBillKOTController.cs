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
    public class RestaurantPOS_OrderedProductBillKOTController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderedProductBillKOT
        public IQueryable<RestaurantPOS_OrderedProductBillKOT> GetRestaurantPOS_OrderedProductBillKOT()
        {
            return db.RestaurantPOS_OrderedProductBillKOT;
        }

        // GET: api/RestaurantPOS_OrderedProductBillKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillKOT))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderedProductBillKOT(int id)
        {
            RestaurantPOS_OrderedProductBillKOT restaurantPOS_OrderedProductBillKOT = await db.RestaurantPOS_OrderedProductBillKOT.FindAsync(id);
            if (restaurantPOS_OrderedProductBillKOT == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderedProductBillKOT);
        }

        // PUT: api/RestaurantPOS_OrderedProductBillKOT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderedProductBillKOT(int id, RestaurantPOS_OrderedProductBillKOT restaurantPOS_OrderedProductBillKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderedProductBillKOT.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderedProductBillKOT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderedProductBillKOTExists(id))
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

        // POST: api/RestaurantPOS_OrderedProductBillKOT
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillKOT))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderedProductBillKOT(RestaurantPOS_OrderedProductBillKOT restaurantPOS_OrderedProductBillKOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderedProductBillKOT.Add(restaurantPOS_OrderedProductBillKOT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderedProductBillKOT.OP_ID }, restaurantPOS_OrderedProductBillKOT);
        }

        // DELETE: api/RestaurantPOS_OrderedProductBillKOT/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillKOT))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderedProductBillKOT(int id)
        {
            RestaurantPOS_OrderedProductBillKOT restaurantPOS_OrderedProductBillKOT = await db.RestaurantPOS_OrderedProductBillKOT.FindAsync(id);
            if (restaurantPOS_OrderedProductBillKOT == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderedProductBillKOT.Remove(restaurantPOS_OrderedProductBillKOT);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderedProductBillKOT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderedProductBillKOTExists(int id)
        {
            return db.RestaurantPOS_OrderedProductBillKOT.Count(e => e.OP_ID == id) > 0;
        }
    }
}