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
    public class NarudzbaController : ApiController
    {
        private MyContext ctx = new MyContext();

        // GET: api/Narudzba
        [HttpPost]
        [Route("api/checkout/{stoId}")]
        public IHttpActionResult Checkout(int? stoId, [FromBody]CartIndexVM cart)
        {

            if (cart.Jela.Count == 0 && cart.Pica.Count == 0)
            {

                //return RedirectToAction("Index", "Cart");

            }

            //if (Autentifikacija.klijentSesija == null)
            //{
            //    TempData["notAuthenticated"] = "Please sign in";
            //    return RedirectToAction("Login", "Account");
            //}
            Narudzba narudzba = new Narudzba();
            int zaposlenikId = 0;
            int klijentId = 0;
            if (stoId != null) { narudzba.StoId = (int)stoId; }
            ctx.Narudzbe.Add(narudzba);
            ctx.SaveChanges();
            //if (Autentifikacija.klijentSesija != null)
            //{
            //    if (Autentifikacija.klijentSesija.TipKorisnika == TipKorisnika.Konobar)
            //    {
            //        zaposlenikId = Autentifikacija.klijentSesija.Id;
            //        narudzba.ZaposlenikId = zaposlenikId;
            //        narudzba.Sifra = "Z" + zaposlenikId + "N" + narudzba.Id;

            //    }
            //    if (Autentifikacija.klijentSesija.TipKorisnika == TipKorisnika.Klijent)
            //    {
            //        klijentId = Autentifikacija.klijentSesija.Id;
            //        narudzba.KlijentId = klijentId;
            //        narudzba.Sifra = "K" + klijentId + "N" + narudzba.Id;

            //    }
            //}
            //else
            //{
            //    narudzba.Sifra = "K" + klijentId + "N" + narudzba.Id;
            //}
            narudzba.Sifra = Guid.NewGuid().ToString();
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
            //if (Autentifikacija.klijentSesija != null)
            //{
            //    if (Autentifikacija.klijentSesija.TipKorisnika == TipKorisnika.Konobar)
            //    {
            //        racun.ZaposlenikId = Autentifikacija.klijentSesija.Id;
            //    }
            //    if (Autentifikacija.klijentSesija.TipKorisnika == TipKorisnika.Klijent)
            //    {
            //        racun.KlijentId = Autentifikacija.klijentSesija.Id;
            //    }
            //}
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