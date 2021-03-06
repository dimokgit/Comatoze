﻿using System;
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
    builder.EntitySet<vIsAAA>("OlympicEx");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    /// <summary>
    /// 
    /// </summary>
    public class OlympicExController : ODataController
    {
        private MarkSecuritiesModelEx db = new MarkSecuritiesModelEx();

        // GET: odata/OlympicEx
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        //[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]        
        //public IQueryable<vIsAAA> GetOlympicEx()
        //{
        //    return db.vIsAAAs;
        //}
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]        
        public IQueryable<vIsAAA> GetOlympicEx()
        {
            return db.vIsAAAs;
        }
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        // GET: odata/OlympicEx(5)
        [EnableQuery]
        public SingleResult<vIsAAA> GetvIsAAA([FromODataUri] string key)
        {
            return SingleResult.Create(db.vIsAAAs.Where(vIsAAA => vIsAAA.SecurityCode == key));
        }
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        // PUT: odata/OlympicEx(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<vIsAAA> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vIsAAA vIsAAA = await db.vIsAAAs.FindAsync(key);
            if (vIsAAA == null)
            {
                return NotFound();
            }

            patch.Put(vIsAAA);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAAExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(vIsAAA);
        }
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        // POST: odata/OlympicEx
        public async Task<IHttpActionResult> Post(vIsAAA vIsAAA)
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

            return Created(vIsAAA);
        }
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        // PATCH: odata/OlympicEx(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<vIsAAA> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vIsAAA vIsAAA = await db.vIsAAAs.FindAsync(key);
            if (vIsAAA == null)
            {
                return NotFound();
            }

            patch.Patch(vIsAAA);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vIsAAAExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(vIsAAA);
        }
        /// <summary>
        /// some
        /// </summary>
        /// <returns></returns>
        // DELETE: odata/OlympicEx(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            vIsAAA vIsAAA = await db.vIsAAAs.FindAsync(key);
            if (vIsAAA == null)
            {
                return NotFound();
            }

            db.vIsAAAs.Remove(vIsAAA);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIsAAAExists(string key)
        {
            return db.vIsAAAs.Count(e => e.SecurityCode == key) > 0;
        }
    }
}
