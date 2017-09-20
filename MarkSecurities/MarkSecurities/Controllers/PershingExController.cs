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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Query;
using MarkSecuritiesDataLayer;

namespace MarkSecurities.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MarkSecuritiesDataLayer;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<vIsAAA1>("PershingEx");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PershingExController : ODataController
    {
        private MarkSecuritiesModelEx db = new MarkSecuritiesModelEx();

        // GET: odata/PershingEx
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<vIsAAA1> GetPershingEx()
        {
            return db.vIsAAA1;
        }

        // GET: odata/PershingEx(5)
        [EnableQuery]
        public SingleResult<vIsAAA1> GetvIsAAA1([FromODataUri] string key)
        {
            return SingleResult.Create(db.vIsAAA1.Where(vIsAAA1 => vIsAAA1.CUSIP == key));
        }

        // PUT: odata/PershingEx(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<vIsAAA1> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vIsAAA1 vIsAAA1 = await db.vIsAAA1.FindAsync(key);
            if (vIsAAA1 == null)
            {
                return NotFound();
            }

            patch.Put(vIsAAA1);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAA1Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vIsAAA1);
        }

        // POST: odata/PershingEx
        public async Task<IHttpActionResult> Post(vIsAAA1 vIsAAA1)
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

            return Created(vIsAAA1);
        }

        // PATCH: odata/PershingEx(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<vIsAAA1> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vIsAAA1 vIsAAA1 = await db.vIsAAA1.FindAsync(key);
            if (vIsAAA1 == null)
            {
                return NotFound();
            }

            patch.Patch(vIsAAA1);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAA1Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vIsAAA1);
        }

        // DELETE: odata/PershingEx(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            vIsAAA1 vIsAAA1 = await db.vIsAAA1.FindAsync(key);
            if (vIsAAA1 == null)
            {
                return NotFound();
            }

            db.vIsAAA1.Remove(vIsAAA1);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIsAAA1Exists(string key)
        {
            return db.vIsAAA1.Count(e => e.CUSIP == key) > 0;
        }
    }
}
