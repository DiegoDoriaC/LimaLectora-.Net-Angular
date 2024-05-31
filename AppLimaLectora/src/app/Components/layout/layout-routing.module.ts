import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { ClienteComponent } from './Pages/cliente/cliente.component';
import { ComprobanteComponent } from './Pages/comprobante/comprobante.component';
import { EmpleadoComponent } from './Pages/empleado/empleado.component';
import { LibroComponent } from './Pages/libro/libro.component';
import { RecepcionComponent } from './Pages/recepcion/recepcion.component';
import { VentaComponent } from './Pages/venta/venta.component';

const routes: Routes = [{
  path:'', component:LayoutComponent,
  children:[
    {path:'cliente', component:ClienteComponent},
    {path:'comprobante', component:ComprobanteComponent},
    {path:'empleado', component:EmpleadoComponent},
    {path:'libro', component:LibroComponent},
    {path:'recepcion', component:RecepcionComponent},
    {path:'venta', component:VentaComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
