
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using eRestoran.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRestoran.Areas.ModulAdministracija.Controllers
{
    public class PonudaAdministratorController : Controller
    {
        MyContext ctx = new MyContext();
        // GET: PonudaAdministrator
        public ActionResult PrikaziPonudu()
        {
            PonudaVM model = new PonudaVM();
            model.Pica = ctx.Proizvodi.Where(x => x.TipProizvoda.Naziv == "Pica").Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                Naziv = x.Naziv
            }).ToList();
            model.Ponuda = ctx.Jelo.Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = "Jela",
                KolicinaString="N/A",
                Cijena = x.Cijena,
                Naziv = x.Naziv,

            }).ToList();

            model.Ponuda.AddRange(model.Pica);

            return View(model);
        }
        public ActionResult PrikaziJela()
        {
           
            PonudaVM model = new PonudaVM();
            model.Jela = ctx.Jelo.Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = "Jela",
                KolicinaString="N/A",
                Cijena = x.Cijena,
                Naziv = x.Naziv,

            }).ToList();
            return View(model);
        }
        public ActionResult PrikaziPica()
        {
          
            PonudaVM model = new PonudaVM();
            model.Pica = ctx.Proizvodi.Where(x => x.TipProizvoda.Naziv == "Pica").Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                Naziv = x.Naziv
            }).ToList();
            return View(model);
        }
        public ActionResult Uredi(int urediId, string kategorija)
        {
           
            PonudaUrediVM model;
            if (kategorija == "Pica")
            {
                model = ctx.Proizvodi.Where(x => x.Id == urediId).Select(x => new PonudaUrediVM
                {
                    ID = x.Id,
                    Naziv=x.Naziv,
                    Kategorija = x.TipProizvoda.Naziv,
                    Cijena = x.Cijena,
                    Kolicina = x.Kolicina

                }).SingleOrDefault();
            }
            else
            {
                return RedirectToAction("UrediJeloIzPonude", "Proizvodi", new { jeloId = urediId });
            }
          
            model.KategorijeLista = new List<SelectListItem>() 
    { 
        new SelectListItem { Text = "Pica", Value = "Pica", Selected = false },
        new SelectListItem { Text = "Jela", Value = "Jela", Selected = true }
    };

            return View(model);
        }
        public ActionResult Snimi(PonudaUrediVM model)
        {
            
            Proizvod p;
            if (!ModelState.IsValid)
                return RedirectToAction("PrikaziPonudu");
            if (model.ID == 0)
            {
                p = new Proizvod();
                ctx.Proizvodi.Add(p);
              

            }
            else
            {
                p = ctx.Proizvodi.Where(x => x.Id == model.ID).SingleOrDefault();
            }
            p.Kolicina = model.Kolicina;
            p.Naziv = model.Naziv;
            p.Cijena = model.Cijena;
            p.TipProizvodaId = model.Kategorija == "Pica" ? 3 : 2;
            ctx.SaveChanges();
            return RedirectToAction("PrikaziPonudu");
        }

        public ActionResult KriticneZalihe()
        {
           
            PrikazKriticnihZaliha model = new PrikazKriticnihZaliha();
            model.Kriticne = ctx.Proizvodi.Where(x => x.Kolicina <= x.KriticnaKolicina).Select(x => new PrikazKriticnihZaliha.KriticneZalihe
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Sifra = x.Sifra,
                Kolicina = x.Kolicina,
                Kategorija = x.TipProizvoda.Naziv
            }).ToList();

            return View(model);
        }

   
    }
}