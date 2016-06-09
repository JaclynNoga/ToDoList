using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace To_Do_List.Models
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        [Display(Name = "Due Date")]
        public Nullable<System.DateTime> DueDate { get; set; }
        [Display(Name = "Completed")]
        public bool TaskDone { get; set; }

        private TimeSpan daysPastDue;
        [DisplayFormat(DataFormatString = "{0:%d}")]
        public Nullable<System.TimeSpan> DaysPastDue
        {
            get
            {
                if (this.DueDate < DateTime.Today)
                {
                    var thing = (DateTime)this.DueDate;
                    var answer = (TimeSpan)DateTime.Today.Subtract(thing);
                    return answer;
                }
                else { return daysPastDue; }
            }
        }
    }
}