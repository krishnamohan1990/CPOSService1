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
    public class Voucher_OtherDetailsController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Voucher_OtherDetails
        public IQueryable<Voucher_OtherDetails> GetVoucher_OtherDetails()
        {
            return db.Voucher_OtherDetails;
        }

        // GET: api/Voucher_OtherDetails/5
        [ResponseType(typeof(Voucher_OtherDetails))]
        public async Task<IHttpActionResult> GetVoucher_OtherDetails(int id)
        {
            Voucher_OtherDetails voucher_OtherDetails = await db.Voucher_OtherDetails.FindAsync(id);
            if (voucher_OtherDetails == null)
            {
                return NotFound();
            }

            return Ok(voucher_OtherDetails);
        }

        // PUT: api/Voucher_OtherDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVoucher_OtherDetails(int id, Voucher_OtherDetails voucher_OtherDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voucher_OtherDetails.VD_ID)
            {
                return BadRequest();
            }

            db.Entry(voucher_OtherDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Voucher_OtherDetailsExists(id))
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

        // POST: api/Voucher_OtherDetails
        [ResponseType(typeof(Voucher_OtherDetails))]
        public async Task<IHttpActionResult> PostVoucher_OtherDetails(Voucher_OtherDetails voucher_OtherDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voucher_OtherDetails.Add(voucher_OtherDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = voucher_OtherDetails.VD_ID }, voucher_OtherDetails);
        }

        // DELETE: api/Voucher_OtherDetails/5
        [ResponseType(typeof(Voucher_OtherDetails))]
        public async Task<IHttpActionResult> DeleteVoucher_OtherDetails(int id)
        {
            Voucher_OtherDetails voucher_OtherDetails = await db.Voucher_OtherDetails.FindAsync(id);
            if (voucher_OtherDetails == null)
            {
                return NotFound();
            }

            db.Voucher_OtherDetails.Remove(voucher_OtherDetails);
            await db.SaveChangesAsync();

            return Ok(voucher_OtherDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Voucher_OtherDetailsExists(int id)
        {
            return db.Voucher_OtherDetails.Count(e => e.VD_ID == id) > 0;
        }
    }
}