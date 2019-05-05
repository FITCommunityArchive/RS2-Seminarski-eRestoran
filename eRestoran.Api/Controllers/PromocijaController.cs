using eRestoran.Api.Infrastructure;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace eRestoran.Api.Controllers
{
    public class PromocijaController : ApiController
    {
        private MyContext db = new MyContext();

        public List<Promocija> GetPromocije()
        {
            return db.Promocije.ToList();
        }

        // POST: api/Skladiste
        [ResponseType(typeof(Promocija))]
        public IHttpActionResult PostPromocija(Promocija promocija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (promocija.DatumOd.Date == DateTime.Now.Date)
            {
                var promotionsService = new PromotionsService();
                promotionsService.CheckPromotions();
            }

            db.Promocije.Add(promocija);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promocija.Id }, promocija);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
