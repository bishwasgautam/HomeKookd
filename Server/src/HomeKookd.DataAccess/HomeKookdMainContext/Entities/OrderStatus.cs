namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public enum OrderStatus
    {
        Processing, //payment processing
        Placed, //payment complete
        Received, //sent to cook
        Ready, //all meals ready
        PickedUp, //picked up by user
        Delivered //delivered to user
    }
}