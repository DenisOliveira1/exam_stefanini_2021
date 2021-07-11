import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Person } from '../_models/Person';
import { PersonPhone } from '../_models/PersonPhone';
import { ResponseModel } from '../_models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl = environment.apiUrl;

  constructor(
    private httpClient : HttpClient
  ) { }

  getPeople(){
    return this.httpClient.get(this.baseUrl + "person").pipe(
      map((response : ResponseModel<Person>) => {
        return response.data.objects;
      })
    );
  }

  getPersonById(id : number){
    return this.httpClient.get(this.baseUrl + "person/" + id).pipe(
      map((response : ResponseModel<Person>) => {
        return response.data.object;
      })
    );
  }

  updatePerson(person : Person){
    return this.httpClient.put(this.baseUrl + "person/", person).pipe(
    );
  }

  insertPerson(person : Person){
    return this.httpClient.post(this.baseUrl + "person/", person);
  }

  deletePersonById(id : number){
    return this.httpClient.delete(this.baseUrl + "person/" + id);
  }

}
