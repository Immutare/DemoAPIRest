using Microsoft.AspNet.Identity.EntityFramework;


namespace APIRestTest.Core
{
    public class BookUserStore: UserStore<IdentityUser>
    {
        public BookUserStore() : base(new ProjectContext())
        {

        }
    }
}