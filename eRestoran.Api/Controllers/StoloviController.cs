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
                ctx.Rezervacija.Where(x => !x.IsDeleted && (x.datumVrijemeOd.Day == DateTime.Now.Day && x.datumVrijemeOd.Month == DateTime.Now.Month && x.datumVrijemeOd.Year == DateTime.Now.Year)
                && (((DateTime.Now.Hour - x.datumVrijemeOd.Hour) == 0) &&
                ((DateTime.Now.Minute - x.datumVrijemeOd.Minute) <= 15 && (DateTime.Now.Minute - x.datumVrijemeOd.Minute) >= -30))).ToList()
               .Select(x => new StoloviRezervacijaVM()
               {
                   StoId = x.StoId,
                   IsSlobodan = x.Sto.IsSlobodan,
                   RedniBrojStola = x.Sto.RedniBroj,
                   RezervacijaId = x.Id,
                   DatumOd = x.datumVrijemeOd
               })
               .ToList();
            foreach (var x in rezervisaniStolovi)
            {
                Sto sto = ctx.Stolovi.Where(y => y.Id == x.StoId).SingleOrDefault();
                ctx.Entry(sto).Entity.IsSlobodan = false;
                ctx.SaveChanges();
            }
            var slobodniStolovi = ctx.Rezervacija.Where(x => x.Sto.IsSlobodan == true).ToList();

            foreach (var x in slobodniStolovi)
            {
                Sto sto = ctx.Stolovi.Where(y => y.Id == x.StoId).SingleOrDefault();
                ctx.Entry(sto).Entity.IsSlobodan = true;
                var rez = ctx.Rezervacija.Where(y => y.Id == x.Id).FirstOrDefault();
                ctx.Rezervacija.Remove(rez);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [ResponseType(typeof(List<Sto>))]
        [HttpPost]
        [Route("api/post/rezervacijestolova")]
        public IHttpActionResult RezervacijeStolova([FromBody] DateTime datum)//6:00  5:14
        {
            var rezervisaniStolovi =
               ctx.Rezervacija
               .Where(x => !x.IsDeleted && (x.datumVrijemeOd.Day == datum.Day && x.datumVrijemeOd.Month == datum.Month && x.datumVrijemeOd.Year == datum.Year)
               && (((datum.Hour - x.datumVrijemeOd.Hour) <= 2) &&
               ((datum.Minute - x.datumVrijemeOd.Minute) <= 15 && (datum.Minute - x.datumVrijemeOd.Minute) >= -30)))
               .ToList()
                .Select(x => new StoloviRezervacijaVM()
                {
                    StoId = x.StoId,
                    IsSlobodan = false,
                    RedniBrojStola = x.Sto.RedniBroj,
                    RezervacijaId = x.Id,
                    DatumOd = x.datumVrijemeOd
                })
               .ToList();
            var slobodniStolovi = ctx.Stolovi.ToList().Where(x => !rezervisaniStolovi.Any(y => y.StoId == x.Id)).ToList()
                .Select(x => new StoloviRezervacijaVM()
                {
                    StoId = x.Id,
                    IsSlobodan = true,
                    RedniBrojStola = x.RedniBroj,
                    RezervacijaId = x.Id,
                    DatumOd = DateTime.MinValue
                })
               .ToList();

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
                rezervacija.KlijentId = ctx.Klijenti.First().Id;
                var rezervisaniSto = ctx.Stolovi.Where(x => x.Id == rezervacija.StoId).FirstOrDefault();
                ctx.Entry(rezervisaniSto).Entity.IsSlobodan = false;
                ctx.Rezervacija.Add(rezervacija);
                ctx.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("api/post/izbrisirezervaciju")]
        public IHttpActionResult IzbrisiRezervaciju([FromBody] int id)
        {
            if (ModelState.IsValid)
            {
                var rezervacija = ctx.Rezervacija.FirstOrDefault(x => x.Id == id);
                if(rezervacija != null)
                {
                    rezervacija.IsDeleted = true;
                    ctx.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
