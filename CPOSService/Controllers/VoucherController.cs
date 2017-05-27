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
    public class VoucherController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Voucher
        public IQueryable<Voucher> GetVouchers()
        {
            return db.Vouchers;
        }

        // GET: api/Voucher/5
        [ResponseType(typeof(Voucher))]
        public async Task<IHttpActionResult> GetVoucher(int id)
        {
            Voucher voucher = await db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }

            return Ok(voucher);
        }

        // PUT: api/Voucher/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVoucher(int id, Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voucher.ID)
            {
                return BadRequest();
            }

            db.Entry(voucher).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(id))
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

        // POST: api/Voucher
        [ResponseType(typeof(Voucher))]
        public async Task<IHttpActionResult> PostVoucher(Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vouchers.Add(voucher);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoucherExists(voucher.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = voucher.ID }, voucher);
        }

        // DELETE: api/Voucher/5
        [ResponseType(typeof(Voucher))]
        public async Task<IHttpActionResult> DeleteVoucher(int id)
        {
            Voucher voucher = await db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }

            db.Vouchers.Remove(voucher);
            await db.SaveChangesAsync();

            return Ok(voucher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoucherExists(int id)
        {
            return db.Vouchers.Count(e => e.ID == id) > 0;
        }
    }
}