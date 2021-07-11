import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonListComponent } from './_components/person-list/person-list.component';
import { PersonPhoneComponent } from './_components/person-phone/person-phone.component';
import { PersonComponent } from './_components/person/person.component';

const routes: Routes = [
  {path: '', component: PersonListComponent},

  {path: 'person/view/:businessEntityID', component: PersonComponent},
  {path: 'person/edit/:businessEntityID', component: PersonComponent},
  {path: 'person/add', component: PersonComponent},

  {path: 'phone/view/:businessEntityID/:phoneNumber/:phoneNumberTypeID', component: PersonPhoneComponent},
  {path: 'phone/edit/:businessEntityID/:phoneNumber/:phoneNumberTypeID', component: PersonPhoneComponent},
  {path: 'phone/add/:businessEntityID', component: PersonPhoneComponent},

  {path: '**', component: PersonListComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
