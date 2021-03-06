import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
import { DealerCarsComponent } from './dealer-cars/dealer-cars.component';

const routes: Routes = [
  { path: '', component: ListComponent },
  { path:'my', component: DealerCarsComponent},
  { path: 'create', component: CreateComponent},
  { path: ':id', component: ViewComponent },
  { path: ':id/edit', component: EditComponent },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class CarsRoutingModule { } 