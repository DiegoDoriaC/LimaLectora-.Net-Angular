import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { ModalClienteComponent } from '../../Modales/modal-cliente/modal-cliente.component';
import { Cliente } from 'src/app/Interfaces/cliente';
import { ClienteService } from 'src/app/Services/cliente.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit, AfterViewInit {

  columnasTabla:string[] = ['Dni', 'Nombre', 'Apellido', 'Email', 'Telefono', 'Estado', 'Acciones'];
  dataInicio:Cliente[] = [];
  dataListaCliente = new MatTableDataSource(this.dataInicio);
  @ViewChild(MatPaginator) paginacionTabla!:MatPaginator;

  constructor(
    private dialog:MatDialog,
    private _clienteServicio:ClienteService,
    private _utilidadServicio:UtilidadService
  ) { }

  obtenerClientes(){
    this._clienteServicio.listar().subscribe({
      next:(data) => {
        if(data.status) {
          this.dataListaCliente = data.value;
        }
        else this._utilidadServicio.mostrarAlerta('No se encontraron datos', 'Oops!')
      },
      error:(e) => {}
    })
  }

  ngOnInit(): void {
    this.obtenerClientes();
  }

  ngAfterViewInit(): void {
    this.dataListaCliente.paginator = this.paginacionTabla
  }

  aplicarFiltroTabla(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataListaCliente.filter = filterValue.trim().toLocaleLowerCase();
  }

  nuevoCliente(){
    this.dialog.open(ModalClienteComponent, {
      disableClose:true
    }).afterClosed().subscribe(resultado => {
      if(resultado == 'true') this.obtenerClientes();
    });
  }

  editarCliente(cliente:Cliente){
    this.dialog.open(ModalClienteComponent, {
      disableClose:true,
      data:cliente
    }).afterClosed().subscribe(resultado => {
      if(resultado == 'true') this.obtenerClientes();
    });
  }

  eliminarCliente(cliente:Cliente){
    Swal.fire({
      title:'Desea eliminar el usuario?',
      text: cliente.nombre,
      icon:'warning',
      confirmButtonColor:'#3085d6',
      confirmButtonText: 'Si, eliminar',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No, volver'
    }).then((resultado) => {
      if(resultado.isConfirmed){
        this._clienteServicio.eliminar(cliente.idCliente).subscribe({
          next:(data) => {
            if(data.status){
              this._utilidadServicio.mostrarAlerta('El cliente fue eliminado', 'Listo!')
              this.obtenerClientes();
            }else this._utilidadServicio.mostrarAlerta('No se pudo eliminar cliente', 'Error')
          },
          error:(e) => {}
        })
      }
    })
  }

}
