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
    public class Recipe_JoinController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();

        // GET: api/Recipe_Join
        public IQueryable<Recipe_Join> GetRecipe_Join()
        {
            return db.Recipe_Join;
        }

        // GET: api/Recipe_Join/5
        [ResponseType(typeof(Recipe_Join))]
        public async Task<IHttpActionResult> GetRecipe_Join(int id)
        {
            Recipe_Join recipe_Join = await db.Recipe_Join.FindAsync(id);
            if (recipe_Join == null)
            {
                return NotFound();
            }

            return Ok(recipe_Join);
        }

        // PUT: api/Recipe_Join/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipe_Join(int id, Recipe_Join recipe_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe_Join.RJ_ID)
            {
                return BadRequest();
            }

            db.Entry(recipe_Join).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Recipe_JoinExists(id))
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

        // POST: api/Recipe_Join
        [ResponseType(typeof(Recipe_Join))]
        public async Task<IHttpActionResult> PostRecipe_Join(Recipe_Join recipe_Join)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipe_Join.Add(recipe_Join);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recipe_Join.RJ_ID }, recipe_Join);
        }

        // DELETE: api/Recipe_Join/5
        [ResponseType(typeof(Recipe_Join))]
        public async Task<IHttpActionResult> DeleteRecipe_Join(int id)
        {
            Recipe_Join recipe_Join = await db.Recipe_Join.FindAsync(id);
            if (recipe_Join == null)
            {
                return NotFound();
            }

            db.Recipe_Join.Remove(recipe_Join);
            await db.SaveChangesAsync();

            return Ok(recipe_Join);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Recipe_JoinExists(int id)
        {
            return db.Recipe_Join.Count(e => e.RJ_ID == id) > 0;
        }
    }
}