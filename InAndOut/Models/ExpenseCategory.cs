﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class ExpenseCategory
    {   [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Expenses> Expenses { get; set; }

    }
}
