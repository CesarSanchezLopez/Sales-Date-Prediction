import { Component , OnInit } from '@angular/core';
import { IOrder } from '../../models/order.interface';
import { IOrderDetail  } from '../../models/orderdetail.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrderService } from '../services/order.service';
import { ActivatedRoute, Route, Router } from "@angular/router";
import { Location } from '@angular/common';
@Component({
  selector: 'app-form-order',
  templateUrl: './form-order.component.html',
  styleUrls: ['./form-order.component.css']
})
export class FormOrderComponent implements OnInit {
  orderForm!: FormGroup;
  orderDetailsForm!: FormGroup;
  cusId: any;
  customerName: any;
  routeSub: any;

  listEmployes: { empId: number, fullName: string }[] = [];
  listShipper: { shipperId: number, companyName: string }[] = [];
  listProduct : { productId: number, productName: string }[] = [];


  constructor
  (
    private fb: FormBuilder,
    private orderService: OrderService, 
    private router: Router,  
    private route: ActivatedRoute,  
    private location: Location
  ) 
  {}

  
  ngOnInit(): void {  

    this.routeSub = this.route.params.subscribe((params) => {
      this.cusId = params['custId'];
      this.customerName= params['customerName'];
      console.log("Prr:"+this.customerName);
     
     });

    this.loadList();
    this.createForm();
  }

  createForm(): void {
    this.orderForm = this.fb.group({
      listEmployes: ["", Validators.required],
      listShipper: ["", Validators.required],
      listProduct: ["", Validators.required],
    
      orderDate: [null, Validators.required],
      requiredDate: [null, Validators.required],
      shippedDate: [null, Validators.required],
      freight: [null, [Validators.required, Validators.min(0)]],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],

      unitPrice: [null, [Validators.required, Validators.min(0)]],
      qty: [null, [Validators.required, Validators.min(1)]],
      discount: [null, [Validators.required, Validators.min(0)]], // Discount should be between 0 and 1 (0-100%)
    });


  }

  async loadList() {
    console.log("loadList555");
    await this.orderService.getDataToList().subscribe((res: any) => {
      console.log(res[0]);
      this.listEmployes = res[0];
      this.listShipper= res[1];
      this.listProduct= res[2];
    });
    
  }


  addOrder() {
    console.log(this.orderForm);
    if (this.orderForm.invalid) {
   
      this.showErrors();
    } else {
      console.log("pASSSS");
      const data: IOrder = {
        orderId: 0,
        custId:  this.cusId,
        //custId: 44, // this.cusId,
        empId: this.orderForm.get("listEmployes")!.value,
        orderDate:this.orderForm.get("orderDate")!.value,
        requiredDate: this.orderForm.get("requiredDate")!.value,
        shipperId:  this.orderForm.get("listShipper")!.value, 
        shippedDate: this.orderForm.get("shippedDate")!.value,
        freight:this.orderForm.get("freight")!.value,
       
        shipName:  this.orderForm.get("shipName")!.value,
        shipAddress: this.orderForm.get("shipAddress")!.value,
        shipCity: this.orderForm.get("shipCity")!.value,
        shipRegion: '',
        shipPostalCode: '',
        shipCountry: this.orderForm.get("shipCountry")!.value,
        //this.orderForm.get("orderDate")!.value,
       
        productId: this.orderForm.get("listProduct")!.value, 
        unitPrice: this.orderForm.get("unitPrice")!.value,
        qty: this.orderForm.get("qty")!.value,
        discount:1// this.orderForm.get("discount")!.value,
       
      };
       console.log(data);
       this.orderService.createOrder(data).subscribe((res) => {
       this.router.navigate(["/customers"]);
      });
      
      //this.router.navigate(['/order']);
    }
  }

  private showErrors() {
    this.orderForm.get("listEmployes")!.markAllAsTouched();
    this.orderForm.get("listShipper")!.markAllAsTouched();
    this.orderForm.get("listProduct")!.markAllAsTouched();
   
    this.orderForm.get("orderDate")!.markAllAsTouched();
    this.orderForm.get("requiredDate")!.markAllAsTouched();
    this.orderForm.get("shippedDate")!.markAllAsTouched();
    this.orderForm.get("freight")!.markAllAsTouched();
    this.orderForm.get("shipName")!.markAllAsTouched();
    this.orderForm.get("shipAddress")!.markAllAsTouched();
    this.orderForm.get("shipCity")!.markAllAsTouched();
    this.orderForm.get("shipCountry")!.markAllAsTouched();

    this.orderForm.get("productId")!.markAllAsTouched();
    this.orderForm.get("unitPrice")!.markAllAsTouched();
    this.orderForm.get("qty")!.markAllAsTouched();
    this.orderForm.get("discount")!.markAllAsTouched();

  }
  goBack(): void {
    this.location.back();
  }
}
