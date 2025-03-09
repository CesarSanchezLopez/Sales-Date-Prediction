
import { IOrder } from '../../models/order.interface';

import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Route, Router } from "@angular/router";
import { OrderService } from '../services/order.service';
//import { IOrder } from '../../models/order.model';
import { ICustomer } from '../../../app/models/customer.interface';  // assuming you have the customer model
import { LocationStrategy } from '@angular/common';
import { Location } from '@angular/common';

// @Component({
//   selector: 'app-order-list',
//   templateUrl: 'list.component.html',
//   styleUrls: ['list.component.css']
// })
// export class OrderListComponent implements OnInit {
//   oders: IOrder[] = [];
//   selectedCustomer: ICustomer | null = null;

//   constructor(private location: Locationprivate orderService: OrderService, private modalService: NgbModal) {}

//   ngOnInit(): void {
//     this.orderService.getOrders().subscribe((data) => {
//       this.oders = data;
//     });
//   }

//   openOrderDetails(content: any, customer: ICustomer) {
//     this.selectedCustomer = customer;
//     this.modalService.open(content, { centered: true, size: 'lg' });
//   }
@Component({
  selector: 'app-order-list',
  //templateUrl: './order-list.component.html',
  templateUrl: '../list/list.component.html',
  styleUrls: ['./list.component.css']
})


export class OrderListComponent implements OnInit {
  orders: IOrder[] = [];
  cusId: any;
  customerName: any;
  routeSub: any;
  q: number = 1;
  page: number = 1;
  itemsPerPage: number = 5;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private orderService: OrderService,
    private location: Location) {

  }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe((params) => {
       this.cusId = params["custId"];
       this.customerName= params["customerName"];
        console.log("id::"+ this.cusId);
       this.loadData(this.cusId);
      });
   
      
    // this.orderService.getOrders().subscribe((data) => {
    //   this.orders = data;
    // });      

    // const customerId = 1; // Replace with the actual customer ID
    // this.orderService.getOrders(customerId).subscribe((data) => {
    //   this.orders = data;
    // });
  }

  loadData(id: number) {
    this.orderService.getOrders(id).subscribe((res: any) => {

      this.orders = res;
     
    });
    }

    goBack(): void {
      this.location.back();
    }
  }

