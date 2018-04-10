using JobTrackerDomain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobTracker_API.Models.Client
{
    public class CreateVM
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string businessName { get; set; }
        [Required]
        public string invoicePrefix { get; set; }
        [Required]
        public string address { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        public string primaryPhone { get; set; }
    }

    public class UpdateVM
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string businessName { get; set; }
        public string invoicePrefix { get; set; }
        public string address { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string primaryPhone { get; set; }
    }
}
