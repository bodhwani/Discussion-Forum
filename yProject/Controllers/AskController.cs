using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yProjectDataAccess;

namespace yProject.Controllers
{
    public class AskController : ApiController
    {


        public HttpResponseMessage Post([FromBody] Question question)
        {
            System.Diagnostics.Debug.WriteLine("---here is the question details");
            System.Diagnostics.Debug.WriteLine(question);
            try
            {
                using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
                {
                    
                    question.User_uid = question.uid;
                    entities.Questions.Add(question);


                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, question);
                    message.Headers.Location = new Uri(Request.RequestUri + question.qid.ToString());
                    
                    return message;
                    //entities.Users.Add(user);
                    //entities.SaveChanges();
                    //var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    //message.Headers.Location = new Uri(Request.RequestUri + user.uid.ToString());
                    //return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
