﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _16TagHelpersApp.Models
{
    public class Phone
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Range(50, 500)]
            [Required]
            public int Price { get; set; }
            
            [Required]
            public int CompanyId { get; set; }
            public Company Company { get; set; }
        }
 
    public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
}
