using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using yProjectDataAccess;

using System.Web;


namespace yProject.Controllers
{
    public class DiscussionController : ApiController
    {
        //public List<Question> Get()
        //{
        //    List<string> qArray = new List<string>();
        //    using (DiscussionFormEntities entities = new DiscussionFormEntities())
        //    {
        //        foreach (var question in entities.Questions)
        //        {


        //            System.Diagnostics.Debug.WriteLine("---here is the user details");
        //            System.Diagnostics.Debug.WriteLine(question.qtitle);
        //            qArray.Add(question.qtitle);
        //            System.Diagnostics.Debug.WriteLine(qArray.ToArray());


        //        }
        //        return entities.Questions.ToList();


        //    }
        //public IEnumerable<Customer> Get()
        //{
        //    using (TempEntities entities = new TempEntities())
        //    {
        //        return entities.Customers.ToList();
        //    }
        //}



        //[System.Web.Http.Route("Discussion/Index")]
        //[System.Web.Http.HttpGet]
        public IEnumerable<Question> Get()
        {
            using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;



                var data = entities.Questions
                .Include("Answers")
                .Where(q => q.qapprove == 1)
                .Select(x => new
                {
                    Questions = x,
                    Answers = x.Answers.Where(a => a.aapprove == 1)
                })
                .ToList();

                var questions = data.Select(x => x.Questions).ToList();


                //List<Question> questions = entities.Questions
                //    .Include("Answers")
                //    .Where(q => q.qapprove == 1)
                //    .ToList();
                System.Diagnostics.Debug.WriteLine("---inside get function");
                System.Diagnostics.Debug.WriteLine(questions);
                return questions;
            }
        }
    
        public IEnumerable<Question> Get(int id)
        {
            using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Question> question = entities.Questions
                    .Include("Answers")
                    .Where(q => (q.qapprove == 1)&& (q.qid == id))
                    .ToList();

               

            
                return question;
                //return entities.Answers.FirstOrDefault(a => a.aid == id);
            }
        }
        //public HttpResponseMessage Post([FromBody] Question question)
        //{
        //    System.Diagnostics.Debug.WriteLine("---here is the question details");
        //    System.Diagnostics.Debug.WriteLine(question);
        //    try
        //    {
        //        using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
        //        {
        //            foreach (var user in entities.Users)
        //            {
        //                if (user.uid == 1)
        //                {
        //                    question.User_uid = 2;
        //                    System.Diagnostics.Debug.WriteLine(question);

        //                }
        //            }

        //            entities.Questions.Add(question);


        //            entities.SaveChanges();

        //            var message = Request.CreateResponse(HttpStatusCode.Created, question);
        //            message.Headers.Location = new Uri(Request.RequestUri + question.qid.ToString());
        //            return message;
        //            //entities.Users.Add(user);
        //            //entities.SaveChanges();
        //            //var message = Request.CreateResponse(HttpStatusCode.Created, user);
        //            //message.Headers.Location = new Uri(Request.RequestUri + user.uid.ToString());
        //            //return message;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        public HttpResponseMessage Post([FromBody] Answer answer)
        {
            System.Diagnostics.Debug.WriteLine("---here is the question details");
            System.Diagnostics.Debug.WriteLine(answer);
            try
            {
                using (DiscussionDatabaseEntities entities = new DiscussionDatabaseEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    answer.Question_qid = answer.qid;
                    entities.Answers.Add(answer);
                    System.Diagnostics.Debug.WriteLine(answer.Question);
                    //entities.Answers.Include("Question");

                    entities.SaveChanges();
                    //List<Answer> answers = entities.Answers
                    //         .ToList();
                    //return answers;
                    //entities.Users.Add(user);
                    //entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, answer);
                    message.Headers.Location = new Uri(Request.RequestUri + answer.aid.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
