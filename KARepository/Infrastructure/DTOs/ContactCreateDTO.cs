using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KARepository.Infrastructure.DTOs
{
    public class ContactCreateDTO
    {
        public int? Age
        {
            get
            {
                if (DateOfBirth == null)
                {
                    return null;
                }
                else
                {
                    return DateTime.Now.Year - DateOfBirth.Value.Year;
                }
            }
            set
            {
                if (value.HasValue & value > 0)
                {
                    DateOfBirth = DateTime.Now.AddYears(-value.Value);
                }
                else DateOfBirth = null;
            }
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string AreaCode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(2500)]
        public string Comment { get; set; }
    }
}

