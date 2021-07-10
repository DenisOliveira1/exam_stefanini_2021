import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Example } from '../_models/Example';
import { ResponseModel } from '../_models/ResponseModel';

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
      map((response : ResponseModel<Example>) => {
        return response.data.objects;
      })
    );
  }

  getExampleById(id : number){
    return this.httpClient.get(this.baseUrl + "example/" + id).pipe(
      map((response : ResponseModel<Example>) => {
        var a = response.data.object;
        return a;
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
