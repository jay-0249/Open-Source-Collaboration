using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//This library is used for 'Key' annotation which tells to EF Core framework that the property before which 'Key' is stated is the primary key of that table 
using System.ComponentModel.DataAnnotations;
//This library is used for 'DatabaseGenerated' annotation
using System.ComponentModel.DataAnnotations.Schema;

namespace Phase1_Projects_Backend.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserSummary { get; set; }
        public string ContactMail { get; set; }
        public string githubProfile { get; set; }
        public string gitlabProfile { get; set; }
        
        public IEnumerable<Project> ProjectId { get; set; }
    }
}
