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
    public class Temp_Stock_RMController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Temp_Stock_RM
        public IQueryable<Temp_Stock_RM> GetTemp_Stock_RM()
        {
            return db.Temp_Stock_RM;
        }

        // GET: api/Temp_Stock_RM/5
        [ResponseType(typeof(Temp_Stock_RM))]
        public async Task<IHttpActionResult> GetTemp_Stock_RM(int id)
        {
            Temp_Stock_RM temp_Stock_RM = await db.Temp_Stock_RM.FindAsync(id);
            if (temp_Stock_RM == null)
            {
                return NotFound();
            }

            return Ok(temp_Stock_RM);
        }

        // PUT: api/Temp_Stock_RM/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemp_Stock_RM(int id, Temp_Stock_RM temp_Stock_RM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temp_Stock_RM.Id)
            {
                return BadRequest();
            }

            db.Entry(temp_Stock_RM).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Temp_Stock_RMExists(id))
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

        // POST: api/Temp_Stock_RM
        [ResponseType(typeof(Temp_Stock_RM))]
        public async Task<IHttpActionResult> PostTemp_Stock_RM(Temp_Stock_RM temp_Stock_RM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Temp_Stock_RM.Add(temp_Stock_RM);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = temp_Stock_RM.Id }, temp_Stock_RM);
        }

        // DELETE: api/Temp_Stock_RM/5
        [ResponseType(typeof(Temp_Stock_RM))]
        public async Task<IHttpActionResult> DeleteTemp_Stock_RM(int id)
        {
            Temp_Stock_RM temp_Stock_RM = await db.Temp_Stock_RM.FindAsync(id);
            if (temp_Stock_RM == null)
            {
                return NotFound();
            }

            db.Temp_Stock_RM.Remove(temp_Stock_RM);
            await db.SaveChangesAsync();

            return Ok(temp_Stock_RM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Temp_Stock_RMExists(int id)
        {
            return db.Temp_Stock_RM.Count(e => e.Id == id) > 0;
        }
    }
}