using eRestoran.Data.DAL;
using System;
using System.Linq;

namespace eRestoran.Api.Infrastructure
{
    public class PromotionsService
    {
        private MyContext db = new MyContext();

        public void CheckPromotions()
        {
            var startingPromotionsPica = db.Promocije.Where(x => x.ProizvodId.HasValue && x.DatumOd.Day == DateTime.Now.Day
                                                     && x.DatumOd.Month == DateTime.Now.Month && x.DatumOd.Year == DateTime.Now.Year);
            var startingPromotionsJela = db.Promocije.Where(x => x.JeloId.HasValue && x.DatumOd.Day == DateTime.Now.Day
                                                       && x.DatumOd.Month == DateTime.Now.Month && x.DatumOd.Year == DateTime.Now.Year);
            var endingPromotionsPica = db.Promocije.Where(x => x.ProizvodId.HasValue && x.DatumDo.Day == DateTime.Now.Day
                                                       && x.DatumDo.Month == DateTime.Now.Month && x.DatumDo.Year == DateTime.Now.Year);
            var endingPromotionsJela = db.Promocije.Where(x => x.JeloId.HasValue && x.DatumDo.Day == DateTime.Now.Day
                                                       && x.DatumDo.Month == DateTime.Now.Month && x.DatumDo.Year == DateTime.Now.Year);
            endingPromotionsPica.ToList().ForEach(x =>
            {
                x.Proizvod.Cijena = x.StaraCijena;
                db.Promocije.Remove(x);
            });

            endingPromotionsJela.ToList().ForEach(x =>
            {
                x.Jelo.Cijena = x.StaraCijena;
                db.Promocije.Remove(x);
            });

            startingPromotionsPica.ToList().ForEach(x =>
            {
                x.Proizvod.Cijena = x.PromotivnaCijena;
            });

            startingPromotionsJela.ToList().ForEach(x =>
            {
                x.Jelo.Cijena = x.PromotivnaCijena;
            });

            db.SaveChanges();

            return;
        }

        public void endPromotions(int? proizvodId = null, int? jeloId = null)
        {
            if (proizvodId.HasValue)
            {
                var promotionPice = db.Promocije.FirstOrDefault(x => x.ProizvodId == proizvodId);

                if (promotionPice != null)
                {
                    promotionPice.Proizvod.Cijena = promotionPice.StaraCijena;
                    db.Promocije.Remove(promotionPice);
                    db.SaveChanges();
                }
            }
            else
            {
                var promotionJelo = db.Promocije.FirstOrDefault(x => x.JeloId == jeloId);

                if (promotionJelo != null)
                {
                    promotionJelo.Jelo.Cijena = promotionJelo.StaraCijena;
                    db.Promocije.Remove(promotionJelo);
                    db.SaveChanges();
                }
            }
        }
    }
}