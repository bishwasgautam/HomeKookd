namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public enum MembershipStatus
    {
        PendingApplicationVerification,
        PendingAccountReview,
        Active,
        PaymentFailed,
        Compromised,
        InActive,
        Flagged
    }
}