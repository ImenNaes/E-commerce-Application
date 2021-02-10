namespace BLL.Entities
{
    public enum PaymentStatus
    {
        Unpaid = 1,
        PartPaid = 2,
        PartRefunded = 4,
        Refunded = 5,
        Completed = 6
    }
}
