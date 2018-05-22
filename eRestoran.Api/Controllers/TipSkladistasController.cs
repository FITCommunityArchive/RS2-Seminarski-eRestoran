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
    public class TipSkladistasController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/TipSkladistas
        public List<TipProizvodaVM> GetTipoviSkladista()
        {
            return db.TipoviSkladista.Select(x => new TipProizvodaVM
            {
                Naziv=x.Naziv,
                Id=x.Id
            }).ToList();
        }

        // GET: api/TipSkladistas/5
        [ResponseType(typeof(TipProizvodaVM))]
        public IHttpActionResult GetTipSkladista(int id)
        {
            TipProizvodaVM tipSkladista = db.TipoviSkladista.Where(x=>x.Id==id).Select(x=>new TipProizvodaVM {
                Naziv=x.Naziv,
                Id=x.Id
            }).FirstOrDefault();
            if (tipSkladista == null)
            {
                return NotFound();
            }

            return Ok(tipSkladista);
        }

        // PUT: api/TipSkladistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipSkladista(int id, TipSkladista tipSkladista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipSkladista.Id)
            {
                return BadRequest();
            }

            db.Entry(tipSkladista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipSkladistaExists(id))
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

        // POST: api/TipSkladistas
        [ResponseType(typeof(TipSkladista))]
        public IHttpActionResult PostTipSkladista(TipSkladista tipSkladista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoviSkladista.Add(tipSkladista);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipSkladista.Id }, tipSkladista);
        }

        // DELETE: api/TipSkladistas/5
        [ResponseType(typeof(TipSkladista))]
        public IHttpActionResult DeleteTipSkladista(int id)
        {
            TipSkladista tipSkladista = db.TipoviSkladista.Find(id);
            if (tipSkladista == null)
            {
                return NotFound();
            }

            db.TipoviSkladista.Remove(tipSkladista);
            db.SaveChanges();

            return Ok(tipSkladista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipSkladistaExists(int id)
        {
            return db.TipoviSkladista.Count(e => e.Id == id) > 0;
        }
    }
}