using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTableCrud.Models
{
    public class Trainee
    {
        [Key]
        public int TraineeID { get; set; }
        public string Name { get; set; }
        public string CoreSubject { get; set; }
        public int Round { get; set; }
        public string TSP { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<ExamDetail> ExamDetails { get; set; }
    }
}