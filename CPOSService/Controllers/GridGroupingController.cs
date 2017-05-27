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
    public class GridGroupingController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/GridGrouping
        public IQueryable<GridGrouping> GetGridGroupings()
        {
            return db.GridGroupings;
        }

        // GET: api/GridGrouping/5
        [ResponseType(typeof(GridGrouping))]
        public async Task<IHttpActionResult> GetGridGrouping(int id)
        {
            GridGrouping gridGrouping = await db.GridGroupings.FindAsync(id);
            if (gridGrouping == null)
            {
                return NotFound();
            }

            return Ok(gridGrouping);
        }

        // PUT: api/GridGrouping/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGridGrouping(int id, GridGrouping gridGrouping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gridGrouping.Id)
            {
                return BadRequest();
            }

            db.Entry(gridGrouping).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GridGroupingExists(id))
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

        // POST: api/GridGrouping
        [ResponseType(typeof(GridGrouping))]
        public async Task<IHttpActionResult> PostGridGrouping(GridGrouping gridGrouping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GridGroupings.Add(gridGrouping);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GridGroupingExists(gridGrouping.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gridGrouping.Id }, gridGrouping);
        }

        // DELETE: api/GridGrouping/5
        [ResponseType(typeof(GridGrouping))]
        public async Task<IHttpActionResult> DeleteGridGrouping(int id)
        {
            GridGrouping gridGrouping = await db.GridGroupings.FindAsync(id);
            if (gridGrouping == null)
            {
                return NotFound();
            }

            db.GridGroupings.Remove(gridGrouping);
            await db.SaveChangesAsync();

            return Ok(gridGrouping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GridGroupingExists(int id)
        {
            return db.GridGroupings.Count(e => e.Id == id) > 0;
        }
    }
}