import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { ClienteComponent } from './Pages/cliente/cliente.component';
import { ComprobanteComponent } from './Pages/comprobante/comprobante.component';
import { EmpleadoComponent } from './Pages/empleado/empleado.component';
import { LibroComponent } from './Pages/libro/libro.component';
import { RecepcionComponent } from './Pages/recepcion/recepcion.component';
import { VentaComponent } from './Pages/venta/venta.component';
import { SharedModule } from 'src/app/Reutilizable/shared/shared.module';
import { ModalClienteComponent } from './Modales/modal-cliente/modal-cliente.component';


@NgModule({
  declarations: [
    ClienteComponent,
    ComprobanteComponent,
    EmpleadoComponent,
    LibroComponent,
    RecepcionComponent,
    VentaComponent,
    ModalClienteComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule
  ]
})
export class LayoutModule { }
