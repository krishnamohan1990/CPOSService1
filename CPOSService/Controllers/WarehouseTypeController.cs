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
    public class WarehouseTypeController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/WarehouseType
        public IQueryable<WarehouseType> GetWarehouseTypes()
        {
            return db.WarehouseTypes;
        }

        // GET: api/WarehouseType/5
        [ResponseType(typeof(WarehouseType))]
        public async Task<IHttpActionResult> GetWarehouseType(string id)
        {
            WarehouseType warehouseType = await db.WarehouseTypes.FindAsync(id);
            if (warehouseType == null)
            {
                return NotFound();
            }

            return Ok(warehouseType);
        }

        // PUT: api/WarehouseType/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWarehouseType(string id, WarehouseType warehouseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warehouseType.Type)
            {
                return BadRequest();
            }

            db.Entry(warehouseType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseTypeExists(id))
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

        // POST: api/WarehouseType
        [ResponseType(typeof(WarehouseType))]
        public async Task<IHttpActionResult> PostWarehouseType(WarehouseType warehouseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WarehouseTypes.Add(warehouseType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WarehouseTypeExists(warehouseType.Type))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = warehouseType.Type }, warehouseType);
        }

        // DELETE: api/WarehouseType/5
        [ResponseType(typeof(WarehouseType))]
        public async Task<IHttpActionResult> DeleteWarehouseType(string id)
        {
            WarehouseType warehouseType = await db.WarehouseTypes.FindAsync(id);
            if (warehouseType == null)
            {
                return NotFound();
            }

            db.WarehouseTypes.Remove(warehouseType);
            await db.SaveChangesAsync();

            return Ok(warehouseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WarehouseTypeExists(string id)
        {
            return db.WarehouseTypes.Count(e => e.Type == id) > 0;
        }
    }
}