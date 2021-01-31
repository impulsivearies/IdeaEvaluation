using IdeaEvaluation.DataAccess;
using IdeaEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdeaEvaluation.Controllers
{
    [RoutePrefix("login")]
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    public class LoginController : ApiController
    {
        // Introduce DI later
        private IRepository judgeRepository = new Repository();
        
        // GET: api/Login/5
        [Route("testlogin")]
        public string Get()
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        [Route("userlogin")]
        public HttpResponseMessage Login([FromBody] Login user)
        {
            try
            {
                if (user == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrEmpty(user.EmailId) || string.IsNullOrEmpty(user.Password))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                int loggedInUserId = this.judgeRepository.GetLoggedInUser(user.EmailId, user.Password);
                if (loggedInUserId != -1)
                {
                    HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK, loggedInUserId);
                    return responseMessage;
                }

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                // Log exception here
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}
