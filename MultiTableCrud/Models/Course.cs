using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MultiTableCrud.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}