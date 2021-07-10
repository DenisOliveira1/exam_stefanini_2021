import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../_models/ResponseModel';
import { map } from 'rxjs/operators';
import { Example } from '../_models/Example';

@Injectable({
  providedIn: 'root'
})
export class ExampleService {

  baseUrl = environment.apiUrl;

  constructor(
    private httpClient : HttpClient
  ) { }

  getExamples(){
    return this.httpClient.get(this.baseUrl + "example").pipe(
      map((response : ResponseModel) => {
        return response.data.exampleObjects;
      })
    );
  }

  getExampleById(id : number){
    return this.httpClient.get(this.baseUrl + "example/" + id).pipe(
      map((response : ResponseModel) => {
        return response.data.exampleObject;
      })
    );
  }

  updateExample(example : Example){
    return this.httpClient.put(this.baseUrl + "example/", example);
  }

  insertExample(example : Example){
    return this.httpClient.post(this.baseUrl + "example/", example);
  }

  deleteExampleById(id : number){
    return this.httpClient.delete(this.baseUrl + "example/" + id);
  }

}
