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
    public class WalletController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Wallet
        public IQueryable<Wallet> GetWallets()
        {
            return db.Wallets;
        }

        // GET: api/Wallet/5
        [ResponseType(typeof(Wallet))]
        public async Task<IHttpActionResult> GetWallet(string id)
        {
            Wallet wallet = await db.Wallets.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }

            return Ok(wallet);
        }

        // PUT: api/Wallet/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWallet(string id, Wallet wallet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wallet.WalletType)
            {
                return BadRequest();
            }

            db.Entry(wallet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(id))
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

        // POST: api/Wallet
        [ResponseType(typeof(Wallet))]
        public async Task<IHttpActionResult> PostWallet(Wallet wallet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wallets.Add(wallet);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WalletExists(wallet.WalletType))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wallet.WalletType }, wallet);
        }

        // DELETE: api/Wallet/5
        [ResponseType(typeof(Wallet))]
        public async Task<IHttpActionResult> DeleteWallet(string id)
        {
            Wallet wallet = await db.Wallets.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }

            db.Wallets.Remove(wallet);
            await db.SaveChangesAsync();

            return Ok(wallet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WalletExists(string id)
        {
            return db.Wallets.Count(e => e.WalletType == id) > 0;
        }
    }
}