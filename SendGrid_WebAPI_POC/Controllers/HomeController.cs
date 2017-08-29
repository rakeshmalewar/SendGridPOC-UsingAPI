using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SendGrid_WebAPI_POC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string resp = sendEmail();
            Response.Write(resp);
            return View();
        }

        public string sendEmail()
        {

            string jsonStr = "{  \"personalizations\": [    {      \"to\": [        {          \"email\": \"rmalewar@prokarma.com\"        }, {          \"email\": \"notvalid@pk.com\"        },{          \"email\": \"pshivakoti@prokarma.com\"        }      ],    \"subject\": \"Hello, World! From SendGrid_WebAPI_POC again\"     }   ],  \"from\": {    \"email\": \"rakesh_malewar@yahoo.com\"   },   \"content\": [     {       \"type\": \"text/plain\",      \"value\": \"Hello, World!\"    }  ] }";

            //https://api.sendgrid.com/v3/mail/send
            string baseUri = @"https://api.sendgrid.com/v3/mail/send";

            var client = new RestClient(baseUri);
            var request = new RestRequest();

            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddHeader("Authorization", "Bearer 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");

            
            request.AddParameter("application/json", jsonStr, ParameterType.RequestBody);

            var response = client.Execute(request);

            return response.ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Auth : IAuthenticator
    {
        private string userName, password, apiKey;

        public Auth(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            //var basicAuthHeaderValue = string.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", this.userName, password))));
            //request.AddHeader("Authorization", basicAuthHeaderValue);
            request.AddHeader("Authorization", this.apiKey);
            request.AddHeader("Content-Type", "application/json");
        }
    }

}