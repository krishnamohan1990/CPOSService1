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
    public class RestaurantPOS_OrderedProductBillHDController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/RestaurantPOS_OrderedProductBillHD
        public IQueryable<RestaurantPOS_OrderedProductBillHD> GetRestaurantPOS_OrderedProductBillHD()
        {
            return db.RestaurantPOS_OrderedProductBillHD;
        }

        // GET: api/RestaurantPOS_OrderedProductBillHD/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillHD))]
        public async Task<IHttpActionResult> GetRestaurantPOS_OrderedProductBillHD(int id)
        {
            RestaurantPOS_OrderedProductBillHD restaurantPOS_OrderedProductBillHD = await db.RestaurantPOS_OrderedProductBillHD.FindAsync(id);
            if (restaurantPOS_OrderedProductBillHD == null)
            {
                return NotFound();
            }

            return Ok(restaurantPOS_OrderedProductBillHD);
        }

        // PUT: api/RestaurantPOS_OrderedProductBillHD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantPOS_OrderedProductBillHD(int id, RestaurantPOS_OrderedProductBillHD restaurantPOS_OrderedProductBillHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantPOS_OrderedProductBillHD.OP_ID)
            {
                return BadRequest();
            }

            db.Entry(restaurantPOS_OrderedProductBillHD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantPOS_OrderedProductBillHDExists(id))
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

        // POST: api/RestaurantPOS_OrderedProductBillHD
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillHD))]
        public async Task<IHttpActionResult> PostRestaurantPOS_OrderedProductBillHD(RestaurantPOS_OrderedProductBillHD restaurantPOS_OrderedProductBillHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantPOS_OrderedProductBillHD.Add(restaurantPOS_OrderedProductBillHD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantPOS_OrderedProductBillHD.OP_ID }, restaurantPOS_OrderedProductBillHD);
        }

        // DELETE: api/RestaurantPOS_OrderedProductBillHD/5
        [ResponseType(typeof(RestaurantPOS_OrderedProductBillHD))]
        public async Task<IHttpActionResult> DeleteRestaurantPOS_OrderedProductBillHD(int id)
        {
            RestaurantPOS_OrderedProductBillHD restaurantPOS_OrderedProductBillHD = await db.RestaurantPOS_OrderedProductBillHD.FindAsync(id);
            if (restaurantPOS_OrderedProductBillHD == null)
            {
                return NotFound();
            }

            db.RestaurantPOS_OrderedProductBillHD.Remove(restaurantPOS_OrderedProductBillHD);
            await db.SaveChangesAsync();

            return Ok(restaurantPOS_OrderedProductBillHD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantPOS_OrderedProductBillHDExists(int id)
        {
            return db.RestaurantPOS_OrderedProductBillHD.Count(e => e.OP_ID == id) > 0;
        }
    }
}