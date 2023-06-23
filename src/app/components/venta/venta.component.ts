import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VentaService } from 'src/app/services/venta.service';

@Component({
  selector: 'app-venta',
  templateUrl: './venta.component.html',
  styleUrls: ['./venta.component.css']
})

export class VentaComponent implements OnInit {
  listProductos: any[] = [];
  listVenta: any[] = [];
  agregar = 'Agregar';
  descripcion = 'Descripcion';
  valor = 'Valor';
  color = 'Color';
  cantidad = 'Cantidad';
  agregarProducto = false;
  form: FormGroup;
  id: number | undefined;

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private _ventaService: VentaService,
    ) { 
      this.form = this.fb.group({
        nombre: ['', Validators.required],
        direccion: ['', Validators.required],
    })
  }

  ngOnInit(): void {
    this.obtenerProducto();
  }

  obtenerProducto(){
    this._ventaService.getListProductos().subscribe(data => {      
      this.listProductos = data;      
    }, error => {
      this.toastr.error('ocurrio un error!', 'Error al obtener los productos');    
    })
  }

  seleccionarProducto(producto: any){
    this._ventaService.listVenta.push(producto)
    this._ventaService.total = this._ventaService.total + producto.valor;  
    this.toastr.info('El producto fue agregado con exito!', 'Producto agregado');
  } 
}