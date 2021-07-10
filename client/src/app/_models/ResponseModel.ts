import { Example } from "./Example";

export class ResponseModel{
    data : Data;
    success : boolean;
}

export class Data{
    errors : string[];
    exampleObjects : Example[];
}