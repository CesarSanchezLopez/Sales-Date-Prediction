import { Injectable } from '@angular/core';
import { Observable, forkJoin } from 'rxjs';
import { IOrder } from '../../models/order.interface';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(public http: HttpClient) { }

  // getOrders() {
  
  //     return this.http.get(`${environment.api}/Order/GetCustId/`);
  //   }

 getOrders(id: number) {
  
      return this.http.get(`${environment.api}/Order/GetCustId/${id}`);
   }
  
 
  createOrder(order: IOrder) {
    // Mock order creation
    console.log("esooooo",order);
    return this.http.post(`${environment.api}/Order`, order);
  }

  getDataToList(): Observable<any[]> {
    
    let list_Employee = this.http.get(`${environment.api}/Employee`);
    let list_Shipper = this.http.get(`${environment.api}/Shipper`);
    let list_Product = this.http.get(`${environment.api}/Product`);
    
    return forkJoin([list_Employee, list_Shipper,list_Product]);
  }
}