export interface IOrderDetail {
  orderId: number;
  productId: number;
  unitPrice: number;  // Use number for decimal value
  qty: number;
  discount: number;   // Use number for decimal value
}