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
    public class ActivationController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Activation
        public IQueryable<Activation> GetActivations()
        {
            return db.Activations;
        }

        // GET: api/Activation/5
        [ResponseType(typeof(Activation))]
        public async Task<IHttpActionResult> GetActivation(int id)
        {
            Activation activation = await db.Activations.FindAsync(id);
            if (activation == null)
            {
                return NotFound();
            }

            return Ok(activation);
        }

        // PUT: api/Activation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivation(int id, Activation activation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activation.Id)
            {
                return BadRequest();
            }

            db.Entry(activation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivationExists(id))
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

        // POST: api/Activation
        [ResponseType(typeof(Activation))]
        public async Task<IHttpActionResult> PostActivation(Activation activation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activations.Add(activation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activation.Id }, activation);
        }

        // DELETE: api/Activation/5
        [ResponseType(typeof(Activation))]
        public async Task<IHttpActionResult> DeleteActivation(int id)
        {
            Activation activation = await db.Activations.FindAsync(id);
            if (activation == null)
            {
                return NotFound();
            }

            db.Activations.Remove(activation);
            await db.SaveChangesAsync();

            return Ok(activation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivationExists(int id)
        {
            return db.Activations.Count(e => e.Id == id) > 0;
        }
    }
}