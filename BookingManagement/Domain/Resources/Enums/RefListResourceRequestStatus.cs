using System.ComponentModel;

namespace BookingManagement.Domain.Resources.Enums
{
    public enum RefListResourceRequestStatus : long
    {
        [Description("Not Started")]
        NotStarted = 1,

        [Description("Awaiting Approval")]
        AwaitingApproval = 2,

        [Description("Cancelled")]
        Cancelled = 3,

        [Description("Approved")]
        Approved = 4,

        [Description("Rejected")]
        Rejected = 5,

        [Description("In Progress")]
        InProgress = 6,

        [Description("Completed")]
        Completed = 7,

        [Description("Over Due")]
        OverDue = 8
    }
}
