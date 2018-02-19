using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerManagement.API.Controllers
{
    public class BaseController : ApiController
    {
        public BaseController()
        {

        }

        protected HttpResponseMessage Error(string errorMessage)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, Envelope.Error(errorMessage));
        }

        protected new HttpResponseMessage Ok()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok());
        }

        protected new HttpResponseMessage Ok<T>(T result)
        {
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok(result));
        }
    }
}
