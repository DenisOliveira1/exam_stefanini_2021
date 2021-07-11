import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PersonPhone } from '../_models/PersonPhone';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {

  baseUrl = environment.apiUrl;

  constructor(
    private httpClient : HttpClient
    ) { }

  insertPhone(phone : PersonPhone){
    return this.httpClient.post(this.baseUrl + "phone", phone).pipe(
    );
  }

  updatePhone(phone : PersonPhone){
    return this.httpClient.put(this.baseUrl + "phone/update", phone);
  }

  deletePhone(phone : PersonPhone){
    return this.httpClient.post(this.baseUrl + "phone/delete", phone);
  }
}
