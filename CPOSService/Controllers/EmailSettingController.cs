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
    public class EmailSettingController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/EmailSetting
        public IQueryable<EmailSetting> GetEmailSettings()
        {
            return db.EmailSettings;
        }

        // GET: api/EmailSetting/5
        [ResponseType(typeof(EmailSetting))]
        public async Task<IHttpActionResult> GetEmailSetting(int id)
        {
            EmailSetting emailSetting = await db.EmailSettings.FindAsync(id);
            if (emailSetting == null)
            {
                return NotFound();
            }

            return Ok(emailSetting);
        }

        // PUT: api/EmailSetting/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmailSetting(int id, EmailSetting emailSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailSetting.Id)
            {
                return BadRequest();
            }

            db.Entry(emailSetting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailSettingExists(id))
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

        // POST: api/EmailSetting
        [ResponseType(typeof(EmailSetting))]
        public async Task<IHttpActionResult> PostEmailSetting(EmailSetting emailSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmailSettings.Add(emailSetting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emailSetting.Id }, emailSetting);
        }

        // DELETE: api/EmailSetting/5
        [ResponseType(typeof(EmailSetting))]
        public async Task<IHttpActionResult> DeleteEmailSetting(int id)
        {
            EmailSetting emailSetting = await db.EmailSettings.FindAsync(id);
            if (emailSetting == null)
            {
                return NotFound();
            }

            db.EmailSettings.Remove(emailSetting);
            await db.SaveChangesAsync();

            return Ok(emailSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailSettingExists(int id)
        {
            return db.EmailSettings.Count(e => e.Id == id) > 0;
        }
    }
}