using System.ComponentModel;

namespace BookingManagement.Domain.Resources.Enums
{
    public enum RefListResourceType : long
    {
        [Description("Room")]
        Room = 1,

        [Description("Vehicle")]
        Vehicle = 2,

        [Description("Equipment")]
        Equipment = 3,

        [Description("Facility")]
        Facility = 4


    }
}
