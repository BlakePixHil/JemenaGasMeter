using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JemenaGasMeter.WebApi.Models
{
    public enum UserType
    {
        Technician = 1,
        Contractor = 2,
    }
    public enum Status
    {
        Active = 1,
        Inactive = 2,
    }
    public class User
    {
        [Key]
        public string PayRollID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }
        public string PIN { get; set; }
        public Status Status { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
