import { Component, OnInit } from '@angular/core';
import { Example } from 'src/app/_models/Example';
import { Data } from 'src/app/_models/ResponseModel';
import { ExampleService } from 'src/app/_services/example.service';

@Component({
  selector: 'app-example-list',
  templateUrl: './example-list.component.html',
  styleUrls: ['./example-list.component.css']
})
export class ExampleListComponent implements OnInit {

  examples : Example[];
  example : Example;

  constructor(
    private exampleService : ExampleService
  ) { }

  ngOnInit(): void {
    this.loadExamples();
    this.loadExample();
    this.insertExample();
  }

  loadExamples(){
    this.exampleService.getExamples().subscribe((response : Example[]) => {
      this.examples = response;
      this.deleteExample();
    });
  }

  loadExample(){
    this.exampleService.getExampleById(3).subscribe((response : Example) => {
      this.example = response;
      this.updateExample();
    });
  }

  updateExample(){
    const date = new Date();
    this.example.nome = "Updated " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    this.exampleService.updateExample(this.example).subscribe(() => {
    });
  }

  insertExample(){
    const date = new Date();
    const exampleNew : Example = {
      id: 0,
      nome: "Inserted " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString()
    }; 
    this.exampleService.insertExample(exampleNew).subscribe(() => {
    });
  }

  deleteExample(){
    if (this.examples.length-1 >= 0){
      const idDelete = this.examples[this.examples.length-1].id;
      this.exampleService.deleteExampleById(idDelete).subscribe(() => {
          console.log("Deleted: " + idDelete)
      });
    }

  }

}
