import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Acceso } from 'src/app/Interfaces/acceso';
import { ClienteService } from 'src/app/Services/cliente.service';
import { UtilidadService } from 'src/app/Reutilizable/utilidad.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formularioLogin:FormGroup;
  ocultarPassword:boolean = true;
  mostrarLoading:boolean = false

  constructor(
    private fb:FormBuilder,
    private router:Router,
    private _usuarioServicio: ClienteService,
    private _utilidadServicio: UtilidadService    
  ) {
    this.formularioLogin = this.fb.group({
      dni:['', Validators.required, Validators.maxLength(8)],
      password:['', Validators.required]
    })
  }

  ngOnInit(): void {
  }

  iniciarSesion(){
    
  }

}
