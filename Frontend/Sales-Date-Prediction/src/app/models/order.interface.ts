import { DecimalPipe } from "@angular/common";
import { InterpolationConfig } from "@angular/compiler";

export interface IOrder {
    orderId: number;
    custId: number;
    empId: number; //new
    shipperId: number; //new
    orderDate: Date;
    requiredDate: Date;
    shippedDate: Date;
    freight: number;  // Use number for decimal value
    shipName: string;
    shipAddress: string;
    shipCity: string;
    shipRegion: string;
    shipPostalCode: string;
    shipCountry: string;

    //Detalle
    productId: number;
    unitPrice: number; 
    qty: number;
    discount: number;  

  }