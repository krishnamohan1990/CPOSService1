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
    public class WorkPeriodEndController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/WorkPeriodEnd
        public IQueryable<WorkPeriodEnd> GetWorkPeriodEnds()
        {
            return db.WorkPeriodEnds;
        }

        // GET: api/WorkPeriodEnd/5
        [ResponseType(typeof(WorkPeriodEnd))]
        public async Task<IHttpActionResult> GetWorkPeriodEnd(int id)
        {
            WorkPeriodEnd workPeriodEnd = await db.WorkPeriodEnds.FindAsync(id);
            if (workPeriodEnd == null)
            {
                return NotFound();
            }

            return Ok(workPeriodEnd);
        }

        // PUT: api/WorkPeriodEnd/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkPeriodEnd(int id, WorkPeriodEnd workPeriodEnd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workPeriodEnd.Id)
            {
                return BadRequest();
            }

            db.Entry(workPeriodEnd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPeriodEndExists(id))
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

        // POST: api/WorkPeriodEnd
        [ResponseType(typeof(WorkPeriodEnd))]
        public async Task<IHttpActionResult> PostWorkPeriodEnd(WorkPeriodEnd workPeriodEnd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkPeriodEnds.Add(workPeriodEnd);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkPeriodEndExists(workPeriodEnd.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = workPeriodEnd.Id }, workPeriodEnd);
        }

        // DELETE: api/WorkPeriodEnd/5
        [ResponseType(typeof(WorkPeriodEnd))]
        public async Task<IHttpActionResult> DeleteWorkPeriodEnd(int id)
        {
            WorkPeriodEnd workPeriodEnd = await db.WorkPeriodEnds.FindAsync(id);
            if (workPeriodEnd == null)
            {
                return NotFound();
            }

            db.WorkPeriodEnds.Remove(workPeriodEnd);
            await db.SaveChangesAsync();

            return Ok(workPeriodEnd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkPeriodEndExists(int id)
        {
            return db.WorkPeriodEnds.Count(e => e.Id == id) > 0;
        }
    }
}