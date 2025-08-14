namespace BookingManagement.Domain.Services.Enums
{
    using System.ComponentModel;

    public enum RefListServiceStatus : long
    {
        [Description("Active")]
        Active = 1,

        [Description("In active")]
        Inactive = 2,

        [Description("Awaiting approval")]
        PendingApproval = 3,

        [Description("suspended")]
        Suspended = 4,

        [Description("archived")]
        Archived = 5,

        [Description("Drafted")]
        Draft = 6
    }

}
