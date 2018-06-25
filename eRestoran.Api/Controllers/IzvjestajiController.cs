using eRestoran.Api.Filter;
using eRestoran.PCL.VM;
using eRestoran.Areas.ModulAdministracija.Models;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace eRestoran.Api.Controllers
{
    [JwtAuthentication(TipKorisnika.Admin)]
    public class IzvjestajiController : ApiController
    {
        MyContext ctx = new MyContext();

        public List<KorisnikInfo> GetSveNarudzbeKorisnici()
        {
            ReportsSviKorisniciNarudzbe model = new ReportsSviKorisniciNarudzbe();
            model.Klijenti = ctx.Klijenti.Select(x => new KorisnikInfo
            {
                Ime = x.Ime + " " + x.Prezime,
                Id = x.Id,
                BrojNarudzbi = ctx.Racuni.Where(y => y.KlijentId == x.Id).Count(),
                Iznos = ctx.Racuni.Where(y => y.KlijentId == x.Id).Count() != 0 ? ctx.Racuni.Where(y => y.KlijentId == x.Id).Sum(y => y.Iznos) : 0

            }).ToList();

            model.Zaposlenici = ctx.Zaposlenici.Select(x => new KorisnikInfo
            {
                Ime = x.Ime + " " + x.Prezime,
                Id = x.Id,
                BrojNarudzbi = ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Count(),
                Iznos = ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Count() != 0 ? ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Sum(y => y.Iznos) : 0
            }).ToList();
            var klijenti = model.Klijenti.Where(x => x.BrojNarudzbi != 0).ToList();
            var zaposlenici = model.Zaposlenici.Where(x => x.BrojNarudzbi != 0).ToList();

            klijenti.AddRange(zaposlenici);
            return klijenti;
        }

        public ReportsSviKorisniciNarudzbe GetSveNarudzbeKorisnici2()
        {

            ReportsSviKorisniciNarudzbe model = new ReportsSviKorisniciNarudzbe();
            model.Klijenti = ctx.Klijenti.Select(x => new KorisnikInfo
            {
                Ime = x.Ime + " " + x.Prezime,
                Id = x.Id,
                BrojNarudzbi = ctx.Racuni.Where(y => y.KlijentId == x.Id).Count(),
                Iznos = ctx.Racuni.Where(y => y.KlijentId == x.Id).Count() != 0 ? ctx.Racuni.Where(y => y.KlijentId == x.Id).Sum(y => y.Iznos) : 0

            }).ToList();

            model.Zaposlenici = ctx.Zaposlenici.Select(x => new KorisnikInfo
            {
                Ime = x.Ime + " " + x.Prezime,
                Id = x.Id,
                BrojNarudzbi = ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Count(),
                Iznos = ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Count() != 0 ? ctx.Racuni.Where(y => y.ZaposlenikId == x.Id).Sum(y => y.Iznos) : 0
            }).ToList();
            model.Klijenti = model.Klijenti.Where(x => x.BrojNarudzbi != 0).ToList();
            model.Zaposlenici = model.Zaposlenici.Where(x => x.BrojNarudzbi != 0).ToList();

            return model;
        }

        public IHttpActionResult SveNarudzbeZaposlenik(int Id)
        {
            ReportsSveNarudzbeKorisnika model = new ReportsSveNarudzbeKorisnika();
            model.Ime = ctx.Korisnici.Where(x => x.Id == Id).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault();
            model.Narudzbe = new List<ReportsSveNarudzbeKorisnikaRow>();

            model.Narudzbe = ctx.Racuni.Where(x => x.ZaposlenikId == Id)
                .Select(x => new ReportsSveNarudzbeKorisnikaRow
                {
                    NarudzbaId = x.Id,
                    Datum = ctx.Racuni.Where(y => y.Id == x.Id).FirstOrDefault().DatumIzdavanja.Day + "." +
                    ctx.Racuni.Where(y => y.Id == x.Id).FirstOrDefault().DatumIzdavanja.Month + "." +
                    ctx.Racuni.Where(y => y.Id == x.Id).FirstOrDefault().DatumIzdavanja.Year + " | " +
                    ctx.Racuni.Where(y => y.Id == x.Id).FirstOrDefault().DatumIzdavanja.Hour + ":" +
                    ctx.Racuni.Where(y => y.Id == x.Id).FirstOrDefault().DatumIzdavanja.Minute,
                    UkupnaKolicina = ctx.NarudzbaStavke.Where(y => y.NarudzbaId == x.Id).Count(),
                    UkupniIznos = x.Iznos
                }).ToList();
            foreach (var n in model.Narudzbe)
            {
                n.Proizvodi = ctx.NarudzbaStavke.Where(x => x.Narudzba.ZaposlenikId == Id && x.NarudzbaId == n.NarudzbaId).Select(x => new ProizvodInfo
                {
                    NarudzbaId = x.NarudzbaId,
                    NazivProizvoda = x.JeloId != null ? x.Jelo.Naziv : x.Proizvod.Naziv,
                    KolicinaProizvoda = x.Kolicina,
                    IznosProizvoda = x.Kolicina * (x.JeloId != null ? x.Jelo.Cijena : x.Proizvod.Cijena),
                    VrijemeNarudzbe = ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Day + "." +
                    ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Month + "." +
                    ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Year + " | " +
                    ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Hour + ":" +
                    ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Minute
                }).ToList();
            }

            return Ok(model);
        }

        public IHttpActionResult NarudzbeKlijent(int Id, string datum)
        {
            ReportsNarudzbeKorisnika model = new ReportsNarudzbeKorisnika();
            model.Ime = ctx.Korisnici.Where(x => x.Id == Id).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault();
            model.Narudzbe = new List<ReportsNarudzbeKorisnikaRow>();
            model.Datum = datum;
            string dan = datum.Split('.')[0];
            string mjesec = datum.Split('.')[1];
            string godina = datum.Split('.')[2];
            model.Narudzbe = ctx.Racuni.Where(x => x.KlijentId == Id
            && x.DatumIzdavanja.Day.ToString() == dan
            && x.DatumIzdavanja.Month.ToString() == mjesec
            && x.DatumIzdavanja.Year.ToString() == godina).Select(x => new ReportsNarudzbeKorisnikaRow
            {
                NarudzbaId = x.Id,
            }).ToList();
            foreach (var n in model.Narudzbe)
            {
                n.Proizvodi = ctx.NarudzbaStavke.Where(x => x.Narudzba.KlijentId == Id && x.NarudzbaId == n.NarudzbaId).Select(x => new ProizvodInfo
                {
                    NarudzbaId = x.NarudzbaId,
                    NazivProizvoda = x.JeloId != null ? x.Jelo.Naziv : x.Proizvod.Naziv,
                    KolicinaProizvoda = x.Kolicina,
                    IznosProizvoda = x.Kolicina * (x.JeloId != null ? x.Jelo.Cijena : x.Proizvod.Cijena),
                    VrijemeNarudzbe = ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Hour + ":" + ctx.Racuni.Where(y => y.Id == x.NarudzbaId).FirstOrDefault().DatumIzdavanja.Minute
                }).ToList();
            }


            return Ok(model);
        }

        [ResponseType(typeof(List<NarudbaDatum.NarudzbaRow>))]
        [HttpPost]
        [Route("api/izvjestaji/getbydate")]
        public IHttpActionResult PoDatumu([FromBody]DateTime datum)
        {
            NarudbaDatum model = new NarudbaDatum();

            model.Narudzbe = ctx.Narudzbe.Where(x => x.NarudzbaRacun.DatumIzdavanja.Year == datum.Year
                 && x.NarudzbaRacun.DatumIzdavanja.Month == datum.Month && x.NarudzbaRacun.DatumIzdavanja.Day == datum.Day).Select(x => new NarudbaDatum.NarudzbaRow
                 {
                     Datum = x.NarudzbaRacun.DatumIzdavanja,
                     NarudzbaId = x.Id,
                     Iznos = x.NarudzbaRacun.Iznos,
                     KlijentId = x.NarudzbaRacun.KlijentId,
                     KlijentIme = x.NarudzbaRacun.Klijent.Ime + " " + x.NarudzbaRacun.Klijent.Prezime,

                 }).ToList();


            return Ok(model.Narudzbe);
        }

        [ResponseType(typeof(List<NarudbaDatum.NarudzbaRow>))]
        [HttpPost]
        [Route("api/izvjestaji/getbykategorija")]
        public IHttpActionResult PonudaNarudzbe(int Id, string Kategorija)
        {
            NarudzbaPonuda model = new NarudzbaPonuda();
            if (Kategorija != "Jela")
            {
                model.ROWW = ctx.NarudzbaStavke.Where(i => i.ProizvodId == Id).Select(x => new NarudzbaPonuda.ROW
                {
                    Datum = x.Narudzba.NarudzbaRacun.DatumIzdavanja,
                    Id = x.NarudzbaId,
                    Iznos = ctx.NarudzbaStavke.Where(u => u.ProizvodId == Id &&
                        u.Narudzba.NarudzbaRacun.KlijentId == x.Narudzba.NarudzbaRacun.KlijentId).Sum(o => o.Narudzba.NarudzbaRacun.Iznos),
                    KlijentId = x.Narudzba.NarudzbaRacun.KlijentId,
                    KlijentIme = x.Narudzba.NarudzbaRacun.Klijent.Ime + " " + x.Narudzba.NarudzbaRacun.Klijent.Prezime,
                    ZaposlenikId = x.Narudzba.NarudzbaRacun.ZaposlenikId,
                    ZaposlenikIme = x.Narudzba.NarudzbaRacun.Zaposlenik.Ime
                }).ToList();
            }
            else
            {
                model.ROWW = ctx.NarudzbaStavke.Where(i => i.JeloId == Id).Select(x => new NarudzbaPonuda.ROW
                {
                    Datum = x.Narudzba.NarudzbaRacun.DatumIzdavanja,
                    Iznos = ctx.NarudzbaStavke.Where(u => u.JeloId == Id &&
                       u.Narudzba.NarudzbaRacun.KlijentId == x.Narudzba.NarudzbaRacun.KlijentId).Sum(o => o.Narudzba.NarudzbaRacun.Iznos),
                    Id = x.NarudzbaId,
                    KlijentId = x.Narudzba.NarudzbaRacun.KlijentId,
                    KlijentIme = x.Narudzba.NarudzbaRacun.Klijent.Ime + " " + x.Narudzba.NarudzbaRacun.Klijent.Prezime,
                    ZaposlenikId = x.Narudzba.NarudzbaRacun.ZaposlenikId,
                    ZaposlenikIme = x.Narudzba.NarudzbaRacun.Zaposlenik.Ime
                }).ToList();
            }

            return Ok(model);
        }

        [ResponseType(typeof(RacunVM))]
        [HttpPost]
        [Route("api/izvjestaji/danasnjazarada")]
        public IHttpActionResult Index([FromBody]DateTime date)
        {
            RacunVM racuni = new RacunVM();

            racuni.DanasnjaZarada = ctx.Racuni.Where(j => j.DatumIzdavanja.Year == date.Year
                                   && j.DatumIzdavanja.Month == date.Month
                                   && j.DatumIzdavanja.Day == date.Day).GroupBy(o => new
                                   {
                                       Day = o.DatumIzdavanja.Day,
                                       DatumIzdavanja = o.DatumIzdavanja,
                                       Iznos = ctx.Racuni.Where(j => j.DatumIzdavanja.Year == date.Year
                                     && j.DatumIzdavanja.Month == date.Month
                                     && j.DatumIzdavanja.Day == date.Day).Sum(y => y.Iznos)
                                   }).Select(x => new RacunVM.RacunRow
                                   {
                                       DatumIzdavanja = x.Key.DatumIzdavanja,
                                       Iznos = x.Key.Iznos,
                                       Dan = x.Key.Day
                                   }).FirstOrDefault();
            if (racuni.DanasnjaZarada == null)
            {
                racuni.DanasnjaZarada = new RacunVM.RacunRow
                {
                    BrojNarudzbi = 0,
                    DatumIzdavanja = DateTime.Now,
                    Iznos = 0,
                    Dan = DateTime.Now.Day,
                };
            }

            racuni.Zarade = ctx.Racuni.Where(j => j.DatumIzdavanja.Year == date.Year
                                     && j.DatumIzdavanja.Month == date.Month
                                     && j.DatumIzdavanja.Day == date.Day).GroupBy(o => new
                                     {
                                         Day = o.DatumIzdavanja.Day,
                                         DatumIzdavanja = o.DatumIzdavanja,
                                         Iznos = ctx.Racuni.Where(j => j.DatumIzdavanja.Year == date.Year
                                       && j.DatumIzdavanja.Month == date.Month
                                       && j.DatumIzdavanja.Day == date.Day).Sum(y => y.Iznos)
                                     }).Select(x => new RacunVM.RacunRow
                                     {
                                         DatumIzdavanja = x.Key.DatumIzdavanja,
                                         Iznos = x.Key.Iznos,
                                         Dan = x.Key.Day,
                                         BrojNarudzbi = ctx.Racuni.Count(j => j.DatumIzdavanja.Year == date.Year
                                      && j.DatumIzdavanja.Month == date.Month
                                      && j.DatumIzdavanja.Day == date.Day)
                                     }).ToList();

            return Ok(racuni);
        }
    }
}
