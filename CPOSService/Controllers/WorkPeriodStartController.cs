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
    public class WorkPeriodStartController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/WorkPeriodStart
        public IQueryable<WorkPeriodStart> GetWorkPeriodStarts()
        {
            return db.WorkPeriodStarts;
        }

        // GET: api/WorkPeriodStart/5
        [ResponseType(typeof(WorkPeriodStart))]
        public async Task<IHttpActionResult> GetWorkPeriodStart(int id)
        {
            WorkPeriodStart workPeriodStart = await db.WorkPeriodStarts.FindAsync(id);
            if (workPeriodStart == null)
            {
                return NotFound();
            }

            return Ok(workPeriodStart);
        }

        // PUT: api/WorkPeriodStart/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkPeriodStart(int id, WorkPeriodStart workPeriodStart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workPeriodStart.ID)
            {
                return BadRequest();
            }

            db.Entry(workPeriodStart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPeriodStartExists(id))
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

        // POST: api/WorkPeriodStart
        [ResponseType(typeof(WorkPeriodStart))]
        public async Task<IHttpActionResult> PostWorkPeriodStart(WorkPeriodStart workPeriodStart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkPeriodStarts.Add(workPeriodStart);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workPeriodStart.ID }, workPeriodStart);
        }

        // DELETE: api/WorkPeriodStart/5
        [ResponseType(typeof(WorkPeriodStart))]
        public async Task<IHttpActionResult> DeleteWorkPeriodStart(int id)
        {
            WorkPeriodStart workPeriodStart = await db.WorkPeriodStarts.FindAsync(id);
            if (workPeriodStart == null)
            {
                return NotFound();
            }

            db.WorkPeriodStarts.Remove(workPeriodStart);
            await db.SaveChangesAsync();

            return Ok(workPeriodStart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkPeriodStartExists(int id)
        {
            return db.WorkPeriodStarts.Count(e => e.ID == id) > 0;
        }
    }
}