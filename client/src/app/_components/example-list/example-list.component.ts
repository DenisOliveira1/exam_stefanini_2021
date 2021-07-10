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

  constructor(
    private exampleService : ExampleService
  ) { }

  ngOnInit(): void {
    this.loadExamples();
  }

  loadExamples(){
    this.exampleService.getExamples().subscribe((response : Example[]) => {
      this.examples = response;
    });
  }

}
