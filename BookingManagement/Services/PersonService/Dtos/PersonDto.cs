using BookingManagement.Domain.Persons.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingManagement.Services.PersonService.Dtos
{
    public class PersonDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListGender Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 
        /// </summary>

        [StringLength(13)]
        public string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>

        [NotMapped]
        public string[] RoleNames { get; set; }
    }
}
