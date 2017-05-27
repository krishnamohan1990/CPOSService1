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
    public class MemberLedgerController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/MemberLedger
        public IQueryable<MemberLedger> GetMemberLedgers()
        {
            return db.MemberLedgers;
        }

        // GET: api/MemberLedger/5
        [ResponseType(typeof(MemberLedger))]
        public async Task<IHttpActionResult> GetMemberLedger(int id)
        {
            MemberLedger memberLedger = await db.MemberLedgers.FindAsync(id);
            if (memberLedger == null)
            {
                return NotFound();
            }

            return Ok(memberLedger);
        }

        // PUT: api/MemberLedger/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMemberLedger(int id, MemberLedger memberLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberLedger.Id)
            {
                return BadRequest();
            }

            db.Entry(memberLedger).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberLedgerExists(id))
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

        // POST: api/MemberLedger
        [ResponseType(typeof(MemberLedger))]
        public async Task<IHttpActionResult> PostMemberLedger(MemberLedger memberLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MemberLedgers.Add(memberLedger);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MemberLedgerExists(memberLedger.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = memberLedger.Id }, memberLedger);
        }

        // DELETE: api/MemberLedger/5
        [ResponseType(typeof(MemberLedger))]
        public async Task<IHttpActionResult> DeleteMemberLedger(int id)
        {
            MemberLedger memberLedger = await db.MemberLedgers.FindAsync(id);
            if (memberLedger == null)
            {
                return NotFound();
            }

            db.MemberLedgers.Remove(memberLedger);
            await db.SaveChangesAsync();

            return Ok(memberLedger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberLedgerExists(int id)
        {
            return db.MemberLedgers.Count(e => e.Id == id) > 0;
        }
    }
}