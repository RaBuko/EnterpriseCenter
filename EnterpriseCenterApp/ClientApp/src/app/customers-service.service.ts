import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../environments/environment'
import { Customer } from './customers-view/customers-view.component';

@Injectable({
  providedIn: 'root'
})
export class CustomersServiceService {

  constructor(private http: HttpClient) { }

  path = environment.apiEndpoint + "/customers";

  public getAllCustomers(): Observable<Customer[]> {
    return this.http.get(this.path) 
  }
}
