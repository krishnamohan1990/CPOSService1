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
    public class PosGroupingController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/PosGrouping
        public IQueryable<PosGrouping> GetPosGroupings()
        {
            return db.PosGroupings;
        }

        // GET: api/PosGrouping/5
        [ResponseType(typeof(PosGrouping))]
        public async Task<IHttpActionResult> GetPosGrouping(int id)
        {
            PosGrouping posGrouping = await db.PosGroupings.FindAsync(id);
            if (posGrouping == null)
            {
                return NotFound();
            }

            return Ok(posGrouping);
        }

        // PUT: api/PosGrouping/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPosGrouping(int id, PosGrouping posGrouping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posGrouping.id)
            {
                return BadRequest();
            }

            db.Entry(posGrouping).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosGroupingExists(id))
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

        // POST: api/PosGrouping
        [ResponseType(typeof(PosGrouping))]
        public async Task<IHttpActionResult> PostPosGrouping(PosGrouping posGrouping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PosGroupings.Add(posGrouping);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = posGrouping.id }, posGrouping);
        }

        // DELETE: api/PosGrouping/5
        [ResponseType(typeof(PosGrouping))]
        public async Task<IHttpActionResult> DeletePosGrouping(int id)
        {
            PosGrouping posGrouping = await db.PosGroupings.FindAsync(id);
            if (posGrouping == null)
            {
                return NotFound();
            }

            db.PosGroupings.Remove(posGrouping);
            await db.SaveChangesAsync();

            return Ok(posGrouping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosGroupingExists(int id)
        {
            return db.PosGroupings.Count(e => e.id == id) > 0;
        }
    }
}