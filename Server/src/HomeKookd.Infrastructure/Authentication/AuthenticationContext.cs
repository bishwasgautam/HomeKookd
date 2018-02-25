namespace HomeKookd.Infrastructure.Authentication
{
    public class AuthenticationContext : IAuthenticationContext
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool SignOut()
        {
            throw new System.NotImplementedException();
        }

        public bool IsSessionActive()
        {
            throw new System.NotImplementedException();
        }
    }
}