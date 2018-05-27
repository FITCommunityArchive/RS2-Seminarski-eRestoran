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
    public class JeloController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Jelo
        public IQueryable<Jelo> GetJelo()
        {
            return db.Jelo;
        }

        // GET: api/Jelo/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult GetJelo(int id)
        {
            Jelo jelo = db.Jelo.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jelo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJelo(int id, Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jelo.Id)
            {
                return BadRequest();
            }

            db.Entry(jelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeloExists(id))
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

        // POST: api/Jelo
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult PostJelo(Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jeloStavke = jelo.JelaStavke.ToList();
           
            if (jelo.Id == 0)
            {
                jelo.JelaStavke.Clear();

                db.Jelo.Add(jelo);
                db.SaveChanges();
                jeloStavke.ForEach(x => x.JeloId = jelo.Id);
                db.JelaStavke.AddRange(jeloStavke);
                db.SaveChanges();
            }
            else
            {
                jelo.JelaStavke = jeloStavke;
                db.Entry(jelo).State = EntityState.Modified;
                foreach (var stavka in jelo.JelaStavke)
                {
                    db.Entry(stavka).State = EntityState.Modified;
                }
                //db.Entry(jelo.JelaStavke).State = EntityState.Modified;
                db.SaveChanges();
            }

           

            return CreatedAtRoute("DefaultApi", new { id = jelo.Id }, jelo);
        }

        // DELETE: api/Jelo/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult DeleteJelo(int id)
        {
            Jelo jelo = db.Jelo.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            db.Jelo.Remove(jelo);
            db.SaveChanges();

            return Ok(jelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JeloExists(int id)
        {
            return db.Jelo.Count(e => e.Id == id) > 0;
        }
    }
}