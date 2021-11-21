using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phase1_Projects_Backend.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string Description { get; set; }

        public string Domain { get; set; }

        public string TechTools { get; set; } = "To be Updated";

        public string ContactMail { get; set; }
    }
}
