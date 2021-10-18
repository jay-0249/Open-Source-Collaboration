import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Project } from '../Models/project';
import { ProjectsService } from '../Services/projects.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {

  projectForm;
  roles: any[] =["Maintainer","Developer","Admin"];
  projectType:any[]=["Sandbox Project","Incubated Project","Graduated Project"];
  constructor(private _service:ProjectsService,private formBuilder:FormBuilder, private _router:Router) { 
    this.projectForm = this.formBuilder.group(
      {
        projectTitle:['',[Validators.required]],
        projectDomain:[''],
        projectTechTools:[''],
        projectDescription:['',[Validators.required]],
        projectContactInfo:['',[Validators.required]],
        projectType:[''],
        projectRole:['']
      }
    )
  }

  
  ngOnInit(): void {
  }

  //to submit the form
  //here I have used the constant 'formvalue' to post the project object to match with api input formbody 
  onSubmit() {
    console.log("project submitted")
    console.log(this.projectForm.value);
    const formvalue = this.projectForm.value;
    let newProj1:Project = new Project();
    newProj1.projectTitle = formvalue.projectTitle;
    newProj1.domain =       formvalue.projectDomain;
    newProj1.description=   formvalue.projectDescription;
    newProj1.contactMail=   formvalue.projectContactInfo;
    newProj1.techTools=     formvalue.projectTechTools;
    console.log("I am now printing the formvalue");
    console.log(formvalue);
    //this.projectForm.reset()
    //res is response of observable it performs the action in {...} in 'res=>{...}' after
    //after web api says the http request is sucessfully executed
    //reset() resets the all form values to empty 
    this._service.addProject(newProj1).subscribe(res=>{
          this.projectForm.reset();
          console.log("This is the projectform after submision");
          console.log(this.projectForm);
          this._router.navigate(['/projectDashboard']);
    });
    
    
  }


}
