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
    public class R_TableController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/R_Table
        public IQueryable<R_Table> GetR_Table()
        {
            return db.R_Table;
        }

        // GET: api/R_Table/5
        [ResponseType(typeof(R_Table))]
        public async Task<IHttpActionResult> GetR_Table(string id)
        {
            R_Table r_Table = await db.R_Table.FindAsync(id);
            if (r_Table == null)
            {
                return NotFound();
            }

            return Ok(r_Table);
        }

        // PUT: api/R_Table/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutR_Table(string id, R_Table r_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != r_Table.TableNo)
            {
                return BadRequest();
            }

            db.Entry(r_Table).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!R_TableExists(id))
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

        // POST: api/R_Table
        [ResponseType(typeof(R_Table))]
        public async Task<IHttpActionResult> PostR_Table(R_Table r_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.R_Table.Add(r_Table);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (R_TableExists(r_Table.TableNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = r_Table.TableNo }, r_Table);
        }

        // DELETE: api/R_Table/5
        [ResponseType(typeof(R_Table))]
        public async Task<IHttpActionResult> DeleteR_Table(string id)
        {
            R_Table r_Table = await db.R_Table.FindAsync(id);
            if (r_Table == null)
            {
                return NotFound();
            }

            db.R_Table.Remove(r_Table);
            await db.SaveChangesAsync();

            return Ok(r_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool R_TableExists(string id)
        {
            return db.R_Table.Count(e => e.TableNo == id) > 0;
        }
    }
}