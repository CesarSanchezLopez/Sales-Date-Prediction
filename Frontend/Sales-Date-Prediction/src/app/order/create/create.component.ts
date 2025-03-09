import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrderService } from '../services/order.service';
import { IOrder } from '../../models/order.interface';
@Component({
  selector: 'app-order-create',
  templateUrl: '../create/create.component.html',
  styleUrls: ['../create/create.component.css']
})
export class OrderCreateComponent {
  newOrder: IOrder = {
    orderId: 0,
    custId: 0,
    empId: 0, //new
    shipperId: 0, //new
    orderDate: new Date(),
    requiredDate: new Date(),
    shippedDate: new Date(),
    freight: 0,
    shipName: '',
    shipAddress: '',
    shipCity: '',
    shipRegion: '',
    shipPostalCode: '',
    shipCountry: '',

    productId: 0,
    unitPrice:0,
    qty:0,
    discount:0,
  };

  constructor(private orderService: OrderService, private router: Router) {}

  createOrder(): void {
    this.orderService.createOrder(this.newOrder).subscribe((data) => {
      this.router.navigate(['/order']);
    });
  }
}