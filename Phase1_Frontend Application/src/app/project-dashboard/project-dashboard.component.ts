import { Component, OnInit } from '@angular/core';
//Imports added
import { Project } from '../Models/project';
import { ProjectsService } from '../Services/projects.service';
//Import observable
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';


@Component({
  selector: 'app-project-dashboard',
  //templateUrl: './project-dashboard.component.html',
  templateUrl: './projectDashboard.html',
  //styleUrls: ['./project-dashboard.component.scss'
  styleUrls: ['./projectDashboard.scss']
})
export class ProjectDashboardComponent implements OnInit {
  allProjects:Project[]=[
    {
    projectId : 1,
    projectTitle : "Title1",
    domain : "Domain1",
    description : "Description1",
    techTools:"Not Available Currently",
    contactMail : "Email1"
    },
    {
      projectId : 2,
      projectTitle : "Title2",
      domain : "Domain2",
      description : "Description2",
      techTools:"Not Available Currently",
      contactMail : "Email2"
    }
  ];
  //APIProjects:any[]=[] ;
  APIProjects:Project[]=[] ;
  ProjectResults:Project[]=[];
  test:string ="before calling fn";
  searchString:string='';
  usernameActive:string='This string is not yet assigned with any active username';


  isSideMenuOpen:boolean= true;
  isProfileMenuOpen:boolean = true;
  isPagesMenuOpen:boolean = true;
  isModalOpen:boolean= true;
  trapCleanup= null;
  constructor(private _service:ProjectsService, private _router:Router, private _userService:UserService) { }

  ngOnInit(): void {
     this._service.getAllProjects().subscribe((data:Project[]) =>
      {
       this.APIProjects=data;
       console.log("APIProjects are ");  
       console.log(this.APIProjects);  
       this.ProjectResults=data;
       console.log("ProjectResults are ");
       console.log(this.ProjectResults);  
      }); 
    // console.log(this.APIProjects.length);
    // this.ProjectResults = this.APIProjects;
    // console.log(this.ProjectResults);  
  }

  onclickdummy(){
    console.log("You clicked on add a new project button");
  }

  goToNewProjectPage()
  {
    //const isUserActive = this._userService.extendedUserObj.IsUserActive;
    const isUserActive = this._userService.GetUserStatus();
    if(isUserActive)
    {
      this._router.navigate(['newProject']);
    }
    else{
      this._router.navigate(['login']);

      //this.goToNewProjectPage()

      // const isUserActive1 = this._userService.extendedUserObj.IsUserActive;
      // if(isUserActive1)
      // {
      //   this._router.navigate(['/newProject']);
      // }

      // else{
      //   this._router.navigate(['/login']);
      //   //this.goToNewProjectPage()
      // }
    }
  }
  public getProjectsList(){
    console.log("getProjectsList() is called");
    this._service.getAllProjects().subscribe((data:Project[]) =>this.APIProjects=data); 
    console.log(this.APIProjects.length);
    this.ProjectResults = this.APIProjects;
  //  this._service.getAll().subscribe((data:string)=>this.test=data);
  //  console.log(this.test+"is the test string fetched");
  //   console.log(this.APIProjects.length);
  //   console.log(this.APIProjects);
    // var lis = this.APIProjects;
    // console.log("datatype is: "+lis);
  }

  getProjectsSearchService(){
    // this.getProjectsList();
     console.log("The search string is: "+this.searchString);
     //this.APIProjects.forEach(p=>this.addProjectResults(p,this.searchString));
     this._service.getProjectsSearched(this.searchString).subscribe((data:Project[])=>
        {
          this.ProjectResults=data;
          console.log("This is data");
          console.log(data);
          console.log("This is ProjectResults array");
          console.log(this.ProjectResults);
        })
     console.log(this.ProjectResults);
   }

  getProjectsSearch(){
   // this.getProjectsList();
    console.log("The search string is: "+this.searchString);
    this.APIProjects.forEach(p=>this.addProjectResults(p,this.searchString));
    console.log(this.ProjectResults);
  }

  addProjectResults(p:Project, keywordSearched:any):void{
    if(p.contactMail.includes(keywordSearched) ||
                           p.description.includes(keywordSearched) || 
                           p.domain.includes(keywordSearched) ||
                           p.techTools.includes(keywordSearched) ||
                           p.contactMail.includes(keywordSearched) ||
                           p.projectTitle.includes(keywordSearched)
    ){this.ProjectResults.push(p)};
  }

  //fetches isUserActive - that is if there is any active user
  getUserStatus(){
    const isUserActive = this._userService.GetUserStatus();
    console.log("User Status is called");
    console.log("The fetched status is: "+isUserActive);
    if(isUserActive){
      this.usernameActive=this._userService.GetUsername();
    }
    return isUserActive;
  }

  //set isUserActive to false
  setUserStatus(){
    const isUserActive1 = this._userService.SetUserToInActive();
    console.log("SetUserToInActive is called");
    console.log("The fetched status is: "+isUserActive1);
    this._router.navigate(['projectDashboard']);
  }



  closeProfileMenu() {
    this.isProfileMenuOpen = false;
  }
  
  toggleProfileMenu() {
      this.isProfileMenuOpen = !this.isProfileMenuOpen;
  }

  toggleSideMenu() {
    this.isSideMenuOpen = !this.isSideMenuOpen
  }
  closeSideMenu() {
      this.isSideMenuOpen = false
  } 
  togglePagesMenu() {
      this.isPagesMenuOpen = !this.isPagesMenuOpen
  }
  // Modal
  
  openModal() {
      this.isModalOpen = true
      this.trapCleanup = focusTrap(document.querySelector('#modal'))
  }
  closeModal() {
      this.isModalOpen = false
      if(this.trapCleanup)
      {
        this.trapCleanup;
      }
      
  }

}
function focusTrap(arg0: any): null {
  throw new Error('Function not implemented.');
}

