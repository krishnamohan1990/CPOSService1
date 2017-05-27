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
    public class WarehouseController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Warehouse
        public IQueryable<Warehouse> GetWarehouses()
        {
            return db.Warehouses;
        }

        // GET: api/Warehouse/5
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> GetWarehouse(string id)
        {
            Warehouse warehouse = await db.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        // PUT: api/Warehouse/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWarehouse(string id, Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warehouse.WarehouseName)
            {
                return BadRequest();
            }

            db.Entry(warehouse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
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

        // POST: api/Warehouse
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> PostWarehouse(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Warehouses.Add(warehouse);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WarehouseExists(warehouse.WarehouseName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = warehouse.WarehouseName }, warehouse);
        }

        // DELETE: api/Warehouse/5
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> DeleteWarehouse(string id)
        {
            Warehouse warehouse = await db.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            db.Warehouses.Remove(warehouse);
            await db.SaveChangesAsync();

            return Ok(warehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WarehouseExists(string id)
        {
            return db.Warehouses.Count(e => e.WarehouseName == id) > 0;
        }
    }
}