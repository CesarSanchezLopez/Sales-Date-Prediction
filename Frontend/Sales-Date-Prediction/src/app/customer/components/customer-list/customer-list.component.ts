import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { ICustomer } from '../../../models/customer.interface';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers: ICustomer[] = [];
  q: number = 1;

  page: number = 1;
  itemsPerPage: number = 5;


  
  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    //this.customerService.getCustomers().subscribe((data: ICustomer[]) => {
    this.customerService.getCustomers().subscribe((res: any) => {
      console.log(res);
      this.customers = res;
    });
  }
  
}