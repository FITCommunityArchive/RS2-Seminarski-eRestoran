using eRestoran.Api.VM;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace eRestoran.Api.Controllers
{
    public class StoloviController : ApiController
    {
        MyContext ctx = new MyContext();

        [ResponseType(typeof(List<Sto>))]
        [HttpGet]
        [Route("api/get/stolovi")]
        public IHttpActionResult Index()
        {
            List<Sto> model = ctx.Stolovi.ToList();
            return Ok(model);
        }

        [HttpGet]
        [Route("api/get/osvjezistolove")]
        public IHttpActionResult ProvjeriRezervacije()
        {
            var rezervisaniStolovi =
                ctx.Rezervacija.Where(x => (x.datumVrijemeOd.Day == DateTime.Now.Day && x.datumVrijemeOd.Month == DateTime.Now.Month && x.datumVrijemeOd.Year == DateTime.Now.Year)
                && (((DateTime.Now.Hour - x.datumVrijemeOd.Hour) == 0) &&
                ((DateTime.Now.Minute - x.datumVrijemeOd.Minute) <= 15 && (DateTime.Now.Minute - x.datumVrijemeOd.Minute) >= -30))).ToList()
               .Select(x => new StoloviRezervacijaVM()
               {
                   StoId = x.StoId,
                   IsSlobodan = false,
                   RedniBrojStola = x.Sto.RedniBroj,
                   RezervacijaId = x.Id,
                   DatumOd = x.datumVrijemeOd
               })
               .ToList();

            foreach (var x in rezervisaniStolovi)
            {
                Sto sto = ctx.Stolovi.Where(y => y.Id == x.StoId).SingleOrDefault();
                sto.IsSlobodan = false;
                Rezervacija rezervacija = ctx.Rezervacija.Where(y => y.Id == x.RezervacijaId).FirstOrDefault();
                ctx.Rezervacija.Remove(rezervacija);
                ctx.SaveChanges();
            }
            var slobodniStolovi = ctx.Rezervacija.ToList().Where(x => !rezervisaniStolovi.Any(y => y.StoId == x.Id)).ToList();
            foreach (var x in slobodniStolovi)
            {
                Sto sto = ctx.Stolovi.Where(y => y.Id == x.StoId).SingleOrDefault();
                sto.IsSlobodan = true;
                ctx.Rezervacija.Remove(x);
                ctx.SaveChanges();
            }


            return Ok();
        }


        [ResponseType(typeof(List<Sto>))]
        [HttpPost]
        [Route("api/post/rezervacijestolova")]
        public IHttpActionResult RezervacijeStolova([FromBody] DateTime datum)
        {
            var rezervisaniStolovi =
               ctx.Rezervacija
               .Where(x => (x.datumVrijemeOd.Day == datum.Day && x.datumVrijemeOd.Month == datum.Month && x.datumVrijemeOd.Year == datum.Year)
               && (((datum.Hour - x.datumVrijemeOd.Hour) == 0) &&
               ((datum.Minute - x.datumVrijemeOd.Minute) <= 15 && (datum.Minute - x.datumVrijemeOd.Minute) >= -30)))
               .ToList()
               .Select(x => new Sto()
               {
                   Id = x.StoId,
                   IsSlobodan = false,
                   RedniBroj = x.Sto.RedniBroj
               })
               .ToList();
            var slobodniStolovi = ctx.Stolovi.ToList().Where(x => !rezervisaniStolovi.Any(y => y.Id == x.Id)).ToList();

            return Ok(slobodniStolovi.Union(rezervisaniStolovi));
        }

        [HttpPost]
        [Route("api/post/oznacisto")]
        public IHttpActionResult OznaciSto([FromBody] int Id)
        {
            Sto sto = ctx.Stolovi.Where(x => x.RedniBroj == Id).SingleOrDefault();
            if (sto != null)
            {
                ctx.Entry(sto).Entity.IsSlobodan = false;
                ctx.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("api/post/oslobodisto")]
        public IHttpActionResult OslobodiSto([FromBody] int Id)
        {
            Sto sto = ctx.Stolovi.Where(x => x.RedniBroj == Id).SingleOrDefault();
            if (sto != null)
            {
                ctx.Entry(sto).Entity.IsSlobodan = true;
                ctx.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult Rezervacija()
        {
            //ako je klijent ili konobar, on moze ovo vidjeti 
            List<Sto> model = ctx.Stolovi.ToList();
            return Ok(model);
        }

        [HttpPost]
        [Route("api/post/rezervisi/{stoId}")]
        public IHttpActionResult Rezervisi(int stoId, [FromBody] DateTime datumOd)
        {
            if (ModelState.IsValid)
            {
                int sto = stoId;
                DateTime datum = datumOd;
                Rezervacija rezervacija = new Rezervacija();
                rezervacija.datumVrijemeOd = datumOd;
                rezervacija.StoId = ctx.Stolovi.FirstOrDefault(x => x.RedniBroj == sto).Id;
                rezervacija.datumVrijemeDo = datumOd.AddHours(2);
                rezervacija.KlijentId = ctx.Klijenti.First().Id; // PROMJENITI
                ctx.Rezervacija.Add(rezervacija);
                ctx.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }
        //}
    }
}
