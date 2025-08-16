using System.ComponentModel;

namespace BookingManagement.Domain.Persons.Enums
{
    public enum RefListGender : long
    {
        [Description("Male")]
        male = 1,

        [Description("Female")]
        female = 2,

        [Description("Other")]
        other = 3,
    }
}
