using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using eRestoran.Api.Helper;
using eRestoran.PCL.VM;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;

namespace eRestoran.Api.Controllers
{
    public class NalogController : ApiController
    {
        private MyContext ctx = new MyContext();

        // GET: api/Nalog
        //public IQueryable<Zaposlenik> GetKorisnici()
        //{
        //    return ctx.Korisnici;
        //}

        //// GET: api/Nalog/5
        [ResponseType(typeof(NaloziVM))]
        public IHttpActionResult GetNaloge()
        {
            var model = new NaloziVM();

            model.Nalozi = ctx.Klijenti.Select(x => new NaloziVM.NalogsRow
            {
                Username = x.Username,
                ImePrezime = x.Ime + " " + x.Prezime,
                Telefon = x.Telefon,
                Id = x.Id,
                Zaposlenik = "NE"
            }).ToList();
            model.Nalozi.AddRange(ctx.Zaposlenici.Where(x => x.Status != StatusZaposlenika.Otpusten).Select(x => new NaloziVM.NalogsRow
            {
                Username = x.Username,
                ImePrezime = x.Ime + " " + x.Prezime,
                Telefon = x.Telefon,
                Id = x.Id,
                Zaposlenik = "DA"
            }).ToList());

            return Ok(model.Nalozi);
        }

        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult GetNaloge(int id)
        {
            if (ctx.Zaposlenici.Where(x => x.Id == id).SingleOrDefault() != null)
            {
                ZaposlenikVM zap = ctx.Zaposlenici.Where(x => x.Id == id).Select(x => new ZaposlenikVM
                {
                    Email = x.Email,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Telefon = x.Telefon,
                    Username = x.Username,
                    Id = x.Id,
                    TipKorisnika = x.TipKorisnika,
                    Adresa = x.Adresa,
                    Plata = x.Plata,
                    Status = x.Status,
                    DatumRodjenja = x.DatumRodjenja,
                    DatumZaposlenja = x.DatumZaposlenja,
                    JMBG = x.Jmbg,
                    Password = x.Password

                }).SingleOrDefault();
                return Ok(zap);
            }
            return NotFound();
        }
        //getKlijent
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult GetNalogeKlijent(int id)
        {
            if (ctx.Klijenti.Where(x => x.Id == id).SingleOrDefault() != null)
            {
                KlijentVM zap = ctx.Klijenti.Where(x => x.Id == id).Select(x => new KlijentVM
                {
                    Email = x.Email,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Telefon = x.Telefon,
                    Username = x.Username,
                    Id = x.Id,
                    TipKorisnika = (int)x.TipKorisnika,
                    Password = x.Password

                }).SingleOrDefault();
                return Ok(zap);
            }
            return NotFound();
        }

        // PUT: api/Nalog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZaposlenik(int id, Zaposlenik zaposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposlenik.Id)
            {
                return BadRequest();
            }
            zaposlenik.Password = CryptoHelper.GetMd5Hash(zaposlenik.Password);
            zaposlenik.DatumPrijave = DateTime.Now;
            ctx.Entry(zaposlenik).State = EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposlenikExists(id))
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
        //put KLIJENT 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijent(int id, Klijent klijent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klijent.Id)
            {
                return BadRequest();
            }
            klijent.DatumPrijave = DateTime.Now;
            klijent.Password = CryptoHelper.GetMd5Hash(klijent.Password);
            ctx.Entry(klijent).State = EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposlenikExists(id))
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

        // POST: api/Nalog
        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult PostZaposlenik(Zaposlenik model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.DatumPrijave = DateTime.Now;
            Korisnik k = model;
            k.Password = CryptoHelper.GetMd5Hash(k.Password);
            ctx.Korisnici.Add(k);

            ctx.Zaposlenici.Add(model);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
        // klijent
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult PostKlijent(Klijent model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.DatumPrijave = DateTime.Now;
            Korisnik k = model;
            k.Password = CryptoHelper.GetMd5Hash(k.Password);
            ctx.Korisnici.Add(k);

            ctx.Korisnici.Add(model);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // DELETE: api/Nalog/5
        [ResponseType(typeof(Zaposlenik))]
        public IHttpActionResult DeleteZaposlenik(int id)
        {
            Zaposlenik zaposlenik = ctx.Zaposlenici.Find(id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            ctx.Korisnici.Remove(zaposlenik);
            ctx.SaveChanges();

            return Ok(zaposlenik);
        }
        //delete klijent
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult DeleteKlijent(int id)
        {
            Klijent zaposlenik = ctx.Klijenti.Find(id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            ctx.Korisnici.Remove(zaposlenik);
            ctx.SaveChanges();

            return Ok(zaposlenik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZaposlenikExists(int id)
        {
            return ctx.Korisnici.Count(e => e.Id == id) > 0;
        }
    }
}