using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using eRestoran.Data.DAL;
using eRestoran.Data.Models;
using eRestoran.PCL.VM;
using Newtonsoft.Json;
using static eRestoran.VM.PonudaVM;

namespace eRestoran.Api.Controllers
{
    public class ProizvodiController : ApiController
    {
        private MyContext db = new MyContext();
        string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

        // GET: api/Proizvodi
        public List<PonudaInfo> GetProizvodi()
        {
            return db.Proizvodi.Select(x => new PonudaInfo
            {
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                KolicinaString = x.Kolicina.ToString(),
                Kategorija = x.TipProizvoda.Naziv,
                Naziv = x.Naziv,
                Id = x.Id,
                imageUrl = x.SlikaUrl

            }).ToList();
        }

        // GET: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public Proizvod GetProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return null;
            }

            return proizvod;
        }
        public PonudaInfo GetProizvodVM(int id)
        {
            PonudaInfo proizvod = db.Proizvodi.Where(x => x.Id == id).Select(x => new PonudaInfo
            {
                Id = id,
                Naziv = x.Naziv,
                Kolicina = x.Kolicina,
                KolicinaString = x.Kolicina.ToString(),
                Kategorija = x.TipProizvoda.Naziv,
                Cijena = x.Cijena,
                imageUrl = x.SlikaUrl


            }).FirstOrDefault();

            return proizvod;
        }

        // PUT: api/Proizvodi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvod.Id)
            {
                return BadRequest();
            }

            var proizvodTrazeni = db.Proizvodi.SingleOrDefault(f => f.Id == id);
            proizvodTrazeni.SkladisteId = proizvod.SkladisteId;
            proizvodTrazeni.TipProizvodaId = proizvod.TipProizvodaId;
            proizvodTrazeni.Naziv = proizvod.Naziv;
            proizvodTrazeni.Cijena = proizvod.Cijena;
            proizvodTrazeni.Kolicina = proizvod.Kolicina;
            proizvodTrazeni.KriticnaKolicina = proizvod.KriticnaKolicina;
            proizvodTrazeni.Menu = proizvod.Menu;
            proizvodTrazeni.Sifra = proizvod.Sifra;
            proizvodTrazeni.SlikaUrl = proizvod.SlikaUrl;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Proizvodi
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            return Ok(Request.Content.ReadAsStringAsync().Result);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Proizvodi.Add(proizvod);
            //try
            //{
            //    db.SaveChanges();

            //}
            //catch (Exception e)
            //{
            //    var x = e.Message;
            //}
            //proizvod.SlikaUrl = proizvod.SlikaUrl;
            //return CreatedAtRoute("DefaultApi", new { id = proizvod.Id }, proizvod);
        }

        // DELETE: api/Proizvodi/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = db.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            db.Proizvodi.Remove(proizvod);
            db.SaveChanges();

            return Ok(proizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodExists(int id)
        {
            return db.Proizvodi.Count(e => e.Id == id) > 0;
        }

        [Route("api/proizvodi/uploadimage/{proizvodId}"), AcceptVerbs("POST")]
        public IHttpActionResult Upload(int proizvodId)
        {

            try
            {
                var test = this.Request.Content.ReadAsStringAsync().Result;
                return Ok(test);
            }
            catch (Exception e)
            {
                var tt = JsonConvert.SerializeObject(e);
                return Ok(e);
            }
            //try
            //{
               
            //    if (Request.Content.IsMimeMultipartContent())
            //{
            //        return Ok("test");
            //        //var path = "/images";
            //        //var task = await FileUpload(path, Request.Content, proizvodId);

            //        //if (task == null)
            //        //    return BadRequest();

            //        //return Ok(task);
                
            //}
            //else
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            //}
            //}
            //catch (Exception e)
            //{
            //    return Ok("greska");
            //}
        }

        public async Task<ProizvodSlikaVM> FileUpload(string relativePath, HttpContent content, int proizvodId)
        {
            var path = HttpContext.Current.Server.MapPath(relativePath);
            var streamProvider = new CustomMultipartFileStreamProvider(path);
            var proizvod = db.Proizvodi.FirstOrDefault(x => x.Id == proizvodId);
            FileInfo info ;
            if (proizvod == null)
            {
                return null;
            }
            var file = await content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    return new ProizvodSlikaVM()
                    {
                        ProizvodId = 0,
                        FileName = "NE RADI",
                        FileUrl = "ss"
                    };
                }
                 info = new FileInfo(streamProvider.FileData[0].LocalFileName);
                proizvod.SlikaUrl = "TESTTTTT/";
                //Attachment attachment = new Attachment()
                //{
                //    IsDeleted = false,
                //    CreatedAt = DateTime.Now,
                //    LastModifiedAt = DateTime.Now,
                //    Extension = info.Extension,
                //    Name = info.Name.Replace('.' + info.Extension, ""),
                //    Url = "uploads/" + info.Name
                //};
                db.SaveChanges();

                return new ProizvodSlikaVM()
                {
                    ProizvodId = proizvod.Id,
                    FileName = info.Name,
                    FileUrl = "images/" + info.Name
                };
            });
            return file;
        }
    }

    public class CustomMultipartFileStreamProvider : MultipartFileStreamProvider
    {
        public CustomMultipartFileStreamProvider(string path) : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return Guid.NewGuid().ToString() + name.Replace("\"", string.Empty);
        }
    }
}