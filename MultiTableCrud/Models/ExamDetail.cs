using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTableCrud.Models
{
    public class ExamDetail
    {
        [Key]
        public int ExamDetailID { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ResultPublishDate { get; set; }
        public decimal ExternalMarks { get; set; }
        public decimal EvidenceMarks { get; set; }

        //[NotMapped]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal TotalMarks { get { return (ExternalMarks + EvidenceMarks); } }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalMarks => (ExternalMarks + EvidenceMarks);

        public int TraineeID { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}