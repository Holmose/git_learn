using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;


namespace Booktest.Controllers
{
    public class DemoApiController : ApiController
    {
        //[HttpGet]
        //public string HelloWorld() 
        //{
        //    return "Hello World!";
        //}

        [HttpGet]
        public int Add(int left, int right)
        {
            return left + right;
        }

        [HttpGet]
        public HttpResponseMessage Image(string img)
        {
            var imgPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Images/"+img);
            var imgByte = File.ReadAllBytes(imgPath);
            var imgStream = new MemoryStream(imgByte);
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                //Content = new StreamContent(imgStream)
                Content = new ByteArrayContent(imgByte)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;
        
        }
    }
}
