export class ResponseModel<T>{
    data : Data<T>;
    success : boolean;
}

export class Data<T>{
    errors : string[];
    success : boolean;
    objects : T[];
    object : T;
}