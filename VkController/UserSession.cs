namespace Vk.DTO.Controllers
{
    public class UserSession
    {
        private string login;
        private string pass;
        
       public bool IsUserAuthorized { get ; set; }
       public int UserId { get; set;}
       public string Login { set { login = value; } }
       public string Pass { set { pass = value; }}

        internal string GetPass()
        {
            return pass;
        }
        internal string GetLogin()
        {
            return this.login;
        }
    }
}
