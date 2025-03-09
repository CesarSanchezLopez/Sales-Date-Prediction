import { Component, computed, OnInit, signal } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { ICustomer } from '../../../models/customer.interface';
import { Pipe, PipeTransform } from '@angular/core';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit  {

  customers: ICustomer[] = [];
  q: number = 1;
  
  page: number = 1;
  itemsPerPage: number = 5;

  searchTerm: string = '';
  currentPage: number = 1;
  pageSize: number = 3; 
  
  
  constructor(private customerService: CustomerService) { 

  }

  ngOnInit(): void {
    //this.customerService.getCustomers().subscribe((data: ICustomer[]) => {
    this.customerService.getCustomers().subscribe((res: any) => {
      console.log(res);
      this.customers = res;
    });
  
  }



  filteredCustomers() {
    return this.customers.filter(customer =>
      customer.customerName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
  // get totalItems() {
  //   return this.customers.length;
  // }

  // // Get the filtered customers based on the search term
  // get filteredCustomers() {
  //   return this.customers.filter(customer =>
  //     customer.customerName.toLowerCase().includes(this.searchTerm.toLowerCase())
  //   );
  // }

  // // Get the customers for the current page based on the filtered list
  // paginatedCustomers() {
  //   const start = (this.currentPage - 1) * this.pageSize;
  //   const end = start + this.pageSize;
  //   return this.filteredCustomers.slice(start, end); // Show customers based on pagination and search filter
  // }
  
  
}