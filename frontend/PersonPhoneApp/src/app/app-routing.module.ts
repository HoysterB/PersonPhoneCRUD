import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonComponent } from './person/person.component';
import { PersonCreateComponent } from './person/person-create/person-create.component';
import { PersonDetailComponent } from './person/person-detail/person-detail.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'person',
    component: PersonComponent,
  },
  {
    path: 'person/create',
    component: PersonCreateComponent,
  },
  {
    path: 'person/details/:id',
    component: PersonDetailComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
