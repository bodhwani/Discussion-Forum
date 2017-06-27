using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yProjectDataAccess;

namespace yProject.Controllers
{
    public class ApproveController : ApiController
    {
        // GET: api/Approve
        public IEnumerable<Question> Get()
        {
            using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Question> questions = entities.Questions
                    .Include("Answers")
                    .Where(q => q.qapprove == 0)
                    .ToList();
                System.Diagnostics.Debug.WriteLine("---inside get function");
                System.Diagnostics.Debug.WriteLine(questions);
                return questions;
            }

        }

        // GET: api/Approve/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Approve
        public HttpResponseMessage Post([FromBody] Approve approve)
        {
            System.Diagnostics.Debug.WriteLine("---inside post function Approve controller");
           

            try
            {
                using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    List<Question> questions = entities.Questions
                    .Where(q => q.qapprove == 0)
                    .ToList();

                    foreach (var question in questions)
                    {
                        if (question.qid == approve.id)
                        {
                            if (approve.value == 1)
                            {
                                question.qapprove = 1;
                                System.Diagnostics.Debug.WriteLine(question.qapprove);

                            }

                        }
                    }
                    //entities.Answers.Include("Question");
                    //entities.Answers.Include("Question");
                    entities.SaveChanges();
                    //List<Answer> answers = entities.Answers
                    //         .ToList();
                    //return questions;
                    //entities.Users.Add(user);
                    //entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, questions);
                    //message.Headers.Location = new Uri(Request.RequestUri + question.qid.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        // PUT: api/Approve/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Approve/5
        public void Delete(int id)
        {
        }
    }
}
