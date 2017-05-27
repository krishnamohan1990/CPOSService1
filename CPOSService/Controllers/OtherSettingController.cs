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
    public class OtherSettingController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/OtherSetting
        public IQueryable<OtherSetting> GetOtherSettings()
        {
            return db.OtherSettings;
        }

        // GET: api/OtherSetting/5
        [ResponseType(typeof(OtherSetting))]
        public async Task<IHttpActionResult> GetOtherSetting(int id)
        {
            OtherSetting otherSetting = await db.OtherSettings.FindAsync(id);
            if (otherSetting == null)
            {
                return NotFound();
            }

            return Ok(otherSetting);
        }

        // PUT: api/OtherSetting/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOtherSetting(int id, OtherSetting otherSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != otherSetting.ID)
            {
                return BadRequest();
            }

            db.Entry(otherSetting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherSettingExists(id))
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

        // POST: api/OtherSetting
        [ResponseType(typeof(OtherSetting))]
        public async Task<IHttpActionResult> PostOtherSetting(OtherSetting otherSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OtherSettings.Add(otherSetting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = otherSetting.ID }, otherSetting);
        }

        // DELETE: api/OtherSetting/5
        [ResponseType(typeof(OtherSetting))]
        public async Task<IHttpActionResult> DeleteOtherSetting(int id)
        {
            OtherSetting otherSetting = await db.OtherSettings.FindAsync(id);
            if (otherSetting == null)
            {
                return NotFound();
            }

            db.OtherSettings.Remove(otherSetting);
            await db.SaveChangesAsync();

            return Ok(otherSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OtherSettingExists(int id)
        {
            return db.OtherSettings.Count(e => e.ID == id) > 0;
        }
    }
}