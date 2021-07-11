import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Person } from '../_models/Person';
import { ResponseModel } from '../_models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl = environment.apiUrl;
  // people : Person[];

  constructor(
    private httpClient : HttpClient
  ) { }

  getPeople(){
    // if (this.people.length > 0) return of(this.people);

    return this.httpClient.get(this.baseUrl + "person").pipe(
      map((response : ResponseModel<Person>) => {
        // this.people =  response.data.objects;
        return response.data.objects;
      })
    );
  }

  getPersonById(id : number){
    // const person = this.people?.find(x => x.businessEntityID === id);
    // if (person !== undefined) return of(person);

    return this.httpClient.get(this.baseUrl + "person/" + id).pipe(
      map((response : ResponseModel<Person>) => {
        return response.data.object;
      })
    );
  }

  updatePerson(example : Person){
    return this.httpClient.put(this.baseUrl + "person/", example);
  }

  insertPerson(example : Person){
    return this.httpClient.post(this.baseUrl + "person/", example);
  }

  deletePersonById(id : number){
    return this.httpClient.delete(this.baseUrl + "person/" + id);
  }

}
