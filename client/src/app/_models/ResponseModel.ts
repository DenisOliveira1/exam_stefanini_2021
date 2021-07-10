import { Example } from "./Example";

export class ResponseModel{
    data : Data;
    success : boolean;
}

export class Data{
    errors : string[];
    success : boolean;
    exampleObjects : Example[];
    exampleObject : Example;
}