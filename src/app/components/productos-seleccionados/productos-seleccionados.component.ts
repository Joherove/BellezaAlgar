import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VentaService } from 'src/app/services/venta.service'
import { VentaComponent } from 'src/app/components/venta/venta.component'

@Component({
  selector: 'app-productos-seleccionados',
  templateUrl: './productos-seleccionados.component.html',
  styleUrls: ['./productos-seleccionados.component.css']
})

export class ProductosSeleccionadosComponent {
  listVenta: any[] = this._ventaService.listVenta;  
  form: FormGroup;  
  descripcion = 'Descripcion';
  valor = 'Valor';
  color = 'Color';
  
  constructor(private fb: FormBuilder,
              private toastr: ToastrService,
              private _ventaService: VentaService,
              private _ventaComponent: VentaComponent) {
                this.form = this.fb.group({
                  nombre: ['', Validators.required],
                  direccion: ['', Validators.required],
              })
  }

  get showTotal(){
    return this._ventaService.total;
  }

  guardarProducto(){     
    for (let o of this.listVenta) {
      const productos: any = {
        productoId: o.productoId,
        valor: o.valor,
        inventarioColoresId: o.inventarioColoresId,
        nombre: this.form.get('nombre')?.value,
        direccion: this.form.get('direccion')?.value,        
      }

      this._ventaService.saveProducto(productos).subscribe(data => {        
        this._ventaComponent.obtenerProducto();
      }, error => {
        this.toastr.error('ocurrio un error!', 'Error en compra');        
      })
    } 
    this.toastr.success('La compra fue realizada con exito!', 'Compra registrada');
    this.form.reset(); 
    this._ventaService.listVenta = [];
    this.listVenta = this._ventaService.listVenta;
    this._ventaService.total = 0;
    this._ventaComponent.obtenerProducto();
  }  
}
