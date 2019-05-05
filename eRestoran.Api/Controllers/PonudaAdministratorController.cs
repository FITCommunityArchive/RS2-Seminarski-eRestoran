using eRestoran.Data.DAL;
using eRestoran.PCL.VM;
using eRestoran.VM;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using static eRestoran.VM.PrikazKriticnihZaliha;

namespace eRestoran.Areas.ModulAdministracija.Controllers
{
    public class PonudaAdministratorController : ApiController
    {
        MyContext ctx = new MyContext();
        // GET: PonudaAdministrator

        public List<PonudaVM.PonudaInfo> GetPonuda()
        {
            MyContext ctx = new MyContext();
            PonudaVM model = new PonudaVM();
            model.Pica = ctx.Proizvodi.Where(x => x.TipProizvoda.Naziv == "Pica").Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                Naziv = x.Naziv,
                imageUrl = x.SlikaUrl
            }).ToList();

            model.Ponuda = ctx.Jelo.Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = "Jela",
                KolicinaString = "N/A",
                Cijena = x.Cijena,
                Naziv = x.Naziv,
                imageUrl = x.SlikaUrl

            }).ToList();

            model.Ponuda.AddRange(model.Pica);
            return model.Ponuda;
        }

        public List<PonudaVM.PonudaInfo> GetJela()
        {

            PonudaVM model = new PonudaVM();
            model.Jela = ctx.Jelo.Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = "Jela",
                KolicinaString = "N/A",
                Cijena = x.Cijena,
                Naziv = x.Naziv,
                imageUrl = x.SlikaUrl

            }).ToList();
            return model.Jela;
        }

        [Route("api/ponuda/getjelo/{id}")]
        [HttpGet]
        [ResponseType(typeof(UrediJelo))]
        public IHttpActionResult GetJelo(int id)
        {
            UrediJelo model = new UrediJelo();
            model = ctx.JelaStavke.Where(x => x.JeloId == id).Select(x => new UrediJelo
            {
                JeloId = x.JeloId,
                Menu = x.Jelo.Menu,
                Cijena = x.Jelo.Cijena,
                Naziv = x.Jelo.Naziv,
                Sifra = x.Jelo.Sifra,
                SlikaUrl = x.Jelo.SlikaUrl,
                ListaStavki = ctx.JelaStavke.Where(y => y.JeloId == id).Select(y => new ProizvodStavka
                {
                    Naziv = y.Proizvod.Naziv,
                    Cijena = y.Proizvod.Cijena.ToString(),
                    ProizvodId = y.ProizvodId,
                    TipProizvoda = y.Proizvod.TipProizvoda.Naziv,
                    Kolicina = y.Kolicina.ToString(),
                }).ToList()


            }).FirstOrDefault();
            return Ok(model);
        }

        public List<PonudaVM.PonudaInfo> GetPica()
        {

            PonudaVM model = new PonudaVM();
            model.Pica = ctx.Proizvodi.Where(x => x.TipProizvoda.Naziv == "Pica").Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                Naziv = x.Naziv,
                KolicinaString = x.Kolicina.ToString()
            }).ToList();
            return model.Pica;
        }

        public PonudaVM.PonudaInfo GetPice(int id)
        {

            PonudaVM.PonudaInfo model = new PonudaVM.PonudaInfo();
            model = ctx.Proizvodi.Where(x => x.TipProizvoda.Naziv == "Pica" && x.Id == id).Select(x => new PonudaVM.PonudaInfo
            {
                Id = x.Id,
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                Naziv = x.Naziv,
                KolicinaString = x.Kolicina.ToString()
            }).FirstOrDefault();
            return model;
        }

        [Route("api/ponuda/GetProizvodBySifra/{sifra}")]
        public PonudaVM.PonudaInfo GetProizvodBySifra(string sifra)
        {

            PonudaVM.PonudaInfo model = new PonudaVM.PonudaInfo();
            var pice = ctx.Proizvodi.FirstOrDefault(x => x.TipProizvoda.Naziv == "Pica" && x.Sifra.Equals(sifra, System.StringComparison.InvariantCultureIgnoreCase));
            var jelo = ctx.Jelo.FirstOrDefault(x => x.Sifra.Equals(sifra, System.StringComparison.InvariantCultureIgnoreCase));
            if (pice != null)
            {
                model.Id = pice.Id;
                model.Kategorija = pice.TipProizvoda.Naziv;
                model.Cijena = pice.Cijena;
                model.Kolicina = pice.Kolicina;
                model.Naziv = pice.Naziv;
                model.KolicinaString = pice.Kolicina.ToString();
                model.IsJelo = false;
            }
            else if (jelo != null)
            {
                var nemaSastojaka = jelo.JelaStavke.Any(x => x.Proizvod.Kolicina == 0);
                model.Id = jelo.Id;
                model.Kategorija = jelo.Naziv;
                model.Cijena = jelo.Cijena;
                model.Kolicina = nemaSastojaka ? 0 : 1;
                model.Naziv = jelo.Naziv;
                model.KolicinaString = nemaSastojaka ? "Nema na stanju" : "Ima na stanju";
                model.IsJelo = true;
            }

            return model;
        }

        public List<KriticneZalihe> GetKriticneZalihe()
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

            return model.Kriticne;
        }
    }
}