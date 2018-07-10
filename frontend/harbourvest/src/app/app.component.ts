import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {

  title = 'Harbour Vest Tech Test';
  formError = false
  orders = []
  orderResponse: any;
  restItemsUrl = 'http://localhost:63651/api/orders';
  orderResult: String = ''

  constructor(private http: HttpClient) { }

  getOrders(params: String): void {
    this.orderServiceGetOrders(params)
      .subscribe(
        orderResponse => {
          this.orderResult = orderResponse.toString();
          this.orders.push({ orderText: params, orderResult: orderResponse });
        }
      )
  }

  orderServiceGetOrders(params: String) {
    return this.http
      .get<any[]>(this.restItemsUrl + '/' + params)
      .pipe(map(data => data));
  }

  onSubmit(form: NgForm) {
    this.formError = !form.valid;
    if (form.valid) {
      this.getOrders(form.value.orderText);
    }
  }

  ClearForm(form: NgForm) {
    form.reset();
  }

  ClearHistory() {
    this.orders.length = 0;
    this.orders = [];
  }

}
