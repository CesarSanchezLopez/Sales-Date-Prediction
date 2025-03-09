import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderRoutingModule } from './order-routing.module';
import { OrderListComponent } from './list/list.component';
import { OrderCreateComponent } from './create/create.component';
import { FormOrderComponent } from './form-order/form-order.component';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination'; 
@NgModule({
  declarations: [
    OrderListComponent,
    OrderCreateComponent,
    FormOrderComponent,
  ],
  imports: [
    CommonModule,
    OrderRoutingModule,
    FormsModule,
    DatePipe,
    ReactiveFormsModule,
    NgxPaginationModule
  ]
})
export class OrderModule {}