import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ICustomer } from '../../models/customer.interface';
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})
export class CustomerService {

  constructor(public http: HttpClient) { }

  // Mock data - you can replace this with an API call later
  //getCustomers(): Observable<ICustomer[]> {
    getCustomers() {
  
      return this.http.get(`${environment.api}/Customer/CustomerOrderPrediction`);
    }
  
    
}