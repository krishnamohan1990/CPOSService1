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
    public class KitchenController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Kitchen
        public IQueryable<Kitchen> GetKitchens()
        {
            return db.Kitchens;
        }

        // GET: api/Kitchen/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> GetKitchen(string id)
        {
            Kitchen kitchen = await db.Kitchens.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }

            return Ok(kitchen);
        }

        // PUT: api/Kitchen/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKitchen(string id, Kitchen kitchen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kitchen.Kitchenname)
            {
                return BadRequest();
            }

            db.Entry(kitchen).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitchenExists(id))
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

        // POST: api/Kitchen
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostKitchen(Kitchen kitchen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kitchens.Add(kitchen);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KitchenExists(kitchen.Kitchenname))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kitchen.Kitchenname }, kitchen);
        }

        // DELETE: api/Kitchen/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> DeleteKitchen(string id)
        {
            Kitchen kitchen = await db.Kitchens.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }

            db.Kitchens.Remove(kitchen);
            await db.SaveChangesAsync();

            return Ok(kitchen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KitchenExists(string id)
        {
            return db.Kitchens.Count(e => e.Kitchenname == id) > 0;
        }
    }
}