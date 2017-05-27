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
    public class Temp_Stock_StoreController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Temp_Stock_Store
        public IQueryable<Temp_Stock_Store> GetTemp_Stock_Store()
        {
            return db.Temp_Stock_Store;
        }

        // GET: api/Temp_Stock_Store/5
        [ResponseType(typeof(Temp_Stock_Store))]
        public async Task<IHttpActionResult> GetTemp_Stock_Store(int id)
        {
            Temp_Stock_Store temp_Stock_Store = await db.Temp_Stock_Store.FindAsync(id);
            if (temp_Stock_Store == null)
            {
                return NotFound();
            }

            return Ok(temp_Stock_Store);
        }

        // PUT: api/Temp_Stock_Store/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemp_Stock_Store(int id, Temp_Stock_Store temp_Stock_Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temp_Stock_Store.Id)
            {
                return BadRequest();
            }

            db.Entry(temp_Stock_Store).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Temp_Stock_StoreExists(id))
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

        // POST: api/Temp_Stock_Store
        [ResponseType(typeof(Temp_Stock_Store))]
        public async Task<IHttpActionResult> PostTemp_Stock_Store(Temp_Stock_Store temp_Stock_Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Temp_Stock_Store.Add(temp_Stock_Store);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = temp_Stock_Store.Id }, temp_Stock_Store);
        }

        // DELETE: api/Temp_Stock_Store/5
        [ResponseType(typeof(Temp_Stock_Store))]
        public async Task<IHttpActionResult> DeleteTemp_Stock_Store(int id)
        {
            Temp_Stock_Store temp_Stock_Store = await db.Temp_Stock_Store.FindAsync(id);
            if (temp_Stock_Store == null)
            {
                return NotFound();
            }

            db.Temp_Stock_Store.Remove(temp_Stock_Store);
            await db.SaveChangesAsync();

            return Ok(temp_Stock_Store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Temp_Stock_StoreExists(int id)
        {
            return db.Temp_Stock_Store.Count(e => e.Id == id) > 0;
        }
    }
}