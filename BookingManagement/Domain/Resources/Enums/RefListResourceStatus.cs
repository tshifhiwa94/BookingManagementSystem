using System.ComponentModel;

namespace BookingManagement.Domain.Resources.Enums
{
    public enum RefListResourceStatus : long
    {

        [Description("Available for booking")]
        Operational = 1,

        [Description("may be unavailable temporarily")]
        Scheduled = 2,

        [Description("Under Maintenance")]
        UnderMaintenance = 3,

        [Description("Out Of Service")]
        OutOfService = 4
    }
}
