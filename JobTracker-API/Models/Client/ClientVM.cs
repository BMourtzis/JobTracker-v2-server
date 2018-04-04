using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string shortname { get; set; }
    }

    public class UpdateVM
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string businessName { get; set; }
        public string shortname { get; set; }
    }
}
