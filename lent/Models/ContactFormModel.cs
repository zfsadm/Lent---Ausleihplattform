﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lent.Models
{
    public class ContactFormModel
    
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Message { get; set; }
        }

    
}
