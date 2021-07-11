import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExampleListComponent } from './_components/example-list/example-list.component';
import { PersonListComponent } from './_components/person-list/person-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PersonComponent } from './_components/person/person.component';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { PersonPhoneComponent } from './_components/person-phone/person-phone.component'; 
import { NgxMaskModule } from 'ngx-mask';
import { NavComponent } from './_components/nav/nav.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
@NgModule({
  declarations: [
    AppComponent,
    ExampleListComponent,
    PersonListComponent,
    PersonComponent,
    PersonPhoneComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: "toast-bottom-right",
      timeOut: 2000,
      progressBar: true,
      preventDuplicates: true
    }),
    FormsModule,
    NgxSpinnerModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: false
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
