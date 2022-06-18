using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTask.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public int Age { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone(ErrorMessage ="Incorrect Phone Number")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Title { get; set; }

        public string JobDescription { get; set; }

    }
}
