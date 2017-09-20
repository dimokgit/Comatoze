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
    public class PershingController : ApiController
    {
        private MarkSecuritiesModelEx db = new MarkSecuritiesModelEx();

        // GET: api/Pershing
        public IQueryable<vIsAAA1> GetvIsAAA1()
        {
            return db.vIsAAA1;
        }

        // GET: api/Pershing/5
        [ResponseType(typeof(vIsAAA1))]
        public async Task<IHttpActionResult> GetvIsAAA1(string id)
        {
            vIsAAA1 vIsAAA1 = await db.vIsAAA1.FindAsync(id);
            if (vIsAAA1 == null)
            {
                return NotFound();
            }

            return Ok(vIsAAA1);
        }

        // PUT: api/Pershing/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutvIsAAA1(string id, vIsAAA1 vIsAAA1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vIsAAA1.CUSIP)
            {
                return BadRequest();
            }

            db.Entry(vIsAAA1).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAA1Exists(id))
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

        // POST: api/Pershing
        [ResponseType(typeof(vIsAAA1))]
        public async Task<IHttpActionResult> PostvIsAAA1(vIsAAA1 vIsAAA1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vIsAAA1.Add(vIsAAA1);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (vIsAAA1Exists(vIsAAA1.CUSIP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vIsAAA1.CUSIP }, vIsAAA1);
        }

        // DELETE: api/Pershing/5
        [ResponseType(typeof(vIsAAA1))]
        public async Task<IHttpActionResult> DeletevIsAAA1(string id)
        {
            vIsAAA1 vIsAAA1 = await db.vIsAAA1.FindAsync(id);
            if (vIsAAA1 == null)
            {
                return NotFound();
            }

            db.vIsAAA1.Remove(vIsAAA1);
            await db.SaveChangesAsync();

            return Ok(vIsAAA1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIsAAA1Exists(string id)
        {
            return db.vIsAAA1.Count(e => e.CUSIP == id) > 0;
        }
    }
}