import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonListComponent } from './_components/person-list/person-list.component';
import { PersonComponent } from './_components/person/person.component';

const routes: Routes = [
  {path: '', component: PersonListComponent},
  {path: 'person/view/:businessEntityID', component: PersonComponent},
  {path: 'person/edit/:businessEntityID', component: PersonComponent},
  {path: 'person/add', component: PersonComponent},
  {path: '**', component: PersonListComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
