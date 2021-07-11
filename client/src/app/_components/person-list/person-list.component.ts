import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Person } from 'src/app/_models/Person';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  people : Person[];

  constructor(
    private personService : PersonService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.loadPeople();
  }

  loadPeople(){
    this.personService.getPeople().subscribe((response : Person[]) => {
      this.people = response;
    });
  }

  deletePerson(id : number){
    this.personService.deletePersonById(id).subscribe(() => {
      this.toastr.success("Person deleted successfully");
      this.people = this.people.filter(x => x.businessEntityID !== id);
    });
  }

}
