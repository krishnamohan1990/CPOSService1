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
    public class SMSSettingController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/SMSSetting
        public IQueryable<SMSSetting> GetSMSSettings()
        {
            return db.SMSSettings;
        }

        // GET: api/SMSSetting/5
        [ResponseType(typeof(SMSSetting))]
        public async Task<IHttpActionResult> GetSMSSetting(int id)
        {
            SMSSetting sMSSetting = await db.SMSSettings.FindAsync(id);
            if (sMSSetting == null)
            {
                return NotFound();
            }

            return Ok(sMSSetting);
        }

        // PUT: api/SMSSetting/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSMSSetting(int id, SMSSetting sMSSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sMSSetting.Id)
            {
                return BadRequest();
            }

            db.Entry(sMSSetting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMSSettingExists(id))
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

        // POST: api/SMSSetting
        [ResponseType(typeof(SMSSetting))]
        public async Task<IHttpActionResult> PostSMSSetting(SMSSetting sMSSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SMSSettings.Add(sMSSetting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sMSSetting.Id }, sMSSetting);
        }

        // DELETE: api/SMSSetting/5
        [ResponseType(typeof(SMSSetting))]
        public async Task<IHttpActionResult> DeleteSMSSetting(int id)
        {
            SMSSetting sMSSetting = await db.SMSSettings.FindAsync(id);
            if (sMSSetting == null)
            {
                return NotFound();
            }

            db.SMSSettings.Remove(sMSSetting);
            await db.SaveChangesAsync();

            return Ok(sMSSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMSSettingExists(int id)
        {
            return db.SMSSettings.Count(e => e.Id == id) > 0;
        }
    }
}