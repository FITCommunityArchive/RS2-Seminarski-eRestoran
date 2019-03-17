using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace eRestoran.Api.Controllers
{
    public class ImageController : ApiController
    {
        string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

        [Route("api/image/upload/{itemId}"), AcceptVerbs("POST")]
        public async Task<object> Upload(int itemId)
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                var path = "~/images";
                var task = await FileUpload(path, Request.Content, itemId);

                if (string.IsNullOrEmpty(task.ToString()))
                    return BadRequest();

                HttpContext.Current.Response.AddHeader("image-url", task.ToString());
                return Ok();
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }

        public async Task<object> FileUpload(string relativePath, HttpContent content, int itemId)
        {
            var path = HttpContext.Current.Server.MapPath(relativePath);
            var streamProvider = new CustomMultipartFileStreamProvider(path, itemId);

            string file = await content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    return string.Empty;
                }
                var info = new FileInfo(streamProvider.FileData[0].LocalFileName);
            
                return "images/" + info.Name;
            });
            return file;
        }
    }

    public class CustomMultipartFileStreamProvider : MultipartFileStreamProvider
    {
        int itemId { get; set; }
        public CustomMultipartFileStreamProvider(string path, int itemId) : base(path)
        {
            this.itemId = itemId;
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return Guid.NewGuid().ToString() + name.Replace("\"", string.Empty);
        }
    }
}
