using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KADataAccess.Models
{
    public class Contact
    {
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

        [MaxLength(20)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(2500)]
        public string Comment { get; set; }
    }
}
