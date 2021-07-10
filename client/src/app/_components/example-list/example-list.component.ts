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
  }

  loadExamples(){
    this.exampleService.getExamples().subscribe((response : Example[]) => {
      this.examples = response;
    });
  }

  loadExample(){
    this.exampleService.getExampleById(3).subscribe((response : Example) => {
      this.example = response;
    });
  }

}
