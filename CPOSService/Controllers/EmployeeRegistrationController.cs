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
    public class EmployeeRegistrationController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/EmployeeRegistration
        public IQueryable<EmployeeRegistration> GetEmployeeRegistrations()
        {
            return db.EmployeeRegistrations;
        }

        // GET: api/EmployeeRegistration/5
        [ResponseType(typeof(EmployeeRegistration))]
        public async Task<IHttpActionResult> GetEmployeeRegistration(int id)
        {
            EmployeeRegistration employeeRegistration = await db.EmployeeRegistrations.FindAsync(id);
            if (employeeRegistration == null)
            {
                return NotFound();
            }

            return Ok(employeeRegistration);
        }

        // PUT: api/EmployeeRegistration/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeRegistration(int id, EmployeeRegistration employeeRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeRegistration.EmpId)
            {
                return BadRequest();
            }

            db.Entry(employeeRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeRegistrationExists(id))
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

        // POST: api/EmployeeRegistration
        [ResponseType(typeof(EmployeeRegistration))]
        public async Task<IHttpActionResult> PostEmployeeRegistration(EmployeeRegistration employeeRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeRegistrations.Add(employeeRegistration);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeRegistrationExists(employeeRegistration.EmpId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeRegistration.EmpId }, employeeRegistration);
        }

        // DELETE: api/EmployeeRegistration/5
        [ResponseType(typeof(EmployeeRegistration))]
        public async Task<IHttpActionResult> DeleteEmployeeRegistration(int id)
        {
            EmployeeRegistration employeeRegistration = await db.EmployeeRegistrations.FindAsync(id);
            if (employeeRegistration == null)
            {
                return NotFound();
            }

            db.EmployeeRegistrations.Remove(employeeRegistration);
            await db.SaveChangesAsync();

            return Ok(employeeRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeRegistrationExists(int id)
        {
            return db.EmployeeRegistrations.Count(e => e.EmpId == id) > 0;
        }
    }
}