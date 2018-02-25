namespace HomeKookd.Infrastructure.Authentication
{
    public interface IAuthenticationContext
    {
        int UserId { get; set; }
        string UserName { get; set; }
        bool SignOut();
        bool IsSessionActive();

    }
}