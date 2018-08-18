using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using eRestoran.Api.Helper;
using eRestoran.PCL.VM;

namespace eRestoran.Api.Controllers
{
    public class KorisniciController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/Korisnici
        public List<Korisnik> GetKorisnici()
        {
            try
            {
                return db.Korisnici.ToList();
            }
            catch (Exception e)
            {
                var xx = e.Message;
                return null;
            }
        }

        // GET: api/Korisnici/5
        public Korisnik GetKorisnik(int id)
        {
            Korisnik korisnik = db.Korisnici.Find(id);

            return korisnik;
        }

        [ResponseType(typeof(Korisnik))]
        [Route("api/korisnici/korisnik/{username}")]
        public IHttpActionResult GetKorisnikUsername(string username)
        {
            Korisnik korisnik = db.Korisnici.Where(x => x.Username == username).FirstOrDefault();
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT: api/Korisnici/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisnik(int id, Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnik.Id)
            {
                return BadRequest();
            }

            db.Entry(korisnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisnici
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult PostKorisnik(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Korisnici.Add(korisnik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = korisnik.Id }, korisnik);
        }

        // DELETE: api/Korisnici/5
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult DeleteKorisnik(int id)
        {
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            db.Korisnici.Remove(korisnik);
            db.SaveChanges();

            return Ok(korisnik);
        }

        [ResponseType(typeof(string))]
        [Route("api/korisnici/login/")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] AuthVM auth)
        {
            var korisnik = GetUser(auth.Email, CryptoHelper.GetMd5Hash(auth.Password));

            if (korisnik != null)
            {
                var token = JwtManager.GenerateToken(korisnik);
                return Ok(new VerifikovanKorisnikVM()
                {
                    Id = korisnik.Id,
                    ImePrezime = korisnik.Ime + " " + korisnik.Prezime,
                    Token = token,
                    TipKorisnika = korisnik.TipKorisnika
                });
            }

            return StatusCode(HttpStatusCode.Unauthorized);
        }

        private Korisnik GetUser(string email, string password)
        {
            try
            {
                var korisnik = db.Korisnici.FirstOrDefault(x => x.Email == email && x.Password == password);
                return korisnik;
            }
            catch (Exception e)
            {
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisnikExists(int id)
        {
            return db.Korisnici.Count(e => e.Id == id) > 0;
        }
    }
}