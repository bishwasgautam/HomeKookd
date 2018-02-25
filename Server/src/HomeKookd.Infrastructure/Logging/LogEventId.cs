namespace HomeKookd.Infrastructure.Logging
{
    public enum LogEventId
    {
        None = 0,
        RequestCompleted = 100,
        UserNotFound = 403,
        Exception = 500,
        SoapRequest = 1000,
        SoapReply = 1001
    }
}