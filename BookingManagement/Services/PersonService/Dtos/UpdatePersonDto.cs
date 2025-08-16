using System.ComponentModel.DataAnnotations;

namespace BookingManagement.Services.PersonService.Dtos
{
    public class UpdatePersonDto
    {
        public Guid Id { get; set; }
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
        public long? Gender { get; set; }
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
    }
}
