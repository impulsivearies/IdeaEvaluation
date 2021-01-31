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
    [RoutePrefix("dashboard")]
    public class DashboardController : ApiController
    {
        private IRepository repository = new Repository();

        [Route("getdashboard/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        // GET: api/Dashboard/5
        public HttpResponseMessage Get(int id)
        {
            // Will be populated from Evaluations
            //Judge judge = new Judge{ Name ="Test", EmailId ="Test123", JudgeId = id, AssignedIdeas = new List<Idea>
            //{
            //    new Idea{IdeaId = 1, IdeaName= "Idea1", IdeaDescription = "Idea1Description", EvaluatedCount = 0},
            //    new Idea{IdeaId = 2, IdeaName= "Idea1", IdeaDescription = "Idea1Description", EvaluatedCount = 1},
            //    new Idea{IdeaId = 3, IdeaName= "Idea1", IdeaDescription = "Idea1Description", EvaluatedCount = 3},
            //} };

            Judge judge = repository.GetJudgesData(id);
            if (judge == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, judge);
            return response;
        }

        // POST: api/Dashboard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dashboard/5
        public void Delete(int id)
        {
        }
    }
}
