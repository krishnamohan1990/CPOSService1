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
    public class RegistrationController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Registration
        public IQueryable<Registration> GetRegistrations()
        {
            return db.Registrations;
        }

        // GET: api/Registration/5
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> GetRegistration(string id)
        {
            Registration registration = await db.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // PUT: api/Registration/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistration(string id, Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registration.UserID)
            {
                return BadRequest();
            }

            db.Entry(registration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registration
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> PostRegistration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registrations.Add(registration);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistrationExists(registration.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = registration.UserID }, registration);
        }

        // DELETE: api/Registration/5
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> DeleteRegistration(string id)
        {
            Registration registration = await db.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            db.Registrations.Remove(registration);
            await db.SaveChangesAsync();

            return Ok(registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationExists(string id)
        {
            return db.Registrations.Count(e => e.UserID == id) > 0;
        }
    }
}