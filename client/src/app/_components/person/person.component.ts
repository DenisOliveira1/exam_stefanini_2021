import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NumberTypeEnum } from 'src/app/_models/enums/NumberTypeEnum';
import { Person } from 'src/app/_models/Person';
import { PersonPhone } from 'src/app/_models/PersonPhone';
import { PersonPhoneService } from 'src/app/_services/person-phone.service';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  @ViewChild("editForm") editForm: NgForm;

  person : Person;
  isEdit : boolean;
  isAdd : boolean;

  constructor(
    private personService : PersonService,
    private personPhoneService : PersonPhoneService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ){
    
  }

  ngOnInit(): void {
    this.isEdit = this.route.snapshot.url[1].path === 'edit' ? true : false;
    this.isAdd = this.route.snapshot.url[1].path === 'add' ? true : false;

    if (this.isAdd){
      this.person = new Person();
    } else{
      this.loadPerson();
    }
  }

  loadPerson(){
    this.personService.getPersonById(parseInt(this.route.snapshot.paramMap.get("businessEntityID"))).subscribe(person => {
      this.person = person;
    })
  }

  updatePerson(){
    if (!this.isPersonValid()) return;
    this.personService.updatePerson(this.person).subscribe(() => {
      this.toastr.success("Person updated successfully");
      this.router.navigateByUrl("/");
    })
  }

  insertPerson(){
    if (!this.isPersonValid()) return;
    this.personService.insertPerson(this.person).subscribe(() => {
      this.toastr.success("Person added successfully");
      this.router.navigateByUrl("/");
    })
  }

  isPersonValid() : boolean{
    if (this.person.name == ""){
      this.toastr.warning("Name field must be filled");
      return false;
    }
    return true;
  }

  deletePhone(phone : PersonPhone){
    this.personPhoneService.deletePhone(phone).subscribe( () => {
      this.toastr.success("Phone deleted successfully");

      const index = this.person.phones?.indexOf(phone);
      this.person.phones?.splice(index,1);
    })
  }

  getNumberTypeEnum = (value : number) => NumberTypeEnum[value];
}
