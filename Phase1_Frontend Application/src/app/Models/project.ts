// export interface Project {

// }
export class Project {
  //id:number,title:string,des:string,domain:string,tech:string,mail:string
  constructor() {
    this.projectId=0;
    this.projectTitle="";
    this.description="";
    this.domain="";
    this.techTools="";
    this.contactMail="";
   }
    projectId: number;
    projectTitle: string;
    description: string;
    domain: string;
    techTools: string;
    contactMail: string;
  }
  // public class Project
  // {
  //     [Key]
  //     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  //     public int ProjectId { get; set; }

  //     public string ProjectTitle { get; set; }

  //     public string Description { get; set; }

  //     public string Domain { get; set; }

  //     public string TechTools { get; set;}

  //     public string ContactMail { get; set; }
  
  // export interface Project {
  //   projectId: number;
  //   projectTitle: string;
  //   description: string;
  //   domain: string;
  //   techTools: string;
  //   contactMail: string;
  // }
  