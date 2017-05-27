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
    public class NotesMasterController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/NotesMaster
        public IQueryable<NotesMaster> GetNotesMasters()
        {
            return db.NotesMasters;
        }

        // GET: api/NotesMaster/5
        [ResponseType(typeof(NotesMaster))]
        public async Task<IHttpActionResult> GetNotesMaster(int id)
        {
            NotesMaster notesMaster = await db.NotesMasters.FindAsync(id);
            if (notesMaster == null)
            {
                return NotFound();
            }

            return Ok(notesMaster);
        }

        // PUT: api/NotesMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotesMaster(int id, NotesMaster notesMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notesMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(notesMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesMasterExists(id))
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

        // POST: api/NotesMaster
        [ResponseType(typeof(NotesMaster))]
        public async Task<IHttpActionResult> PostNotesMaster(NotesMaster notesMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotesMasters.Add(notesMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notesMaster.ID }, notesMaster);
        }

        // DELETE: api/NotesMaster/5
        [ResponseType(typeof(NotesMaster))]
        public async Task<IHttpActionResult> DeleteNotesMaster(int id)
        {
            NotesMaster notesMaster = await db.NotesMasters.FindAsync(id);
            if (notesMaster == null)
            {
                return NotFound();
            }

            db.NotesMasters.Remove(notesMaster);
            await db.SaveChangesAsync();

            return Ok(notesMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotesMasterExists(int id)
        {
            return db.NotesMasters.Count(e => e.ID == id) > 0;
        }
    }
}