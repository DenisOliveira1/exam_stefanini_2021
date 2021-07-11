import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Person } from 'src/app/_models/Person';
import { PersonPhone } from 'src/app/_models/PersonPhone';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person-phone',
  templateUrl: './person-phone.component.html',
  styleUrls: ['./person-phone.component.css']
})
export class PersonPhoneComponent implements OnInit {

  @ViewChild("editForm") editForm: NgForm;

  phone : PersonPhone;
  isEdit : boolean;
  isAdd : boolean;

  constructor(
    private personService : PersonService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ){
    
  }

  ngOnInit(): void {
    this.isEdit = this.route.snapshot.url[1].path === 'edit' ? true : false;
    this.isAdd = this.route.snapshot.url[1].path === 'add' ? true : false;

    if (this.isAdd){
      this.phone = new PersonPhone();
      this.phone.businessEntityID = parseInt(this.route.snapshot.paramMap.get("businessEntityID"));
      this.phone.phoneNumber = "";
      this.phone.phoneNumberTypeID = undefined;
    } else{
      this.loadPersonPhone();
    }
  }

  loadPersonPhone(){
    this.personService.getPersonById(parseInt(this.route.snapshot.paramMap.get("businessEntityID"))).subscribe(person => {

      const businessEntityIDCurrent = parseInt(this.route.snapshot.paramMap.get("businessEntityID"));
      const phoneNumberCurrent = this.route.snapshot.paramMap.get("phoneNumber");
      const phoneNumberTypeIDurrent = parseInt(this.route.snapshot.paramMap.get("phoneNumberTypeID"));

      this.phone = person.phones.filter(x => {
        return x.businessEntityID === businessEntityIDCurrent && 
        x.phoneNumber === phoneNumberCurrent && 
        x.phoneNumberTypeID === phoneNumberTypeIDurrent;
      })[0];
    })
  }

  updatePhone(){
    if (!this.isPhoneValid()) return;
  }

  insertPhone(){
    if (!this.isPhoneValid()) return;
  }

  isPhoneValid() : boolean{

    let errors = 0;

    if (this.phone.phoneNumber == ""){
      this.toastr.warning("Phone number field must be filled");
      errors++;
    }
    if (this.phone.phoneNumberTypeID == undefined || this.phone.phoneNumberTypeID.toString() == ""){
      this.toastr.warning("Type field must be filled");
      errors++;
    }

    if (errors > 0) return false;
    return true;
  }

}
