using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expenses
    {[Key]
        public int Id { get; set; }
       
        [DisplayName("Expenses Name")]
        [Required]
        public string ExpensesName { get; set; }   
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Amount must be grater than 0")]
        public long Amount { get; set; }
        [DisplayName("Expense Category Id ")]
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        
    }
}
