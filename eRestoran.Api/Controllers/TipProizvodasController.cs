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
    public class TipProizvodasController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/TipProizvodas
        public List<TipProizvodaVM> GetTipoviProizvoda()
        {
            return db.TipoviProizvoda.Select(x => new TipProizvodaVM
            {
                Naziv = x.Naziv,
                Id = x.Id,
                mjernaJedinica=x.MjernaJedinica
            }).ToList();
        }

        // GET: api/TipProizvodas/5
        [ResponseType(typeof(TipProizvodaVM))]
        public IHttpActionResult GetTipProizvoda(int id)
        {
            TipProizvodaVM tipProizvoda = db.TipoviProizvoda.Where(x=>x.Id==id).Select(x=> new TipProizvodaVM {
                Naziv=x.Naziv,
                Id=x.Id,
                mjernaJedinica=x.MjernaJedinica

            }).FirstOrDefault();
            if (tipProizvoda == null)
            {
                return NotFound();
            }

            return Ok(tipProizvoda);
        }

        // PUT: api/TipProizvodas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipProizvoda(int id, TipProizvoda tipProizvoda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipProizvoda.Id)
            {
                return BadRequest();
            }

            db.Entry(tipProizvoda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipProizvodaExists(id))
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

        // POST: api/TipProizvodas
        [ResponseType(typeof(TipProizvoda))]
        public IHttpActionResult PostTipProizvoda(TipProizvoda tipProizvoda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoviProizvoda.Add(tipProizvoda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipProizvoda.Id }, tipProizvoda);
        }

        // DELETE: api/TipProizvodas/5
        [ResponseType(typeof(TipProizvoda))]
        public IHttpActionResult DeleteTipProizvoda(int id)
        {
            TipProizvoda tipProizvoda = db.TipoviProizvoda.Find(id);
            if (tipProizvoda == null)
            {
                return NotFound();
            }

            db.TipoviProizvoda.Remove(tipProizvoda);
            db.SaveChanges();

            return Ok(tipProizvoda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipProizvodaExists(int id)
        {
            return db.TipoviProizvoda.Count(e => e.Id == id) > 0;
        }
    }
}