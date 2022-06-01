﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class EmployeePayRate
    {
        public int EmployeeId { get; set; }
        public Employee  Employee { get; set; }

        [Key]
        public int PayTFId { get; set; }
        public PayTimeFrame PayTimeFrame { get; set; }

        [Precision(10, 2)]
        public decimal TFCommPercent { get; set; }  

    }
}
