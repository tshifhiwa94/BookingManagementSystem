using System.ComponentModel;

namespace BookingManagement.Domain.Services.Enums
{
    public enum RefListServiceRequestStatus : long
    {
        [Description("Approved")]
        Approved = 1,


        [Description("Rejected")]
        Rejected = 2,

        [Description("On Hold")]
        OnHold = 3,

        [Description("Awaiting for Approval")]
        AwaitingForApproval = 4,

        [Description("Cancelled")]
        Cancelled = 5,

        [Description("Completed")]
        Completed = 6,

        [Description("Drafted")]
        Drafted = 7
    }
}
