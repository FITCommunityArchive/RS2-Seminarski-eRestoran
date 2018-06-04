using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;

namespace eRestoran.Api.Controllers
{
    public class NarudzbaController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Narudzba
        public IQueryable<Narudzba> GetNarudzbe()
        {
            return db.Narudzbe;
        }

        // GET: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult GetNarudzba(int id)
        {
            Narudzba narudzba = db.Narudzbe.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return Ok(narudzba);
        }

        // PUT: api/Narudzba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzba(int id, Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzba.Id)
            {
                return BadRequest();
            }

            db.Entry(narudzba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaExists(id))
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

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult PostNarudzba(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Narudzbe.Add(narudzba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = narudzba.Id }, narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult DeleteNarudzba(int id)
        {
            Narudzba narudzba = db.Narudzbe.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            db.Narudzbe.Remove(narudzba);
            db.SaveChanges();

            return Ok(narudzba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaExists(int id)
        {
            return db.Narudzbe.Count(e => e.Id == id) > 0;
        }
    }
}