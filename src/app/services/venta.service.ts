import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VentaService {  
  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = environment.apiVenta;

  public listVenta: any[] = [];
  public total: number = 0;
  
  constructor(private http: HttpClient) { }

  getListProductos(): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }

  saveProducto(producto: any): Observable<any> {    
    return this.http.post(this.myAppUrl + this.myApiUrl, producto)
  }
}
