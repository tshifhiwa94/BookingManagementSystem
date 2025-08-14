using BookingManagement.Domain.Addresses;
using BookingManagement.Domain.Persons.Enums;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingManagement.Domain.Persons
{
    public class Person : RecordEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(13)]
        public virtual string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListGender Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Address? Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual User? User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public virtual string?[] RoleNames { get; set; }
    }
}
