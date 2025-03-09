import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderListComponent } from './list/list.component';
import { OrderCreateComponent } from './create/create.component';
import { FormOrderComponent } from './form-order/form-order.component';

const routes: Routes = [
  { path: 'order/:custId/:customerName', component: OrderListComponent },
   { path: 'order/create', component: FormOrderComponent },
   { path: 'order/create/:custId', component: FormOrderComponent },
   { path: 'order/create/:custId/:customerName', component: FormOrderComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule {}