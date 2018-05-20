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
using eRestoran.Api.VM;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;

namespace eRestoran.Api.Controllers
{
    public class SkladisteController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Skladiste
        public List<SkadisteVM> GetSkladista()
        {
            return db.Skladista.Select(x => new SkadisteVM
            {
                Adresa = x.Adresa,
                Id = x.Id
            }).ToList();
        }

        // GET: api/Skladiste/5
        [ResponseType(typeof(Skladiste))]
        public IHttpActionResult GetSkladiste(int id)
        {
            Skladiste skladiste = db.Skladista.Find(id);
            if (skladiste == null)
            {
                return NotFound();
            }

            return Ok(skladiste);
        }

        // PUT: api/Skladiste/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkladiste(int id, Skladiste skladiste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skladiste.Id)
            {
                return BadRequest();
            }

            db.Entry(skladiste).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkladisteExists(id))
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

        // POST: api/Skladiste
        [ResponseType(typeof(Skladiste))]
        public IHttpActionResult PostSkladiste(Skladiste skladiste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skladista.Add(skladiste);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skladiste.Id }, skladiste);
        }

        // DELETE: api/Skladiste/5
        [ResponseType(typeof(Skladiste))]
        public IHttpActionResult DeleteSkladiste(int id)
        {
            Skladiste skladiste = db.Skladista.Find(id);
            if (skladiste == null)
            {
                return NotFound();
            }

            db.Skladista.Remove(skladiste);
            db.SaveChanges();

            return Ok(skladiste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkladisteExists(int id)
        {
            return db.Skladista.Count(e => e.Id == id) > 0;
        }
    }
}