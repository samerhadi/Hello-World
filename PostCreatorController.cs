using Grupp38.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Grupp38.API
{
    public class PostCreatorController : ApiController
    {
        //Get DBContext
        protected ApplicationDbContext DB = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing) DB.Dispose();

            base.Dispose(disposing);
        }

        //Add row with postDetails to DB.Posts
        [HttpPost]
        public void UsePostCreator(Post postDetails)
        {
            var FromUser = DB.Users.Single(x => x.UserName == User.Identity.Name);
            postDetails.From = FromUser;
            var ToUser = DB.Users.Single(x => x.Id == postDetails.ToUser);
            postDetails.To = ToUser;
            postDetails.Text = postDetails.Text;
            postDetails.Date = DateTime.Now;
            DB.Posts.Add(postDetails);
            DB.SaveChanges();
        }
    }
}