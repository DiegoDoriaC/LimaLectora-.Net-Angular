import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseApi } from '../Interfaces/response-api';
import { Cliente } from '../Interfaces/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private urlAPI:string = `${environment.endpoint}Cliente/`

  constructor(private http:HttpClient) { }

  listar():Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlAPI}Lista`)
  }

  registrar(request:Cliente):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(`${this.urlAPI}Registrar`,request)
  }

  buscarNombre(nombre:string):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlAPI}Buscar?nombre=${nombre}`)
  }

  buscar(id:number):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlAPI}Buscar/${id}`)
  }

  editar(request:Cliente):Observable<ResponseApi>{
    return this.http.put<ResponseApi>(`${this.urlAPI}Actualizar`, request)
  }

  eliminar(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.urlAPI}Eliminar/${id}`)
  }

}
