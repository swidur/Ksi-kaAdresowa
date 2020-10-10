using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KARepository.DTOs
{
    class ContactReadDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(2500)]
        public string Comment { get; set; }

        public string FullName { 
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
