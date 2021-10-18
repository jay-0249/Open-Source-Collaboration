// export interface IuserMini {
// }

export class User {
    userId: number;
    username: string;
    password: string;
    userSummary: string;
    contactMail: string;
    githubProfile: string;
    gitlabProfile: string;

    projectId?: (ProjectIdEntity)[] | null;

    constructor(){
      this.userId = 0;
      this.username="";
      this.userSummary="";
      this.password="";
      this.contactMail="";
      this.githubProfile="";
      this.gitlabProfile="";
    }

  }
  export interface ProjectIdEntity {
    projectId: number;
    projectTitle: string;
    description: string;
    domain: string;
    techTools: string;
    contactMail: string;
  }
  