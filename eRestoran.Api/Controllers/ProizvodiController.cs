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
using static eRestoran.VM.PonudaVM;

namespace eRestoran.Api.Controllers
{
    public class ProizvodiController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Proizvodi
        public IQueryable<Proizvod> GetProizvodi()
        {
            return db.Proizvodi;
        }

        // GET: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public Proizvod GetProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return null;
            }

            return proizvod;
        }
        public PonudaInfo GetProizvodVM(int id)
        {
            PonudaInfo proizvod = db.Proizvodi.Where(x => x.Id == id).Select(x => new PonudaInfo
            {
                Id = id,
                Naziv = x.Naziv,
                Kolicina = x.Kolicina,
                KolicinaString = x.Kolicina.ToString(),
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena

            }).FirstOrDefault();

            return proizvod;
        }

        // PUT: api/Proizvodi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvod.Id)
            {
                return BadRequest();
            }

            db.Entry(proizvod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
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

        // POST: api/Proizvodi
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proizvodi.Add(proizvod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proizvod.Id }, proizvod);
        }

        // DELETE: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            db.Proizvodi.Remove(proizvod);
            db.SaveChanges();

            return Ok(proizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodExists(int id)
        {
            return db.Proizvodi.Count(e => e.Id == id) > 0;
        }
    }
}