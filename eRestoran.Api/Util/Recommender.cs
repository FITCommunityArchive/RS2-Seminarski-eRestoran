//using eRestoran.Data.DAL;
//using eRestoran.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using static eRestoran.VM.PonudaVM;

//namespace eRestoran.Api.Util
//{

//    //TABELA OCJENA;
//    //Proizvod proizvod;
//    //Kupac kupac;
//    //int ocjena
//    public class Recommender
//    {
//        private MyContext db = new MyContext();
//        Dictionary<int, List<Ocjene>> proizvodi = new Dictionary<int, List<Ocjene>>();

//        public List<PonudaInfo> GetSlicneProizvode(int proizvodId) {

//            ucitajProizvode(proizvodId);
//            List<PonudaInfo> preporuceniProizvodi = new List<PonudaInfo>();
//            List<Proizvod> ocjenePosmatranogProizvoda = db.Proizvodi.Where(x => x.Id == proizvodId).ToList();

//            List<Ocjene> zajednickeOcjene1 = new List<Ocjene>();
//            List<Ocjene> zajednickeOcjene2 = new List<Ocjene>();

//            foreach (var item in proizvodi)
//            {
//                foreach (Ocjene o in ocjenePosmatranogProizvoda)
//                {
//                    if (item.Value.Where(x => x.kupacId == o.kupacId).Count() > 0) {
//                        zajednickeOcjene1.Add(o);
//                        zajednickeOcjene1.Add(item.Value.Where(x => x.kupacId == o.kupacId).FirstOrDefault());
//                    }
//                }

//                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);

//                if (slicnost > 0.5)
//                {
//                    preporuceniProizvodi.Add(db.Proizvodi.Where(x => x.Id == item.Key).Select( x=> new PonudaInfo {
//                        Cijena = x.Cijena,
//                        Id = x.Id,
//                        imageUrl = x.SlikaUrl,
//                        Naziv = x.Naziv,
//                    }).FirstOrDefault());

//                    zajednickeOcjene1.Clear();
//                    zajednickeOcjene2.Clear();
//                }

//            }

//                return preporuceniProizvodi;

//        }

//        private double GetSlicnost(List<Ocjene> zajednickeOcjene1, List<Ocjene> zajednickeOcjene2)
//        {
//            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count) {
//                return 0;
//            }

//            double brojnik = 0, nazivnik = 0, nazivnik2 = 0;

//            for (int i = 0; i < zajednickeOcjene1.Count; i++) {
//                brojnik = zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
//                nazivnik = zajednickeOcjene1[i].Ocjena * zajednickeOcjene1[i].Ocjena;
//                nazivnik2 = zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
//            }

//            nazivnik = Math.Sqrt(nazivnik);
//            nazivnik2 = Math.Sqrt(nazivnik2);

//            if (nazivnik == 0)
//                return 0;

//            return brojnik / nazivnik;
//        }

//        private void ucitajProizvode(int proizvodId)
//        {
//            List<Proizvod> aktivniProizvodi = db.Proizvodi.Where(x => x.Id != proizvodId).ToList();

//            List<Ocjene> ocjene;

//            foreach (Proizvod p in aktivniProizvodi) {
//                ocjene = db.Ocjene.Where(x => x.proizvodId == p.Id).OrderBy(x => x.kupacId).ToList();

//                if (ocjene > 0) {
//                    proizvodi.Add(p.Id, ocjene);
//                }
//            }
//        }
//    }
//}