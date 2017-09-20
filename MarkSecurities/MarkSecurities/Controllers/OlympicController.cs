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
using MarkSecuritiesDataLayer;

namespace MarkSecurities.Controllers
{

    public class OlympicController : ApiController
    {
        private MarkSecuritiesModelEx db = new MarkSecuritiesModelEx();

        // GET: api/Olympic
        public IQueryable<vIsAAA> GetvIsAAAs()
        {
            return db.vIsAAAs;
        }

        // GET: api/Olympic/5
        [ResponseType(typeof(vIsAAA))]
        public async Task<IHttpActionResult> GetvIsAAA(string id)
        {
            vIsAAA vIsAAA = await db.vIsAAAs.FindAsync(id);
            if (vIsAAA == null)
            {
                return NotFound();
            }

            return Ok(vIsAAA);
        }

        // PUT: api/Olympic/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutvIsAAA(string id, vIsAAA vIsAAA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vIsAAA.SecurityCode)
            {
                return BadRequest();
            }

            db.Entry(vIsAAA).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAAExists(id))
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

        // POST: api/Olympic
        [ResponseType(typeof(vIsAAA))]
        public async Task<IHttpActionResult> PostvIsAAA(vIsAAA vIsAAA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vIsAAAs.Add(vIsAAA);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (vIsAAAExists(vIsAAA.SecurityCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vIsAAA.SecurityCode }, vIsAAA);
        }

        // DELETE: api/Olympic/5
        [ResponseType(typeof(vIsAAA))]
        public async Task<IHttpActionResult> DeletevIsAAA(string id)
        {
            vIsAAA vIsAAA = await db.vIsAAAs.FindAsync(id);
            if (vIsAAA == null)
            {
                return NotFound();
            }

            db.vIsAAAs.Remove(vIsAAA);
            await db.SaveChangesAsync();

            return Ok(vIsAAA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIsAAAExists(string id)
        {
            return db.vIsAAAs.Count(e => e.SecurityCode == id) > 0;
        }
    }
}