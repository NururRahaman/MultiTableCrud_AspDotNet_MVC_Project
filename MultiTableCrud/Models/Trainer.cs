using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MultiTableCrud.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateofBirth { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}