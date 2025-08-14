using System.ComponentModel;

namespace BookingManagement.Domain.Services.Enums
{
    public enum RefListServiceCategory : long
    {
        [Description("IT")]
        IT = 1,

        [Description("HR")]
        HR = 2,

        [Description("Legal")]
        Legal = 3,

        [Description("Finance")]
        Finance = 4,

        [Description("Facilities")]
        Facilities = 5,

        [Description("Transport")]
        Transport = 6,

        [Description("Catering")]
        Catering = 7,

        [Description("Logistics")]
        Logistics = 8,

        [Description("Marketing")]
        Marketing = 9,

        [Description("Executive Support")]
        ExecutiveSupport = 10,

        [Description("Security")]
        Security = 11,

        [Description("Compliance & Audit")]
        ComplianceAndAudit = 12,

        [Description("Insurance")]
        Insurance = 13,

        [Description("Healthcare & Benefits")]
        HealthcareAndBenefits = 14,
        [Description("Others")]
        Others = 15,
    }

}
