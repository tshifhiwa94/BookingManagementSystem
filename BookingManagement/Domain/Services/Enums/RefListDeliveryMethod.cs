using System.ComponentModel;

namespace BookingManagement.Domain.Services.Enums
{
    public enum RefListDeliveryMethod : long
    {
        [Description("On Site")]
        OnSite = 1,

        [Description("Remote")]
        Remote = 2,

        [Description("Hybrid")]
        Hyper = 3,
    }
}
