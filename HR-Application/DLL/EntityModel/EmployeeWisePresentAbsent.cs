﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityModel
{
    public class EmployeeWisePresentAbsent
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeWisePresentAbsentId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int IsPresent { get; set; }
        public int DepartureTime { get; set; }
       
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }// one to one 
    }
}
