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

        public void ProvjeriRezervacije()
        {

            //bool dt = (DateTime.Now - DateTime.Now.Subtract(new TimeSpan(0, 15, 0))).Hours == 0 && ((DateTime.Now - DateTime.Now.Subtract(new TimeSpan(0, 15, 0))).Minutes <= 15) && (DateTime.Now - DateTime.Now.Subtract(new TimeSpan(0, 15, 0))).Minutes >= -15;

            List<int> rezervisaniStolovi =
                ctx.Rezervacija.Where(x => (x.datumVrijemeOd.Day == DateTime.Now.Day && x.datumVrijemeOd.Month == DateTime.Now.Month && x.datumVrijemeOd.Year == DateTime.Now.Year)
                && (((DateTime.Now.Hour - x.datumVrijemeOd.Hour) == 0) &&
                ((DateTime.Now.Minute - x.datumVrijemeOd.Minute) <= 15 && (DateTime.Now.Minute - x.datumVrijemeOd.Minute) >= -30)))
                .Select(x => x.StoId).ToList();
            if (rezervisaniStolovi.Count != 0)
            {
                foreach (int x in rezervisaniStolovi)
                {
                    Sto sto = ctx.Stolovi.Where(y => y.Id == x).SingleOrDefault();
                    sto.IsSlobodan = false;
                    ctx.SaveChanges();
                }
            }
            return;
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
        //    public ActionResult Rezervisi(int stoId, DateTime datumOd)
        //    {
        //        if (Autentifikacija.klijentSesija == null)
        //        {
        //            return RedirectToAction("Index", "Account", new { area = "" });

        //        }
        //        if (Autentifikacija.klijentSesija != null)
        //        {
        //            if (Autentifikacija.klijentSesija.TipKorisnika == TipKorisnika.Klijent)
        //            {
        //                if (ModelState.IsValid)
        //                {
        //                    int sto = stoId;
        //                    DateTime datum = datumOd;
        //                    Rezervacija rezervacija = new Rezervacija();
        //                    rezervacija.datumVrijemeOd = datumOd;
        //                    rezervacija.StoId = stoId;
        //                    rezervacija.datumVrijemeDo = datumOd.AddHours(1);
        //                    rezervacija.KlijentId = Autentifikacija.klijentSesija.Id;
        //                    ctx.Rezervacija.Add(rezervacija);
        //                    ctx.SaveChanges();
        //                    return RedirectToAction("Index", "Home", new { poruka = "Uspjesna rezervacija!" });
        //                }


        //            }


        //        }

        //        return RedirectToAction("Index", "Account", new { area = "" });


        //    }
        //}
    }
}
