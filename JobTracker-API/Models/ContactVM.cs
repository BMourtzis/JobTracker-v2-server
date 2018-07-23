
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobTracker_API.Models
{
    public class AddContactVM
    {
        public List<Tuple<string, string, int>> Contacts { get; set; }
    }
    
    public class UpdateContactVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactValue { get; set; }
    }
}
