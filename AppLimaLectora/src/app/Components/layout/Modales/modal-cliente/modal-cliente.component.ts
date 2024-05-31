import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validator, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/Interfaces/cliente';
import { ClienteService } from 'src/app/Services/cliente.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';

@Component({
  selector: 'app-modal-cliente',
  templateUrl: './modal-cliente.component.html',
  styleUrls: ['./modal-cliente.component.css']
})
export class ModalClienteComponent implements OnInit {

  formularioCliente:FormGroup;
  tituloAccion:string = 'Agregar';
  botonAccion:string = 'Guardar';

  constructor(
    private modalActual:MatDialogRef<ModalClienteComponent>,
    @Inject(MAT_DIALOG_DATA) public datosCliente:Cliente,
    private fb: FormBuilder,
    private _clienteServicio: ClienteService,
    private _utilidadServicio: UtilidadService
  ) { 
    this.formularioCliente = this.fb.group({
      dni:['', Validators.required],
      nombre:['', Validators.required],
      apellido:['', Validators.required],
        //OPCIONALES
      email:['', Validators.required],
      telefono:['', Validators.required],
      esActivo:['1', Validators.required]
    })

    if(datosCliente != null){
      this.tituloAccion = 'Editar';
      this.botonAccion = 'Actualizar';
    }   

  }

  ngOnInit(): void {
    if(this.datosCliente != null){
      this.formularioCliente.patchValue({
        dni:this.datosCliente.dni,
        nombre:this.datosCliente.nombre,
        apellido:this.datosCliente.apellido,
          //OPCIONALES
        email:this.datosCliente.email,
        telefono:this.datosCliente.telefono,
        esActivo:this.datosCliente.esActivo.toString()
      })
    }
  }

  guardarEditarCliente(){
    const _cliente:Cliente = {
      idCliente: this.datosCliente == null ? 0 : this.datosCliente.idCliente,
      dni: this.formularioCliente.value.dni,
      nombre: this.formularioCliente.value.nombre,
      apellido: this.formularioCliente.value.apellido,
      email: this.formularioCliente.value.email,
      telefono: this.formularioCliente.value.telefono,
      esActivo: parseInt(this.formularioCliente.value.esActivo)
    }

    if(this.datosCliente == null){
      this._clienteServicio.registrar(_cliente).subscribe({
        next:(data) => {
          if(data.status){
            this._utilidadServicio.mostrarAlerta('Cliente registrado', 'Exito');
            this.modalActual.close('true');
          }
          else{
            this._utilidadServicio.mostrarAlerta('No se pudo registrar el cliente', 'Error')
          }
        },
        error:(e) => {}
      })
    }
    else{
      this._clienteServicio.editar(_cliente).subscribe({
        next:(data) => {
          if(data.status){
            this._utilidadServicio.mostrarAlerta('Cliente editado', 'Exito');
            this.modalActual.close('true');
          }
          else{
            this._utilidadServicio.mostrarAlerta('No se pudo editar el cliente', 'Error')
          }
        },
        error:(e) => {}
      })
    }

  }

}
