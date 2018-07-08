using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using eRestoran.Api.Filter;
using eRestoran.PCL.VM;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;

namespace eRestoran.Api.Controllers
{
    public class NarudzbaController : ApiController
    {
        private MyContext ctx = new MyContext();

        // GET: api/Narudzba
        [HttpPost]
        [Route("api/checkout/{stoId}")]
        public IHttpActionResult Checkout(int? stoId, [FromBody]CartIndexVM cart)
        {
            var korisnik = JwtAuthenticationAttribute.GetKorisnik(this.Request.Headers.Authorization);
            if (cart.Jela.Count == 0 && cart.Pica.Count == 0)
            {
                return BadRequest();
            }

            if (korisnik.TipKorisnika != TipKorisnika.Konobar && korisnik.TipKorisnika != TipKorisnika.Klijent)
            {
                return BadRequest();
            }

            Narudzba narudzba = new Narudzba();
            int zaposlenikId = 0;
            int klijentId = 0;
            if (stoId != null)
            {
                narudzba.StoId = (int)stoId;
            }
            ctx.Narudzbe.Add(narudzba);
            ctx.SaveChanges();

            if (korisnik.TipKorisnika == TipKorisnika.Konobar)
            {
                zaposlenikId = korisnik.Id;
                narudzba.ZaposlenikId = zaposlenikId;
                narudzba.Sifra = "Z" + zaposlenikId + "N" + narudzba.Id;

            }
            if (korisnik.TipKorisnika == TipKorisnika.Klijent)
            {
                klijentId = korisnik.Id;
                narudzba.KlijentId = klijentId;
                narudzba.Sifra = "K" + klijentId + "N" + narudzba.Id;
            }

            narudzba.StatusJela = statusNarudzbe.U_Pripremi;
            narudzba.StatusPica = statusNarudzbe.U_Pripremi;
            ctx.SaveChanges();

            List<NarudzbaStavke> narudzbaStavke = new List<NarudzbaStavke>();
            double racunTotal = 0;

            if (cart.Jela.Count != 0)
            {
                narudzbaStavke = cart.Jela.Select(x => new NarudzbaStavke
                {
                    NarudzbaId = narudzba.Id,
                    JeloId = x.Id,
                    Kolicina = x.Kolicina
                }).ToList();

                foreach (var x in cart.Jela)
                {
                    racunTotal += ctx.Jelo.Where(y => y.Id == x.Id).SingleOrDefault().Cijena * x.Kolicina;
                    List<JelaStavke> proizvodi = ctx.JelaStavke.Where(y => y.JeloId == x.Id).ToList();
                    foreach (var stavka in proizvodi)
                    {
                        ctx.Proizvodi.Where(y => y.Id == stavka.ProizvodId).SingleOrDefault().Kolicina -= stavka.Kolicina * x.Kolicina;
                        ctx.SaveChanges();
                    }
                }
            }

            if (cart.Pica.Count != 0)
            {
                narudzbaStavke.AddRange(cart.Pica.Select(x => new NarudzbaStavke
                {
                    NarudzbaId = narudzba.Id,
                    ProizvodId = x.Id,
                    Kolicina = x.Kolicina
                }).ToList());
                foreach (var x in cart.Pica)
                {
                    racunTotal += ctx.Proizvodi.Where(y => y.Id == x.Id).SingleOrDefault().Cijena * x.Kolicina;
                    ctx.Proizvodi.Where(y => y.Id == x.Id).SingleOrDefault().Kolicina -= x.Kolicina;
                    ctx.SaveChanges();
                }
            }
            ctx.NarudzbaStavke.AddRange(narudzbaStavke);
            ctx.SaveChanges();

            NarudzbaRacun racun = new NarudzbaRacun();
            racun.DatumIzdavanja = DateTime.Now;
            racun.Sifra = narudzba.Sifra;

            if (korisnik.TipKorisnika == TipKorisnika.Konobar)
            {
                racun.ZaposlenikId = korisnik.Id;
            }
            if (korisnik.TipKorisnika == TipKorisnika.Klijent)
            {
                racun.KlijentId = korisnik.Id;
            }

            racun.Iznos = racunTotal;
            racun.Id = narudzba.Id;
            ctx.Racuni.Add(racun);
            ctx.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}